using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Dto;
using TNE.Services;

namespace TNE.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProvidersController : ControllerBase
    {
        private readonly IProviderService _service;

        public ProvidersController(IProviderService service) => _service = service; 

        /// <summary>
        /// Get all Providers
        /// </summary>
        /// /// <returns>Returns list of Providers or EMPTY List, if no Providers are found</returns>
        /// <response code="200">Returns list of Providers or EMPTY List, if no Providers are found</response>
        [HttpGet]
        public async Task<List<ProviderDto>> GetAll() => await _service.GetAllDtoAsync();

        /// <summary>
        /// Get all active Providers
        /// </summary>
        /// /// <returns>Returns list of active Providers or EMPTY List, if no Providers are found</returns>
        /// <response code="200">Returns list of Providers or EMPTY List, if no Providers are found</response>
        [HttpGet("active")]
        public async Task<List<ProviderDto>> GetAllActive() => await _service.GetAllActiveDtoAsync();

        /// <summary>
        /// Get specific Provider by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The requested Provider</returns>
        /// <response code="200">Returns the requested Provider</response>
        /// <response code="404">If no Providers are found</response>        
        [HttpGet("{id}")]
        public async Task<ActionResult<ProviderDto>> GetById(Guid id) => Ok(await _service.GetDtoByIdAsync(id));

        /// <summary>
        /// Get list of Providers by SubDivision ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The requested Provider</returns>
        /// <response code="200">Returns the requested Provider</response>
        /// <response code="400">If no Providers are found</response>        
        [HttpGet("bySubDivision/{id}")]
        public async Task<List<ProviderDto>> GetAllBySubDivisionId(Guid id) => await _service.GetAllDtoBySubDivisionIdAsync(id);

        /// <summary>
        /// Deletes specific Provider by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True, if deleting is done</returns>
        /// <response code="200">If deleting is done</response>
        /// <response code="404">If no Providers are found</response>         
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProviderDto>> DeleteById(Guid id) => Ok(await _service.DeleteAsync(id));

        /// <summary>
        /// Restores specific Provider by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True, if restoring is done</returns>
        /// <response code="200">If restoring is done</response>
        /// <response code="404">If no Providers are found</response>         
        [HttpDelete("undelete/{id}")]
        public async Task<ActionResult<ProviderDto>> UndeleteById(Guid id) => Ok(await _service.UndeleteAsync(id));

        /// <summary>
        /// Creates a Provider
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>A newly created Provider</returns>
        /// <response code="201">Returns the newly created Provider</response>
        /// <response code="400">If the item is null or did not pass validation</response> 
        [HttpPost]
        public async Task<ActionResult<ProviderDto>> Create([FromBody] ProviderDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
        }

        /// <summary>
        /// Updates a Provider
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>A updated Provider</returns>
        /// <response code="200">Returns the updated Provider</response>
        /// <response code="400">If the item is null or did not pass validation</response>         
        [HttpPut]
        public async Task<ActionResult<ProviderDto>> Update([FromBody] ProviderDto dto)
        {
            return ModelState.IsValid
                ? (ActionResult<ProviderDto>)Ok(await _service.UpdateAsync(dto))
                : BadRequest(ModelState);
        }
    }
}
