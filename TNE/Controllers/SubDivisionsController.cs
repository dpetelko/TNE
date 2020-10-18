using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TNE.Dto;
using TNE.Services;

namespace TNE.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SubDivisionsController : ControllerBase
    {
        private readonly ISubDivisionService _service;

        public SubDivisionsController(ISubDivisionService service) =>  _service = service;

        /// <summary>
        /// Get all SubDivisions
        /// </summary>
        /// /// <returns>Returns list of SubDivisions or EMPTY List, if no SubDivisions are found</returns>
        /// <response code="200">Returns list of SubDivisions or EMPTY List, if no SubDivisions are found</response>
        [HttpGet]
        public async Task<List<SubDivisionDto>> GetAll() => await _service.GetAllDtoAsync();

        /// <summary>
        /// Get all active SubDivisions
        /// </summary>
        /// /// <returns>Returns list of active SubDivisions or EMPTY List, if no SubDivisions are found</returns>
        /// <response code="200">Returns list of SubDivisions or EMPTY List, if no SubDivisions are found</response>
        [HttpGet("active")]
        public async Task<List<SubDivisionDto>> GetAllActive() => await _service.GetAllActiveDtoAsync();

        /// <summary>
        /// Get list of SubDivisions by LeadDivision ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The requested SubDivision</returns>
        /// <response code="200">Returns the requested SubDivision</response>
        /// <response code="400">If no SubDivisions are found</response>          
        [HttpGet("byLeadDivision/{id}")]
        public async Task<List<SubDivisionDto>> GetAllByLeadDivisionId(Guid id) => await _service.GetAllDtoByLeadDivisionIdAsync(id);

        /// <summary>
        /// Get specific SubDivision by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The requested SubDivision</returns>
        /// <response code="200">Returns the requested SubDivision</response>
        /// <response code="404">If no SubDivisions are found</response>         
        [HttpGet("{id}")]
        public async Task<ActionResult<SubDivisionDto>> GetById(Guid id) => Ok(await _service.GetDtoByIdAsync(id));

        /// <summary>
        /// Deletes specific SubDivision by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True, if deleting is done</returns>
        /// <response code="200">If deleting is done</response>
        /// <response code="404">If no SubDivisions are found</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult<SubDivisionDto>> DeleteById(Guid id) => Ok(await _service.DeleteAsync(id));

        /// <summary>
        /// Restores specific SubDivision by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True, if restoring is done</returns>
        /// <response code="200">If restoring is done</response>
        /// <response code="404">If no SubDivisions are found</response> 
        [HttpDelete("undelete/{id}")]
        public async Task<ActionResult<SubDivisionDto>> UndeleteById(Guid id) => Ok(await _service.UndeleteAsync(id));

        /// <summary>
        /// Creates a SubDivision
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>A newly created SubDivision</returns>
        /// <response code="201">Returns the newly created SubDivision</response>
        /// <response code="400">If the item is null or did not pass validation</response>
        [HttpPost]
        public async Task<ActionResult<SubDivisionDto>> Create([FromBody] SubDivisionDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
        }

        /// <summary>
        /// Updates a SubDivision
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>A updated SubDivision</returns>
        /// <response code="200">Returns the updated SubDivision</response>
        /// <response code="400">If the item is null or did not pass validation</response>
        [HttpPut]
        public async Task<ActionResult<SubDivisionDto>> Update([FromBody] SubDivisionDto dto)
        {
            return ModelState.IsValid
                ? (ActionResult<SubDivisionDto>)Ok(await _service.UpdateAsync(dto))
                : BadRequest(ModelState);
        }
    }
}
