using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNEClient.Dtos;

namespace TNEClient.Data
{
    /// <summary>
    /// Performs operations on the Providers 
    /// </summary>
    [Headers("Accept: application/json")]
    public interface IProviderRepository
    {
        /// <summary>
        /// Get all ProvidersDto. 
        /// Returns list of Providers or EMPTY List, if no Providers are found
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/Providers")]
        Task<List<ProviderDto>> GetAllAsync();

        /// <summary>
        /// Get all not deleted ProvidersDto. 
        /// Returns list of Providers or EMPTY List, if no Providers are found
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/Providers/active")]
        Task<List<ProviderDto>> GetAllActiveAsync();

        /// <summary>
        /// Returns a specific Provider by ID
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/Providers/{id}")]
        Task<ProviderDto> GetAsync(Guid id);

        /// <summary>
        /// Returns list of Providers by SubDivision ID or EMPTY List, if no Providers are found
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/Providers/bySubDivision/{id}")]
        Task<List<ProviderDto>> GetBySubDivisionAsync(Guid id);

        /// <summary>
        /// Creates a Provider. 
        /// Returns a newly created Provider
        /// </summary>
        /// <exception cref="ValidationApiException">If Provider validation fail on server-side</exception>
        /// <exception cref="ApiException">If Response HttpStatus not equal 201</exception>
        [Post("/api/v1/Providers")]
        Task<ProviderDto> CreateAsync([Body] ProviderDto dto);

        /// <summary>
        /// Updates a Provider. 
        /// Returns a updated Provider
        /// </summary>
        /// <exception cref="ValidationApiException">If Provider validation fail on server-side</exception>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Put("/api/v1/Providers")]
        Task<ProviderDto> UpdateAsync([Body] ProviderDto dto);

        /// <summary>
        /// Deletes a Provider. 
        /// Returns TRUE if deleting done
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Delete("/api/v1/Providers/{id}")]
        Task<bool> DeleteAsync(Guid id);

        /// <summary>
        /// Restores a Provider. 
        /// Returns TRUE if restoring is done
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Delete("/api/v1/Providers/undelete/{id}")]
        Task<bool> UndeleteAsync(Guid id);
    }
}
