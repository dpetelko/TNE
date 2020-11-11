using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNEClient.Dtos;

namespace TNEClient.Data
{
    /// <summary>
    /// Performs operations on the DeliveryPoints 
    /// </summary>
    [Headers("Accept: application/json")]
    public interface IDeliveryPointRepository
    {
        /// <summary>
        /// Get all DeliveryPointsDto. 
        /// Returns list of DeliveryPoints or EMPTY List, if no DeliveryPoints are found
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/DeliveryPoints")]
        Task<List<DeliveryPointDto>> GetAllAsync();

        /// <summary>
        /// Get all not deleted DeliveryPointsDto. 
        /// Returns list of DeliveryPoints or EMPTY List, if no DeliveryPoints are found
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/DeliveryPoints/active")]
        Task<List<DeliveryPointDto>> GetAllActiveAsync();

        /// <summary>
        /// Returns a specific DeliveryPoint by ID
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/DeliveryPoints/{id}")]
        Task<DeliveryPointDto> GetAsync(Guid id);

        /// <summary>
        /// Returns list of DeliveryPoints by Provider ID or EMPTY List, if no DeliveryPoints are found
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/DeliveryPoints/byProvider/{id}")]
        Task<List<DeliveryPointDto>> GetByProviderAsync(Guid id);

        /// <summary>
        /// Creates a DeliveryPoint. 
        /// Returns a newly created DeliveryPoint
        /// </summary>
        /// <exception cref="ValidationApiException">If DeliveryPoint validation fail on server-side</exception>
        /// <exception cref="ApiException">If Response HttpStatus not equal 201</exception>
        [Post("/api/v1/DeliveryPoints")]
        Task<DeliveryPointDto> CreateAsync([Body] DeliveryPointDto dto);

        /// <summary>
        /// Updates a DeliveryPoint. 
        /// Returns a updated DeliveryPoint
        /// </summary>
        /// <exception cref="ValidationApiException">If DeliveryPoint validation fail on server-side</exception>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Put("/api/v1/DeliveryPoints")]
        Task<DeliveryPointDto> UpdateAsync([Body] DeliveryPointDto dto);

        /// <summary>
        /// Deletes a DeliveryPoint. 
        /// Returns TRUE if deleting done
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Delete("/api/v1/DeliveryPoints/{id}")]
        Task<bool> DeleteAsync(Guid id);

        /// <summary>
        /// Restores a DeliveryPoint. 
        /// Returns TRUE if restoring is done
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Delete("/api/v1/DeliveryPoints/undelete/{id}")]
        Task<bool> UndeleteAsync(Guid id);
    }
}
