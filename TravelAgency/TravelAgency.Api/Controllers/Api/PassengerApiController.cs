namespace TravelAgency.Api.Controllers.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using TravelAgency.Domain.Entities;
    using TravelAgency.Domain.Interfaces;
    using TravelAgency.Domain.Services;


    [Route("api/[controller]")]
    public class PassengerApiController : Controller
    {
        private readonly IGenericService service;

        public PassengerApiController(PassengerService service)
        {
            this.service = service;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<Passenger>> Get()
        {
            return await service.GetAllAsync<Passenger>();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Passenger> Get(Guid id)
        {
            return await service.GetAsync<Passenger>(id);
        }

        [HttpGet("GetPassengerIdentityCard/{IdentityCard}")]
        public async Task<Passenger> GetPassengerIdentityCard(double IdentityCard)
        {
            return await ((PassengerService)service).GetPassengerIdentityCard<Passenger>(IdentityCard);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Passenger passenger)
        {
           var result = await service.AddAsync(passenger);
            return Ok(result);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Passenger passenger)
        {
            passenger.Id = id;
            var result = await service.UpdateAsync(passenger);
            return Ok(result);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await service.DeleteAsync(id);
            return Ok(result);
        }
    }
}
