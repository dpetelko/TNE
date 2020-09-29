using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Dto.LeadDivisions;
using TNE.Services;

namespace TNE.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LeadDivisionsController : ControllerBase
    {
        private readonly ILeadDivisionService _service;
        public LeadDivisionsController(ILeadDivisionService service) => _service = service;

        [HttpGet]
        public async Task<List<LeadDivisionDto>> GetAll() { return await _service.GetAllDtoAsync(); }

        [HttpGet("active")] 
        public async Task<List<LeadDivisionDto>> GetAllActive() { return await _service.GetAllActiveDtoAsync(); }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeadDivisionDto>> GetById(Guid id) { return Ok(await _service.GetDtoByIdAsync(id)); }

        [HttpDelete("{id}")]
        public async Task<ActionResult<LeadDivisionDto>> DeleteById(Guid id) { return Ok(await _service.DeleteAsync(id)); }

        [HttpDelete("undelete/{id}")]
        public async Task<ActionResult<LeadDivisionDto>> UndeleteById(Guid id) { return Ok(await _service.UndeleteAsync(id)); }

        [HttpPost]
        public async Task<ActionResult<LeadDivisionDto>> Create([FromBody] LeadDivisionDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult<LeadDivisionDto>> Update([FromBody] LeadDivisionDto value)
        {
            return ModelState.IsValid
                ? (ActionResult<LeadDivisionDto>)Ok(await _service.UpdateAsync(value))
                : BadRequest(ModelState);
        }
    }
}
