namespace TravelAgency.Api.Controllers.Api
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TravelAgency.Domain.Entities;
    using TravelAgency.Domain.Interfaces;
    using TravelAgency.Domain.Services;

    [Route("api/[controller]")]
    public class TravelApiController : Controller
    {
        private IGenericService service;
        public TravelApiController(TravelService service)
        {
            this.service = service;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<Travel>> Get()
        {
            return await service.GetAllAsync<Travel>();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Travel> Get(Guid id)
        {
            return await service.GetAsync<Travel>(id);
        }

        [HttpGet("GetTravelCode/{TravelCode}")]
        public async Task<Travel> GetTravelCode(string TravelCode)
        {
            return await ((TravelService)service).GetTravelCode<Travel>(TravelCode);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Travel travel)
        {
            var result = await service.AddAsync(travel);
            return Ok(result);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Travel travel)
        {
            travel.Id = id;
            var result = await service.UpdateAsync(travel);
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
