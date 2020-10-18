﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Dtos;
using TNE.Dtos.SearchFilters;
using TNE.Models;
using TNE.Services;

namespace TNE.Controllers
{
    [Produces("application/json")]
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

        [HttpGet("ControlPoint/{id}")]
        public async Task<ElectricityMeterDto> GetByControlPointId(Guid id) { return await _service.GetDtoByControlPointId(id); }

        [HttpGet("{id}")]
        public async Task<ActionResult<ElectricityMeterDto>> GetById(Guid id) { return Ok(await _service.GetDtoByIdAsync(id)); }
        
        [HttpGet("checkCalibration")]
        public async Task<List<ElectricityMeterDto>> GetAllByFilter([FromBody] DeviceCalibrationControlDto filter) => await _service.GetAllDtoByFilterAsync(filter);

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

        [HttpPut("{id}/{status}")]
        public async Task<ActionResult<bool>> SetStatus(Guid id, Status status)
        {
            return ModelState.IsValid
                ? (ActionResult<bool>)Ok(await _service.SetStatus(id, status))
                : BadRequest(ModelState);
        }
    }
}
