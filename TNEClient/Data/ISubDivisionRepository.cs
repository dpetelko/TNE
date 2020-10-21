using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNEClient.Dtos;

namespace TNEClient.Data
{
    /// <summary>
    /// Performs operations on the SubDivisions 
    /// </summary>
    [Headers("Accept: application/json")]
    public interface ISubDivisionRepository
    {
        /// <summary>
        /// Get all SubDivisionsDto. 
        /// Returns list of SubDivisions or EMPTY List, if no SubDivisions are found
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/SubDivisions")]
        Task<List<SubDivisionDto>> GetAllAsync();

        /// <summary>
        /// Get all not deleted SubDivisionsDto. 
        /// Returns list of SubDivisions or EMPTY List, if no SubDivisions are found
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/SubDivisions/active")]
        Task<List<SubDivisionDto>> GetAllActiveAsync();

        /// <summary>
        /// Returns a specific SubDivision by ID
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/SubDivisions/{id}")]
        Task<SubDivisionDto> GetAsync(Guid id);

        /// <summary>
        /// Returns list of SubDivisions by LeadDivision ID or EMPTY List, if no SubDivisions are found
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/SubDivisions/byLeadDivision/{id}")]
        Task<List<SubDivisionDto>> GetByLeadDivisionAsync(Guid id);

        /// <summary>
        /// Creates a SubDivision. 
        /// Returns a newly created SubDivision
        /// </summary>
        /// <exception cref="ValidationApiException">If SubDivision validation fail on server-side</exception>
        /// <exception cref="ApiException">If Response HttpStatus not equal 201</exception>
        [Post("/api/v1/SubDivisions")]
        Task<SubDivisionDto> CreateAsync([Body] SubDivisionDto dto);

        /// <summary>
        /// Updates a SubDivision. 
        /// Returns a updated SubDivision
        /// </summary>
        /// <exception cref="ValidationApiException">If SubDivision validation fail on server-side</exception>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Put("/api/v1/SubDivisions")]
        Task<SubDivisionDto> UpdateAsync([Body] SubDivisionDto dto);

        /// <summary>
        /// Deletes a SubDivision. 
        /// Returns TRUE if deleting done
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Delete("/api/v1/SubDivisions/{id}")]
        Task<bool> DeleteAsync(Guid id);

        /// <summary>
        /// Restores a SubDivision. 
        /// Returns TRUE if restoring is done
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Delete("/api/v1/SubDivisions/undelete/{id}")]
        Task<bool> UndeleteAsync(Guid id);
    }
}
