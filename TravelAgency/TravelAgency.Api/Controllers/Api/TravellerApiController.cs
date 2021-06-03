using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Domain.Entities;
using TravelAgency.Domain.Interfaces;
using TravelAgency.Domain.Services;
using TravelAgency.Domain.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelAgency.Api.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravellerApiController : ControllerBase
    {
        private readonly IGenericService service;

        public TravellerApiController(TravellerService service)
        {
            this.service = service;
        }
        // GET: api/<TravellerApiController>
        [HttpGet]
        public async Task<IEnumerable<ListTravellerViewModel>> Get()
        {
            return await service.GetAllAsync<ListTravellerViewModel>();
        }

        // GET api/<TravellerApiController>/5
        [HttpGet("{id}")]
        public async Task<GetTravellerViewModel> Get(Guid id)
        {
            return await service.GetAsync<GetTravellerViewModel>(id);
        }

        // POST api/<TravellerApiController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Travellers travellers)
        {
            var result = await service.AddAsync(travellers);
            return Ok(result);
        }

        // PUT api/<TravellerApiController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Travellers travellers)
        {
            travellers.Id = id;
            var result = await service.UpdateAsync(travellers);
            return Ok(result);
        }

        // DELETE api/<TravellerApiController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await service.DeleteAsync(id);
            return Ok(result);
        }
    }
}
