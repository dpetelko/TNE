using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNEClient.Dtos;
using TNEClient.Dtos.SearchFilters;

namespace TNEClient.Services
{
    /// <summary>
    /// Performs operations on the BillingPoints 
    /// </summary>
    public interface IBillingPointService
    {

        Task<List<BillingPointDto>> GetAllAsync();

        /// <summary>
        /// Returns a specific BillingPoint by ID
        /// </summary>
        /// <exception cref="ApiException">If no BillingPoint are found</exception>
        Task<BillingPointDto> GetAsync(Guid id);

        /// <summary>
        /// Creates a BillingPoint. 
        /// Returns a newly created BillingPoint
        /// </summary>
        /// <exception cref="ApiException">If BillingPoint are invalid, e.g. ID is not Guid.Empty</exception>
        /// /// <exception cref="ValidationApiException">If BillingPoint validation fail on server-side</exception>
        Task<BillingPointDto> CreateAsync(BillingPointDto dto);

        /// <summary>
        /// Updates a BillingPoint. Returns a updated BillingPoint
        /// </summary>
        /// <exception cref="ApiException">If BillingPoint are invalid, e.g. ID is Guid.Empty or If BillingPoint are not found with this ID</exception>
        /// <exception cref="ValidationApiException">If BillingPoint validation fail on server-side</exception>
        Task<BillingPointDto> UpdateAsync(BillingPointDto dto);

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
