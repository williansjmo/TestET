using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Domain.Entities;
using TravelAgency.Domain.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelAgency.Api.Controllers.Api
{
    [Route("api/[controller]")]
    public class TravelApiController : Controller
    {
        private TravelService service;
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
