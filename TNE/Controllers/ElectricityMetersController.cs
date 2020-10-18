using Microsoft.AspNetCore.Mvc;
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

        public ElectricityMetersController(IElectricityMeterService service) => _service = service;

        /// <summary>
        /// Get all ElectricityMeters
        /// </summary>
        /// /// <returns>Returns list of ElectricityMeters or EMPTY List, if no ElectricityMeters are found</returns>
        /// <response code="200">Returns list of ElectricityMeters or EMPTY List, if no ElectricityMeters are found</response>
        [HttpGet]
        public async Task<List<ElectricityMeterDto>> GetAll() => await _service.GetAllDtoAsync();

        /// <summary>
        /// Get list of ElectricityMeters by Status
        /// </summary>
        /// <param name="status"></param>
        /// <returns>The requested ElectricityMeter</returns>
        /// <response code="200">Returns the requested ElectricityMeter</response>
        /// <response code="400">If no ElectricityMeters are found</response>
        [HttpGet("status/{status}")]
        public async Task<List<ElectricityMeterDto>> GetAllByStatus(Status status) => await _service.GetAllDtoByStatusAsync(status);

        /// <summary>
        /// Get list of ElectricityMeters by ControlPoint ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The requested ElectricityMeter</returns>
        /// <response code="200">Returns the requested ElectricityMeter</response>
        /// <response code="400">If no ElectricityMeters are found</response>
        [HttpGet("ControlPoint/{id}")]
        public async Task<ElectricityMeterDto> GetByControlPointId(Guid id) => await _service.GetDtoByControlPointId(id);

        /// <summary>
        /// Get specific ElectricityMeter by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The requested ElectricityMeter</returns>
        /// <response code="200">Returns the requested ElectricityMeter</response>
        /// <response code="404">If no ElectricityMeters are found</response> 
        [HttpGet("{id}")]
        public async Task<ActionResult<ElectricityMeterDto>> GetById(Guid id) => Ok(await _service.GetDtoByIdAsync(id));

        [HttpGet("checkCalibration")]
        public async Task<List<ElectricityMeterDto>> GetAllByFilter([FromBody] DeviceCalibrationControlDto filter) => await _service.GetAllDtoByFilterAsync(filter);

        /// <summary>
        /// Creates a ElectricityMeter
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>A newly created ElectricityMeter</returns>
        /// <response code="201">Returns the newly created ElectricityMeter</response>
        /// <response code="400">If the item is null or did not pass validation</response>
        [HttpPost]
        public async Task<ActionResult<ElectricityMeterDto>> Create([FromBody] ElectricityMeterDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
        }

        /// <summary>
        /// Updates a ElectricityMeter
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>A updated ElectricityMeter</returns>
        /// <response code="200">Returns the updated ElectricityMeter</response>
        /// <response code="400">If the item is null or did not pass validation</response>
        [HttpPut]
        public async Task<ActionResult<ElectricityMeterDto>> Update([FromBody] ElectricityMeterDto dto)
        {
            return ModelState.IsValid
                ? (ActionResult<ElectricityMeterDto>)Ok(await _service.UpdateAsync(dto))
                : BadRequest(ModelState);
        }

        /// <summary>
        /// Setting new Status for the ElectricityMeter
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns>True, if setting is done</returns>
        /// <response code="200">If setting is done</response>
        /// <response code="404">If no ElectricityMeters are found</response>
        [HttpPut("{id}/{status}")]
        public async Task<ActionResult<bool>> SetStatus(Guid id, Status status)
        {
            return ModelState.IsValid
                ? (ActionResult<bool>)Ok(await _service.SetStatus(id, status))
                : BadRequest(ModelState);
        }
    }
}
