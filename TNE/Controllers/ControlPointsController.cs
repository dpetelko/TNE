using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Dtos;
using TNE.Services;

namespace TNE.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ControlPointsController : ControllerBase
    {
        private readonly IControlPointService _service;
        public ControlPointsController(IControlPointService service) => _service = service;

        /// <summary>
        /// Get all ControlPoints
        /// </summary>
        /// /// <returns>Returns list of ControlPoints or EMPTY List, if no ControlPoints are found</returns>
        /// <response code="200">Returns list of ControlPoints or EMPTY List, if no ControlPoints are found</response>
        [HttpGet]
        public async Task<List<ControlPointDto>> GetAll() => await _service.GetAllDtoAsync();

        /// <summary>
        /// Get all active ControlPoints
        /// </summary>
        /// /// <returns>Returns list of active ControlPoints or EMPTY List, if no ControlPoints are found</returns>
        /// <response code="200">Returns list of ControlPoints or EMPTY List, if no ControlPoints are found</response>
        [HttpGet("active")]
        public async Task<List<ControlPointDto>> GetAllActive() => await _service.GetAllActiveDtoAsync();

        /// <summary>
        /// Get specific ControlPoint by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The requested ControlPoint</returns>
        /// <response code="200">Returns the requested ControlPoint</response>
        /// <response code="404">If no ControlPoints are found</response>         
        [HttpGet("{id}")]
        public async Task<ActionResult<ControlPointDto>> GetById(Guid id) => Ok(await _service.GetDtoByIdAsync(id));

        /// <summary>
        /// Get list of ControlPoints by Provider ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The requested ControlPoint</returns>
        /// <response code="200">Returns the requested ControlPoint</response>
        /// <response code="400">If no ControlPoints are found</response>          
        [HttpGet("byProvider/{id}")]
        public async Task<List<ControlPointDto>> GetAllByProviderId(Guid id) => await _service.GetAllDtoByProviderIdAsync(id);

        /// <summary>
        /// Deletes specific ControlPoint by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True, if deleting is done</returns>
        /// <response code="200">If deleting is done</response>
        /// <response code="404">If no ControlPoints are found</response>         
        [HttpDelete("{id}")]
        public async Task<ActionResult<ControlPointDto>> DeleteById(Guid id) => Ok(await _service.DeleteAsync(id));

        /// <summary>
        /// Restores specific ControlPoint by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True, if restoring is done</returns>
        /// <response code="200">If restoring is done</response>
        /// <response code="404">If no ControlPoints are found</response>         
        [HttpDelete("undelete/{id}")]
        public async Task<ActionResult<ControlPointDto>> UndeleteById(Guid id) => Ok(await _service.UndeleteAsync(id));

        /// <summary>
        /// Creates a ControlPoint
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>A newly created ControlPoint</returns>
        /// <response code="201">Returns the newly created ControlPoint</response>
        /// <response code="400">If the item is null or did not pass validation</response>            
        [HttpPost]
        public async Task<ActionResult<ControlPointDto>> Create([FromBody] ControlPointDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
        }

        /// <summary>
        /// Updates a ControlPoint
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>A updated ControlPoint</returns>
        /// <response code="200">Returns the updated ControlPoint</response>
        /// <response code="400">If the item is null or did not pass validation</response>         
        [HttpPut]
        public async Task<ActionResult<ControlPointDto>> Update([FromBody] ControlPointDto dto)
        {
            return ModelState.IsValid
                ? (ActionResult<ControlPointDto>)Ok(await _service.UpdateAsync(dto))
                : BadRequest(ModelState);
        }
    }
}
