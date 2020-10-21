using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNEClient.Dtos;

namespace TNEClient.Data
{
    /// <summary>
    /// Performs operations on the ControlPoints 
    /// </summary>
    [Headers("Accept: application/json")]
    public interface IControlPointRepository
    {
        /// <summary>
        /// Get all ControlPointsDto. 
        /// Returns list of ControlPoints or EMPTY List, if no ControlPoints are found
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/ControlPoints")]
        Task<List<ControlPointDto>> GetAllAsync();

        /// <summary>
        /// Get all not deleted ControlPointsDto. 
        /// Returns list of ControlPoints or EMPTY List, if no ControlPoints are found
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/ControlPoints/active")]
        Task<List<ControlPointDto>> GetAllActiveAsync();
        
        /// <summary>
        /// Returns a specific ControlPoint by ID
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/ControlPoints/{id}")]
        Task<ControlPointDto> GetAsync(Guid id);

        /// <summary>
        /// Returns list of ControlPoints by Provider ID or EMPTY List, if no ControlPoints are found
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/ControlPoints/byProvider/{id}")]
        Task<List<ControlPointDto>> GetByProviderAsync(Guid id);

        /// <summary>
        /// Creates a ControlPoint. 
        /// Returns a newly created ControlPoint
        /// </summary>
        /// <exception cref="ValidationApiException">If ControlPoint validation fail on server-side</exception>
        /// <exception cref="ApiException">If Response HttpStatus not equal 201</exception>
        [Post("/api/v1/ControlPoints")]
        Task<ControlPointDto> CreateAsync([Body] ControlPointDto dto);

        /// <summary>
        /// Updates a ControlPoint. 
        /// Returns a updated ControlPoint
        /// </summary>
        /// <exception cref="ValidationApiException">If ControlPoint validation fail on server-side</exception>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Put("/api/v1/ControlPoints")]
        Task<ControlPointDto> UpdateAsync([Body] ControlPointDto dto);

        /// <summary>
        /// Deletes a ControlPoint. 
        /// Returns TRUE if deleting done
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Delete("/api/v1/ControlPoints/{id}")]
        Task<bool> DeleteAsync(Guid id);

        /// <summary>
        /// Restores a ControlPoint. 
        /// Returns TRUE if restoring is done
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Delete("/api/v1/ControlPoints/undelete/{id}")]
        Task<bool> UndeleteAsync(Guid id);
    }
}
