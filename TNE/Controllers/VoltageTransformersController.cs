using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TNE.Dtos;
using TNE.Dtos.SearchFilters;
using TNE.Models;
using TNE.Services;

namespace TNE.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VoltageTransformersController : ControllerBase
    {
        private readonly IVoltageTransformerService _service;

        public VoltageTransformersController(IVoltageTransformerService service) => _service = service;

        /// <summary>
        /// Get all VoltageTransformers
        /// </summary>
        /// /// <returns>Returns list of VoltageTransformers or EMPTY List, if no VoltageTransformers are found</returns>
        /// <response code="200">Returns list of VoltageTransformers or EMPTY List, if no VoltageTransformers are found</response>
        [HttpGet]
        public async Task<List<VoltageTransformerDto>> GetAll() => await _service.GetAllDtoAsync();

        /// <summary>
        /// Get list of VoltageTransformers by Status
        /// </summary>
        /// <param name="status"></param>
        /// <returns>The requested VoltageTransformer</returns>
        /// <response code="200">Returns the requested VoltageTransformer</response>
        /// <response code="400">If no VoltageTransformers are found</response>
        [HttpGet("status/{status}")]
        public async Task<List<VoltageTransformerDto>> GetAllByStatus(Status status) => await _service.GetAllDtoByStatusAsync(status);

        /// <summary>
        /// Get list of VoltageTransformers by ControlPoint ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The requested VoltageTransformer</returns>
        /// <response code="200">Returns the requested VoltageTransformer</response>
        /// <response code="400">If no VoltageTransformers are found</response>
        [HttpGet("ControlPoint/{id}")]
        public async Task<VoltageTransformerDto> GetByControlPointId(Guid id) => await _service.GetDtoByControlPointId(id);

        /// <summary>
        /// Get specific VoltageTransformer by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The requested VoltageTransformer</returns>
        /// <response code="200">Returns the requested VoltageTransformer</response>
        /// <response code="404">If no VoltageTransformers are found</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<VoltageTransformerDto>> GetById(Guid id) => Ok(await _service.GetDtoByIdAsync(id));

        [HttpGet("checkCalibration")]
        public async Task<List<VoltageTransformerDto>> GetAllByFilter([FromBody] DeviceCalibrationControlDto filter) => await _service.GetAllDtoByFilterAsync(filter);

        /// <summary>
        /// Creates a VoltageTransformer
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>A newly created VoltageTransformer</returns>
        /// <response code="201">Returns the newly created VoltageTransformer</response>
        /// <response code="400">If the item is null or did not pass validation</response>
        [HttpPost]
        public async Task<ActionResult<VoltageTransformerDto>> Create([FromBody] VoltageTransformerDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
        }

        /// <summary>
        /// Updates a VoltageTransformer
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>A updated VoltageTransformer</returns>
        /// <response code="200">Returns the updated VoltageTransformer</response>
        /// <response code="400">If the item is null or did not pass validation</response>
        [HttpPut]
        public async Task<ActionResult<VoltageTransformerDto>> Update([FromBody] VoltageTransformerDto dto)
        {
            return ModelState.IsValid
                ? (ActionResult<VoltageTransformerDto>)Ok(await _service.UpdateAsync(dto))
                : BadRequest(ModelState);
        }

        /// <summary>
        /// Setting new Status for the VoltageTransformer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns>True, if setting is done</returns>
        /// <response code="200">If setting is done</response>
        /// <response code="404">If no VoltageTransformers are found</response>
        [HttpPut("{id}/{status}")]
        public async Task<ActionResult<bool>> SetStatus(Guid id, Status status)
        {
            return ModelState.IsValid
                ? (ActionResult<bool>)Ok(await _service.SetStatus(id, status))
                : BadRequest(ModelState);
        }
    }
}
