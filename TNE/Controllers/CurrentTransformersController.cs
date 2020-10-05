using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TNE.Dtos;
using TNE.Models;
using TNE.Services;

namespace TNE.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CurrentTransformersController : ControllerBase
    {
        private readonly ICurrentTransformerService _service;

        public CurrentTransformersController(ICurrentTransformerService service) { _service = service; }

        [HttpGet]
        public async Task<List<CurrentTransformerDto>> GetAll() { return await _service.GetAllDtoAsync(); }

        [HttpGet("status/{status}")]
        public async Task<List<CurrentTransformerDto>> GetAllByStatus(Status status) { return await _service.GetAllDtoByStatusAsync(status); }

        [HttpGet("{id}")]
        public async Task<ActionResult<CurrentTransformerDto>> GetById(Guid id) { return Ok(await _service.GetDtoByIdAsync(id)); }

        [HttpPost]
        public async Task<ActionResult<CurrentTransformerDto>> Create([FromBody] CurrentTransformerDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult<CurrentTransformerDto>> Update([FromBody] CurrentTransformerDto dto)
        {
            return ModelState.IsValid
                ? (ActionResult<CurrentTransformerDto>)Ok(await _service.UpdateAsync(dto))
                : BadRequest(ModelState);
        }

        [HttpPut("{id}/{status}")]
        public async Task<ActionResult<bool>> SetStatus(Guid id, Status status)
        {
            return ModelState.IsValid
                ? (ActionResult<bool>)Ok(await _service.SetStatus(id, status))
                : BadRequest(ModelState);
        }
    }
}
