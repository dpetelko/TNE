using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNEClient.Dtos;
using TNEClient.Dtos.SearchFilters;

namespace TNEClient.Data
{
    /// <summary>
    /// Performs operations on the BillingPoints 
    /// </summary>
    [Headers("Accept: application/json")]
    public interface IBillingPointRepository
    {
        /// <summary>
        /// Get all BillingPointsDto. 
        /// Returns list of BillingPoints or EMPTY List, if no BillingPoints are found
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/BillingPoints")]
        Task<List<BillingPointDto>> GetAllAsync();

        /// <summary>
        /// Returns a specific BillingPoint by ID
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/BillingPoints/{id}")]
        Task<BillingPointDto> GetAsync(Guid id);

        /// <summary>
        /// Returns list of BillingPoints by ControlPoint ID or EMPTY List, if no BillingPoints are found
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/BillingPoints/ControlPoint/{id}")]
        Task<List<BillingPointDto>> GetByControlPointAsync(Guid id);

        /// <summary>
        /// Returns list of BillingPoints by DeliveryPoint ID or EMPTY List, if no BillingPoints are found
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/BillingPoints/DeliveryPoint/{id}")]
        Task<List<BillingPointDto>> GetByDeliveryPointAsync(Guid id);

        /// <summary>
        /// Returns list list of BillingPoints by BillingPointFilter or EMPTY List, if no BillingPoints are found
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/BillingPoints/filter")]
        Task<List<BillingPointDto>> GetByFilterAsync([Body] BillingPointFilter filter);

        /// <summary>
        /// Creates a BillingPoint. 
        /// Returns a newly created BillingPoint
        /// </summary>
        /// <exception cref="ValidationApiException">If BillingPoint validation fail on server-side</exception>
        /// <exception cref="ApiException">If Response HttpStatus not equal 201</exception>
        [Post("/api/v1/BillingPoints")]
        Task<BillingPointDto> CreateAsync([Body] BillingPointDto dto);

        /// <summary>
        /// Updates a BillingPoint. 
        /// Returns a updated BillingPoint
        /// </summary>
        /// <exception cref="ValidationApiException">If BillingPoint validation fail on server-side</exception>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Put("/api/v1/BillingPoints")]
        Task<BillingPointDto> UpdateAsync([Body] BillingPointDto dto);
    }
}
