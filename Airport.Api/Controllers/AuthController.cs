using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Airport.Data.UnitOfWork;
using Airport.Domain;
using Microsoft.AspNetCore.Mvc;
using Airport.Api.Models;
using Airport.Api.Services;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Airport.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IUnitOfWork uow;
        IAuthService authService;

        public AuthController(IUnitOfWork uow, IAuthService authService)
        {
            this.uow = uow;
            this.authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult<AuthData> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            User user = uow.User.FindByEmail(model.Email);
            
            if(user == null)
            {
                return BadRequest(new { email = "no user with this eamil" });
            }

            bool passwordValid = authService.VerifyPassword(model.Password, user.Password);

            if (!passwordValid)
            {
                return BadRequest(new { password = "invalid password" });
            }

            return authService.GetAuthData(user.Id, user.Role);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public ActionResult Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if(uow.User.GetOne(u => u.Email == model.Email) != null)
            {
                return BadRequest(new { email = "user with this email already exists" });
            }

            if (uow.User.GetOne(u => u.Username == model.Username) != null)
            {
                return BadRequest(new { email = "user with this username already exists" });
            }

            string id = Guid.NewGuid().ToString();


            var user = new User
            {
                Id = id,
                Username = model.Username,
                Email = model.Email,
                Password = authService.HashPassword(model.Password),
                Role = model.Role
            };

            uow.User.Add(user);
            uow.Commit();

            return Ok(user);

        }



    }
}
