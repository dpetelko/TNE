using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Dtos;
using TNE.Dtos.SearchFilters;
using TNE.Services;

namespace TNE.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ControlPointsController : ControllerBase
    {
        private readonly IControlPointService _service;
        public ControlPointsController(IControlPointService service) { _service = service; }

        [HttpGet]
        public async Task<List<ControlPointDto>> GetAll() { return await _service.GetAllDtoAsync(); }

        [HttpGet("active")]
        public async Task<List<ControlPointDto>> GetAllActive() { return await _service.GetAllActiveDtoAsync(); }

        [HttpGet("{id}")]
        public async Task<ActionResult<ControlPointDto>> GetById(Guid id) { return Ok(await _service.GetDtoByIdAsync(id)); }

        [HttpGet("filter")]
        public async Task<List<ControlPointDto>> GetByFilter([FromBody] InterTestingFilter filter) { return await _service.GetAllDtoByFilterAsync(filter); }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ControlPointDto>> DeleteById(Guid id) { return Ok(await _service.DeleteAsync(id)); }

        [HttpDelete("undelete/{id}")]
        public async Task<ActionResult<ControlPointDto>> UndeleteById(Guid id) { return Ok(await _service.UndeleteAsync(id)); }

        [HttpPost]
        public async Task<ActionResult<ControlPointDto>> Create([FromBody] ControlPointDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult<ControlPointDto>> Update([FromBody] ControlPointDto dto)
        {
            return ModelState.IsValid
                ? (ActionResult<ControlPointDto>)Ok(await _service.UpdateAsync(dto))
                : BadRequest(ModelState);
        }
    }
}
