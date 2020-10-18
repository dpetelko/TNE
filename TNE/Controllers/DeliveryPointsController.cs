using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TNE.Dtos;
using TNE.Services;

namespace TNE.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DeliveryPointsController : ControllerBase
    {
        private readonly IDeliveryPointService _service;
        public DeliveryPointsController(IDeliveryPointService service) => _service = service; 

        /// <summary>
        /// Get all DeliveryPoints
        /// </summary>
        /// /// <returns>Returns list of DeliveryPoints or EMPTY List, if no DeliveryPoints are found</returns>
        /// <response code="200">Returns list of DeliveryPoints or EMPTY List, if no DeliveryPoints are found</response>
        [HttpGet]
        public async Task<List<DeliveryPointDto>> GetAll() => await _service.GetAllDtoAsync();

        /// <summary>
        /// Get all active DeliveryPoints
        /// </summary>
        /// /// <returns>Returns list of active DeliveryPoints or EMPTY List, if no DeliveryPoints are found</returns>
        /// <response code="200">Returns list of DeliveryPoints or EMPTY List, if no DeliveryPoints are found</response>
        [HttpGet("active")]
        public async Task<List<DeliveryPointDto>> GetAllActive() => await _service.GetAllActiveDtoAsync();

        /// <summary>
        /// Get specific DeliveryPoint by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The requested DeliveryPoint</returns>
        /// <response code="200">Returns the requested DeliveryPoint</response>
        /// <response code="404">If no DeliveryPoints are found</response>         
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryPointDto>> GetById(Guid id) => Ok(await _service.GetDtoByIdAsync(id));

        /// <summary>
        /// Get list of DeliveryPoints by SubDivision ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The requested DeliveryPoint</returns>
        /// <response code="200">Returns the requested DeliveryPoint</response>
        /// <response code="400">If no DeliveryPoints are found</response>  
        [HttpGet("byProvider/{id}")]
        public async Task<List<DeliveryPointDto>> GetAllBySubDivisionId(Guid id) => await _service.GetAllDtoByProviderIdAsync(id);

        /// <summary>
        /// Deletes specific DeliveryPoint by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True, if deleting is done</returns>
        /// <response code="200">If deleting is done</response>
        /// <response code="404">If no DeliveryPoints are found</response>     
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeliveryPointDto>> DeleteById(Guid id) => Ok(await _service.DeleteAsync(id));

        /// <summary>
        /// Restores specific DeliveryPoint by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True, if restoring is done</returns>
        /// <response code="200">If restoring is done</response>
        /// <response code="404">If no DeliveryPoints are found</response>       
        [HttpDelete("undelete/{id}")]
        public async Task<ActionResult<DeliveryPointDto>> UndeleteById(Guid id) => Ok(await _service.UndeleteAsync(id));

        /// <summary>
        /// Creates a DeliveryPoint
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>A newly created DeliveryPoint</returns>
        /// <response code="201">Returns the newly created DeliveryPoint</response>
        /// <response code="400">If the item is null or did not pass validation</response>            
        [HttpPost]
        public async Task<ActionResult<DeliveryPointDto>> Create([FromBody] DeliveryPointDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
        }

        /// <summary>
        /// Updates a DeliveryPoint
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>A updated DeliveryPoint</returns>
        /// <response code="200">Returns the updated DeliveryPoint</response>
        /// <response code="400">If the item is null or did not pass validation</response>         
        [HttpPut]
        public async Task<ActionResult<DeliveryPointDto>> Update([FromBody] DeliveryPointDto dto)
        {
            return ModelState.IsValid
                ? (ActionResult<DeliveryPointDto>)Ok(await _service.UpdateAsync(dto))
                : BadRequest(ModelState);
        }
    }
}
