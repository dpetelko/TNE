using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TNE.Dtos;
using TNE.Services;

namespace TNE.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DeliveryPointController : ControllerBase
    {
        private readonly IDeliveryPointService _service;
        public DeliveryPointController(IDeliveryPointService service) { _service = service; }

        [HttpGet]
        public async Task<List<DeliveryPointDto>> GetAll() { return await _service.GetAllDtoAsync(); }

        [HttpGet("active")]
        public async Task<List<DeliveryPointDto>> GetAllActive() { return await _service.GetAllActiveDtoAsync(); }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryPointDto>> GetById(Guid id) { return Ok(await _service.GetDtoByIdAsync(id)); }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeliveryPointDto>> DeleteById(Guid id) { return Ok(await _service.DeleteAsync(id)); }

        [HttpDelete("undelete/{id}")]
        public async Task<ActionResult<DeliveryPointDto>> UndeleteById(Guid id) { return Ok(await _service.UndeleteAsync(id)); }

        [HttpPost]
        public async Task<ActionResult<DeliveryPointDto>> Create([FromBody] DeliveryPointDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult<DeliveryPointDto>> Update([FromBody] DeliveryPointDto dto)
        {
            return ModelState.IsValid
                ? (ActionResult<DeliveryPointDto>)Ok(await _service.UpdateAsync(dto))
                : BadRequest(ModelState);
        }
    }
}
