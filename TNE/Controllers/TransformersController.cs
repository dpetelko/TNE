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
    public class TransformersController : ControllerBase
    {
        private readonly ITransformerService _service;

        public TransformersController(ITransformerService service) { _service = service; }

        [HttpGet]
        public async Task<List<TransformerDto>> GetAll() { return await _service.GetAllDtoAsync(); }

        [HttpGet("status/{status}")]
        public async Task<List<TransformerDto>> GetAllByStatus(Status status) { return await _service.GetAllDtoByStatusAsync(status); }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransformerDto>> GetById(Guid id) { return Ok(await _service.GetDtoByIdAsync(id)); }

        [HttpPost]
        public async Task<ActionResult<TransformerDto>> Create([FromBody] TransformerDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult<TransformerDto>> Update([FromBody] TransformerDto dto)
        {
            return ModelState.IsValid
                ? (ActionResult<TransformerDto>)Ok(await _service.UpdateAsync(dto))
                : BadRequest(ModelState);
        }
    }
}
