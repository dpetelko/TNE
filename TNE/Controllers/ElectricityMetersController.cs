using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Dtos;
using TNE.Models;
using TNE.Services;

namespace TNE.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ElectricityMetersController : ControllerBase
    {
        private readonly IElectricityMeterService _service;

        public ElectricityMetersController(IElectricityMeterService service) { _service = service; }

        [HttpGet]
        public async Task<List<ElectricityMeterDto>> GetAll() { return await _service.GetAllDtoAsync(); }

        [HttpGet("status/{status}")]
        public async Task<List<ElectricityMeterDto>> GetAllByStatus(Status status) { return await _service.GetAllDtoByStatusAsync(status); }

        [HttpGet("{id}")]
        public async Task<ActionResult<ElectricityMeterDto>> GetById(Guid id) { return Ok(await _service.GetDtoByIdAsync(id)); }

        [HttpPost]
        public async Task<ActionResult<ElectricityMeterDto>> Create([FromBody] ElectricityMeterDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult<ElectricityMeterDto>> Update([FromBody] ElectricityMeterDto dto)
        {
            return ModelState.IsValid
                ? (ActionResult<ElectricityMeterDto>)Ok(await _service.UpdateAsync(dto))
                : BadRequest(ModelState);
        }
    }
}
