using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Dto.LeadDivisions;
using TNE.Services;

namespace TNE.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LeadDivisionsController : ControllerBase
    {
        private readonly ILeadDivisionService _service;
        public LeadDivisionsController(ILeadDivisionService service) => _service = service;

        /// <summary>
        /// Get all LeadDivisions
        /// </summary>
        /// /// <returns>Returns list of LeadDivisions or EMPTY List, if no LeadDivisions are found</returns>
        /// <response code="200">Returns list of LeadDivisions or EMPTY List, if no LeadDivisions are found</response>
        //[Produces("application/json", Type = typeof(List<LeadDivisionDto>))]
        [HttpGet]
        public async Task<List<LeadDivisionDto>> GetAll() => await _service.GetAllDtoAsync();

        /// <summary>
        /// Get all active LeadDivisions
        /// </summary>
        /// /// <returns>Returns list of active LeadDivisions or EMPTY List, if no LeadDivisions are found</returns>
        /// <response code="200">Returns list of LeadDivisions or EMPTY List, if no LeadDivisions are found</response>
        [HttpGet("active")]
        public async Task<List<LeadDivisionDto>> GetAllActive() => await _service.GetAllActiveDtoAsync();

        /// <summary>
        /// Get specific LeadDivision by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The requested LeadDivision</returns>
        /// <response code="200">Returns the requested LeadDivision</response>
        /// <response code="404">If no LeadDivisions are found</response>         
        [HttpGet("{id}")]
        public async Task<ActionResult<LeadDivisionDto>> GetById(Guid id) => Ok(await _service.GetDtoByIdAsync(id));

        /// <summary>
        /// Deletes specific LeadDivision by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True, if deleting is done</returns>
        /// <response code="200">If deleting is done</response>
        /// <response code="404">If no LeadDivisions are found</response>       
        [HttpDelete("{id}")]
        public async Task<ActionResult<LeadDivisionDto>> DeleteById(Guid id) => Ok(await _service.DeleteAsync(id));

        /// <summary>
        /// Restores specific LeadDivision by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True, if restoring is done</returns>
        /// <response code="200">If restoring is done</response>
        /// <response code="404">If no LeadDivisions are found</response>         
        [HttpDelete("undelete/{id}")]
        public async Task<ActionResult<LeadDivisionDto>> UndeleteById(Guid id) => Ok(await _service.UndeleteAsync(id));

        /// <summary>
        /// Creates a LeadDivision
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>A newly created LeadDivision</returns>
        /// <response code="201">Returns the newly created LeadDivision</response>
        /// <response code="400">If the item is null or did not pass validation</response>     
        
        [HttpPost]
        public async Task<ActionResult<LeadDivisionDto>> Create([FromBody] LeadDivisionDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
        }

        /// <summary>
        /// Updates a LeadDivision
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>A updated LeadDivision</returns>
        /// <response code="200">Returns the updated LeadDivision</response>
        /// <response code="400">If the item is null or did not pass validation</response>       
        [HttpPut]
        public async Task<ActionResult<LeadDivisionDto>> Update([FromBody] LeadDivisionDto dto)
        {
            return ModelState.IsValid
                ? (ActionResult<LeadDivisionDto>)Ok(await _service.UpdateAsync(dto))
                : BadRequest(ModelState);
        }
    }
}
