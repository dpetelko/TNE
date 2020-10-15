using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TNE.Dto;
using TNE.Dtos;
using TNE.Dtos.SearchFilters;
using TNE.Services;

namespace TNE.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BillingPointsController : ControllerBase
    {
        private readonly IBillingPointService _service;

        public BillingPointsController(IBillingPointService service) {  _service = service; }

        [HttpGet]
        public async Task<List<BillingPointDto>> GetAll() { return await _service.GetAllDtoAsync(); }

        [HttpGet("{id}")]
        public async Task<ActionResult<BillingPointDto>> GetById(Guid id) { return Ok(await _service.GetDtoByIdAsync(id)); }

        [HttpGet("ControlPoint/{id}")]
        public async Task<List<BillingPointDto>> GetByControlPointId(Guid id) { return await _service.GetAllDtoByControlPointIdAsync(id); }

        [HttpGet("DeliveryPoint/{id}")]
        public async Task<List<BillingPointDto>> GetByDeliveryPointId(Guid id) { return await _service.GetAllDtoByDeliveryPointIdAsync(id); }

        [HttpGet("filter")]
        public async Task<List<BillingPointDto>> GetByFilterId([FromBody] BillingPointFilter filter) { return await _service.GetAllDtoByFilterAsync(filter); }

        [HttpPost]
        public async Task<ActionResult<BillingPointDto>> Create([FromBody] BillingPointDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult<BillingPointDto>> Update([FromBody] BillingPointDto dto)
        {
            return ModelState.IsValid
                ? (ActionResult<BillingPointDto>)Ok(await _service.UpdateAsync(dto))
                : BadRequest(ModelState);
        }
    }
}
