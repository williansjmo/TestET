namespace TravelAgency.Api.Controllers.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using TravelAgency.Domain.Entities;
    using TravelAgency.Domain.Services;


    [Route("api/[controller]")]
    public class PassengerApiController : Controller
    {
        private readonly PassengerService service;

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

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] Passenger passenger)
        {
            await service.AddAsync(passenger);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(Guid id, [FromBody] Passenger passenger)
        {
            await service.UpdateAsync(passenger);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await service.DeleteAsync(id);
        }
    }
}
