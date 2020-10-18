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
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BillingPointsController : ControllerBase
    {
        private readonly IBillingPointService _service;

        public BillingPointsController(IBillingPointService service) {  _service = service; }

        /// <summary>
        /// Get all BillingPoints
        /// </summary>
        /// /// <returns>Returns list of BillingPoints or EMPTY List, if no BillingPoints are found</returns>
        /// <response code="200">Returns list of BillingPoints or EMPTY List, if no BillingPoints are found</response>
        [HttpGet]
        public async Task<List<BillingPointDto>> GetAll() { return await _service.GetAllDtoAsync(); }

        /// <summary>
        /// Get specific BillingPoint by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The requested BillingPoint</returns>
        /// <response code="200">Returns the requested BillingPoint</response>
        /// <response code="404">If no BillingPoints are found</response>         
        [HttpGet("{id}")]
        public async Task<ActionResult<BillingPointDto>> GetById(Guid id) { return Ok(await _service.GetDtoByIdAsync(id)); }

        /// <summary>
        /// Get list of BillingPoints by ControlPoint ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The requested BillingPoint</returns>
        /// <response code="200">Returns the requested BillingPoint</response>
        /// <response code="400">If no BillingPoints are found</response>          
        [HttpGet("ControlPoint/{id}")]
        public async Task<List<BillingPointDto>> GetByControlPointId(Guid id) { return await _service.GetAllDtoByControlPointIdAsync(id); }

        /// <summary>
        /// Get list of BillingPoints by DeliveryPoint ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The requested BillingPoint</returns>
        /// <response code="200">Returns the requested BillingPoint</response>
        /// <response code="404">If no BillingPoints are found</response>     
        [HttpGet("DeliveryPoint/{id}")]
        public async Task<List<BillingPointDto>> GetByDeliveryPointId(Guid id) { return await _service.GetAllDtoByDeliveryPointIdAsync(id); }

        /// <summary>
        /// Get list of BillingPoints by BillingPointFilter 
        /// </summary>
        /// <returns>The requested BillingPoint</returns>
        /// <response code="200">Returns the requested BillingPoint</response>
        /// <response code="404">If no BillingPoints are found</response>      
        [HttpGet("filter")]
        public async Task<List<BillingPointDto>> GetByFilterId([FromBody] BillingPointFilter filter) { return await _service.GetAllDtoByFilterAsync(filter); }

        /// <summary>
        /// Creates a BillingPoint
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>A newly created BillingPoint</returns>
        /// <response code="201">Returns the newly created BillingPoint</response>
        /// <response code="400">If the item is null or did not pass validation</response>            
        [HttpPost]
        public async Task<ActionResult<BillingPointDto>> Create([FromBody] BillingPointDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
        }
        
        /// <summary>
        /// Updates a BillingPoint
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>A updated BillingPoint</returns>
        /// <response code="200">Returns the updated BillingPoint</response>
        /// <response code="400">If the item is null or did not pass validation</response>         
        [HttpPut]
        public async Task<ActionResult<BillingPointDto>> Update([FromBody] BillingPointDto dto)
        {
            return ModelState.IsValid
                ? (ActionResult<BillingPointDto>)Ok(await _service.UpdateAsync(dto))
                : BadRequest(ModelState);
        }
    }
}
