using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Dto;
using TNE.Services;

namespace TNE.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProvidersController : ControllerBase
    {
        private readonly IProviderService _service;

        public ProvidersController(IProviderService service) { _service = service; }

        [HttpGet]
        public async Task<List<ProviderDto>> GetAll() { return await _service.GetAllDtoAsync(); }

        [HttpGet("active")]
        public async Task<List<ProviderDto>> GetAllActive() { return await _service.GetAllActiveDtoAsync(); }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProviderDto>> GetById(Guid id) { return Ok(await _service.GetDtoByIdAsync(id)); }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProviderDto>> DeleteById(Guid id) { return Ok(await _service.DeleteAsync(id)); }

        [HttpDelete("undelete/{id}")]
        public async Task<ActionResult<ProviderDto>> UndeleteById(Guid id) { return Ok(await _service.UndeleteAsync(id)); }

        [HttpPost]
        public async Task<ActionResult<ProviderDto>> Create([FromBody] ProviderDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult<ProviderDto>> Update([FromBody] ProviderDto dto)
        {
            return ModelState.IsValid
                ? (ActionResult<ProviderDto>)Ok(await _service.UpdateAsync(dto))
                : BadRequest(ModelState);
        }
    }
}
