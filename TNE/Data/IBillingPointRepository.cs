using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Data.Exceptions;
using TNE.Dtos;
using TNE.Dtos.SearchFilters;
using TNE.Models;

namespace TNE.Data
{
    /// <summary>
    /// Performs operations on the BillingPoints 
    /// </summary>
    public interface IBillingPointRepository : IRepository<BillingPoint>
    {
        /// <summary>
        /// Returns a specific BillingPoint by ID
        /// </summary>
        /// <exception cref="EntityNotFoundException">If no BillingPoint are found</exception>
        Task<BillingPointDto> GetDtoByIdAsync(Guid id);
        
        /// <summary>
        /// Get all BillingPointsDto. 
        /// Returns list of BillingPoints or EMPTY List, if no BillingPoints are found
        /// </summary>
        Task<List<BillingPointDto>> GetAllDtoAsync();
        
        /// <summary>
        /// Returns list of BillingPoints by ControlPoint ID or EMPTY List, if no BillingPoints are found
        /// </summary>
        Task<List<BillingPointDto>> GetAllDtoByControlPointIdAsync(Guid id);
        
        /// <summary>
        /// Returns list of BillingPoints by DeliveryPoint ID or EMPTY List, if no BillingPoints are found
        /// </summary>
        Task<List<BillingPointDto>> GetAllDtoByDeliveryPointIdAsync(Guid id);
        
        /// <summary>
        /// Returns list list of BillingPoints by BillingPointFilter or EMPTY List, if no BillingPoints are found
        /// </summary>
        Task<List<BillingPointDto>> GetAllDtoByFilterAsync(BillingPointFilter filter);
    }
}
