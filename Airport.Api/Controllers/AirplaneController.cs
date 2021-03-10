using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Airport.Data.UnitOfWork;
using Airport.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Airport.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AirplaneController : ControllerBase
    {
        IUnitOfWork uow;

        public AirplaneController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [HttpGet("getall")]
        public List<Airplane> Get()
        {
            return uow.Airplane.GetAll();
        }

        [HttpGet("get/{id}")]
        [Authorize(Roles = Role.Admin)]
        public ActionResult Get(int id)
        {
            Airplane airplane = uow.Airplane.FindById(id);
            if (airplane != null)
            {
                return Ok(airplane);
            }
            return NotFound();
        }


        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public ActionResult Post([FromBody] Airplane item)
        {

            try
            {
                uow.Airplane.Add(item);
                uow.Commit();
                //HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;

                Airplane airplane = uow.Airplane.FindByName(item.Name);

                return Ok(airplane);
            }
            catch (Exception)
            {
                HttpContext.Response.StatusCode = 400;
                return BadRequest(new { error = "Wrong data" });
            }

            
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Role.Admin)]
        public void Put([FromBody] Airplane item)
        {
            try
            {
                uow.Airplane.Update(item, item.AirplaneId);
                uow.Commit();
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;
            }
            catch (Exception)
            {
                HttpContext.Response.StatusCode = 400;
            }

            
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public void Delete(int id)
        {
            try
            {
                Airplane airplane = uow.Airplane.FindById(id);
                uow.Airplane.Remove(airplane);
                uow.Commit();
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;
            }
            catch (Exception)
            {
                HttpContext.Response.StatusCode = 400;
            }
        }

        [HttpGet("destinations/{id}")]
        public List<string> GetDestinations([FromRoute] int id)
        {
            return uow.Airplane.GetDestinations(id);
        }
    }
}
