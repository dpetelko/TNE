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
    public class CurrentTransformersController : ControllerBase
    {
        private readonly ICurrentTransformerService _service;

        public CurrentTransformersController(ICurrentTransformerService service) => _service = service;

        /// <summary>
        /// Get all CurrentTransformers
        /// </summary>
        /// /// <returns>Returns list of CurrentTransformers or EMPTY List, if no CurrentTransformers are found</returns>
        /// <response code="200">Returns list of CurrentTransformers or EMPTY List, if no CurrentTransformers are found</response>
        [HttpGet]
        public async Task<List<CurrentTransformerDto>> GetAll() => await _service.GetAllDtoAsync();

        /// <summary>
        /// Get list of CurrentTransformers by ControlPoint ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The requested CurrentTransformer</returns>
        /// <response code="200">Returns the requested CurrentTransformer</response>
        /// <response code="400">If no CurrentTransformers are found</response>       
        [HttpGet("CurrentTransformer/{id}")]
        public async Task<CurrentTransformerDto> GetByControlPointId(Guid id) => await _service.GetDtoByControlPointId(id);

        /// <summary>
        /// Get list of CurrentTransformers by Status
        /// </summary>
        /// <param name="status"></param>
        /// <returns>The requested CurrentTransformer</returns>
        /// <response code="200">Returns the requested CurrentTransformer</response>
        /// <response code="400">If no CurrentTransformers are found</response>       
        [HttpGet("status/{status}")]
        public async Task<List<CurrentTransformerDto>> GetAllByStatus(Status status) => await _service.GetAllDtoByStatusAsync(status);

        [HttpGet("checkCalibration")]
        public async Task<List<CurrentTransformerDto>> GetAllByFilter([FromBody] DeviceCalibrationControlDto filter) => await _service.GetAllDtoByFilterAsync(filter);

        /// <summary>
        /// Get specific CurrentTransformer by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The requested CurrentTransformer</returns>
        /// <response code="200">Returns the requested CurrentTransformer</response>
        /// <response code="404">If no CurrentTransformers are found</response>         
        [HttpGet("{id}")]
        public async Task<ActionResult<CurrentTransformerDto>> GetById(Guid id) => Ok(await _service.GetDtoByIdAsync(id));

        /// <summary>
        /// Creates a CurrentTransformer
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>A newly created CurrentTransformer</returns>
        /// <response code="201">Returns the newly created CurrentTransformer</response>
        /// <response code="400">If the item is null or did not pass validation</response>
        [HttpPost]
        public async Task<ActionResult<CurrentTransformerDto>> Create([FromBody] CurrentTransformerDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
        }

        /// <summary>
        /// Updates a CurrentTransformer
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>A updated CurrentTransformer</returns>
        /// <response code="200">Returns the updated CurrentTransformer</response>
        /// <response code="400">If the item is null or did not pass validation</response>
        [HttpPut]
        public async Task<ActionResult<CurrentTransformerDto>> Update([FromBody] CurrentTransformerDto dto)
        {
            return ModelState.IsValid
                ? (ActionResult<CurrentTransformerDto>)Ok(await _service.UpdateAsync(dto))
                : BadRequest(ModelState);
        }

        /// <summary>
        /// Setting new Status for the CurrentTransformer
        /// </summary>
        /// <param name="id"></param>
        /// /// <param name="status"></param>
        /// <returns>True, if setting is done</returns>
        /// <response code="200">If setting is done</response>
        /// <response code="404">If no CurrentTransformers are found</response>
        [HttpPut("{id}/{status}")]
        public async Task<ActionResult<bool>> SetStatus(Guid id, Status status)
        {
            return ModelState.IsValid
                ? (ActionResult<bool>)Ok(await _service.SetStatus(id, status))
                : BadRequest(ModelState);
        }
    }
}
