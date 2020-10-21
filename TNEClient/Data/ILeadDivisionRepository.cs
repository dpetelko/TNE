using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNEClient.Dtos;

namespace TNEClient.Data
{
    /// <summary>
    /// Performs operations on the LeadDivisions 
    /// </summary>
    [Headers("Accept: application/json")]
    public interface ILeadDivisionRepository
    {
        /// <summary>
        /// Get all LeadDivisionsDto. 
        /// Returns list of LeadDivisions or EMPTY List, if no LeadDivisions are found
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/LeadDivisions")]
        Task<List<LeadDivisionDto>> GetAllAsync();
        
        /// <summary>
        /// Get all not deleted LeadDivisionsDto. 
        /// Returns list of LeadDivisions or EMPTY List, if no LeadDivisions are found
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/LeadDivisions/active")]
        Task<List<LeadDivisionDto>> GetAllActiveAsync();

        /// <summary>
        /// Returns a specific LeadDivision by ID
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/LeadDivisions/{id}")]
        Task<LeadDivisionDto> GetAsync(Guid id);

        /// <summary>
        /// Creates a LeadDivision. 
        /// Returns a newly created LeadDivision
        /// </summary>
        /// <exception cref="ValidationApiException">If LeadDivision validation fail on server-side</exception>
        /// <exception cref="ApiException">If Response HttpStatus not equal 201</exception>
        [Post("/api/v1/LeadDivisions")]
        Task<LeadDivisionDto> CreateAsync([Body] LeadDivisionDto dto);

        /// <summary>
        /// Updates a LeadDivision. 
        /// Returns a updated LeadDivision
        /// </summary>
        /// <exception cref="ValidationApiException">If LeadDivision validation fail on server-side</exception>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Put("/api/v1/LeadDivisions")]
        Task<LeadDivisionDto> UpdateAsync([Body] LeadDivisionDto dto);

        /// <summary>
        /// Deletes a LeadDivision. 
        /// Returns TRUE if deleting done
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Delete("/api/v1/LeadDivisions/{id}")]
        Task<bool> DeleteAsync(Guid id);

        /// <summary>
        /// Restores a LeadDivision. 
        /// Returns TRUE if restoring is done
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Delete("/api/v1/LeadDivisions/undelete/{id}")]
        Task<bool> UndeleteAsync(Guid id);
    }
}
