using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TNE.Dto;
using TNE.Services;

namespace TNE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubDivisionController : ControllerBase
    {
        private readonly ISubDivisionService _service;

        public SubDivisionController(ISubDivisionService service) {  _service = service; }

        [HttpGet]
        public async Task<List<SubDivisionDto>> GetAll() { return await _service.GetAllDtoAsync(); }

        [HttpGet("active")]
        public async Task<List<SubDivisionDto>> GetAllActive() { return await _service.GetAllActiveDtoAsync(); }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubDivisionDto>> GetById(Guid id) { return Ok(await _service.GetDtoByIdAsync(id)); }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SubDivisionDto>> DeleteById(Guid id) { return Ok(await _service.DeleteAsync(id)); }

        [HttpDelete("undelete/{id}")]
        public async Task<ActionResult<SubDivisionDto>> UndeleteById(Guid id) { return Ok(await _service.UndeleteAsync(id)); }

        [HttpPost]
        public async Task<ActionResult<SubDivisionDto>> Create([FromBody] SubDivisionDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult<SubDivisionDto>> Update([FromBody] SubDivisionDto dto)
        {
            return ModelState.IsValid
                ? (ActionResult<SubDivisionDto>)Ok(await _service.UpdateAsync(dto))
                : BadRequest(ModelState);
        }
    }
}
