using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Airport.Api.Models;
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

        //[HttpGet("getall")]
        [HttpGet]
        [Authorize]
        public async Task<List<Airplane>> Get()
        {
            return await uow.Airplane.GetAllAsync();
        }

        //[HttpGet("get/{id}")]
        [HttpGet("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult> Get(int id)
        {
            Airplane airplane = await uow.Airplane.FindByIdAsync(id);
            if (airplane != null)
            {
                return Ok(airplane);
            }
            return NotFound();
        }


        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult> Post([FromBody] Airplane item)
        {
            try
            {
                

                await uow.Airplane.AddAsync(item);
                await uow.CommitAsync();

                Airplane airplane = await uow.Airplane.FindByNameAsync(item.Name);

                return Ok(airplane);


            }
            catch (Exception)
            { 
                return BadRequest(new { error = "Wrong data" });
            }

        }

        [HttpPut("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult> Put([FromBody] Airplane item)
        {
            try
            {
                await uow.Airplane.UpdateAsync(item, item.AirplaneId);
                await uow.CommitAsync();

                Airplane airplane = await uow.Airplane.FindByIdAsync(item.AirplaneId);

                return Ok(airplane);

            }
            catch (Exception)
            {
                return BadRequest(new { error = "Wrong data" });
            }

            
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult> Delete(int id)
        {

            try
            {
                Airplane airplane = await uow.Airplane.FindByIdAsync(id);
                uow.Airplane.Remove(airplane);
                await uow.CommitAsync();
                return Ok("Airplane has been removed");
            }
            catch (Exception)
            {
                return BadRequest($"Airplane with id : ${id} does not exist or there is seats or flights binded to airplane whith this id");
            }
        }

        [HttpGet("destinations/{id}")]
        public List<string> GetDestinations([FromRoute] int id)
        {
            return uow.Airplane.GetDestinations(id);
        }

        [HttpPost("page")]
        [Authorize]

        public async Task<IActionResult> GetRowsPerPage([FromBody] Pagintaion pagination)
        {
            List<Airplane> airplanes = new List<Airplane>();

            if(pagination.NumOfRows <= 0)
            {
                return BadRequest("Number of rows cant be less than 0");
            }
            if(pagination.PageNum <= 0)
            {
                return BadRequest("Page number cant be less than 0");
            }

            airplanes = await uow.Airplane.GetAirplanesPerPageAsync(pagination.PageNum, pagination.NumOfRows);

            return Ok(airplanes);


        }













    }
}
