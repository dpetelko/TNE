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
    public class VoltageTransformersController : ControllerBase
    {
        private readonly IVoltageTransformerService _service;

        public VoltageTransformersController(IVoltageTransformerService service) { _service = service; }

        [HttpGet]
        public async Task<List<VoltageTransformerDto>> GetAll() { return await _service.GetAllDtoAsync(); }

        [HttpGet("status/{status}")]
        public async Task<List<VoltageTransformerDto>> GetAllByStatus(Status status) { return await _service.GetAllDtoByStatusAsync(status); }

        [HttpGet("{id}")]
        public async Task<ActionResult<VoltageTransformerDto>> GetById(Guid id) { return Ok(await _service.GetDtoByIdAsync(id)); }

        [HttpPost]
        public async Task<ActionResult<VoltageTransformerDto>> Create([FromBody] VoltageTransformerDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
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
