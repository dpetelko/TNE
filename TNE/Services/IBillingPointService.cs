using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Dtos;
using TNE.Dtos.SearchFilters;
using TNE.Models;

namespace TNE.Services
{
    /// <summary>
    /// Performs operations on the BillingPoints 
    /// </summary>
    public interface IBillingPointService : IService<BillingPoint>
    {
        /// <summary>
        /// Returns a specific BillingPoint by ID 
        /// </summary>
        Task<BillingPointDto> GetDtoByIdAsync(Guid id);

        /// <summary>
        /// Get all BillingPointsDto. 
        /// Returns list of BillingPoints or EMPTY List, if no BillingPoints are found
        /// </summary>
        Task<List<BillingPointDto>> GetAllDtoAsync();

        /// <summary>
        /// Creates a BillingPoint. 
        /// Returns a newly created BillingPoint
        /// </summary>
        Task<BillingPointDto> CreateAsync(BillingPointDto dto);

        /// <summary>
        /// Updates a BillingPoint. Returns a updated BillingPoint
        /// </summary>
        Task<BillingPointDto> UpdateAsync(BillingPointDto dto);

        /// <summary>
        /// Returns list of BillingPoints by ControlPoint ID 
        /// </summary>
        Task<List<BillingPointDto>> GetAllDtoByControlPointIdAsync(Guid id);

        /// <summary>
        /// Returns list of BillingPoints by DeliveryPoint ID 
        /// </summary>
        Task<List<BillingPointDto>> GetAllDtoByDeliveryPointIdAsync(Guid id);

        /// <summary>
        /// Returns list list of BillingPoints by BillingPointFilter 
        /// </summary>
        Task<List<BillingPointDto>> GetAllDtoByFilterAsync(BillingPointFilter filter);
    }
}