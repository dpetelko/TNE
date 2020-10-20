using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Data.Exceptions;
using TNE.Dto.LeadDivisions;
using TNE.Models;

namespace TNE.Services
{
    /// <summary>
    /// Performs operations on the LeadDivisions 
    /// </summary>
    public interface ILeadDivisionService : IService<LeadDivision>
    {
        /// <summary>
        /// Returns a specific LeadDivision by ID
        /// </summary>
        /// <exception cref="EntityNotFoundException">If no LeadDivisions are found</exception>
        Task<LeadDivisionDto> GetDtoByIdAsync(Guid id);
        
        /// <summary>
        /// Get all LeadDivisionsDto. 
        /// Returns list of LeadDivisions or EMPTY List, if no LeadDivisions are found
        /// </summary>
        Task<List<LeadDivisionDto>> GetAllDtoAsync();
        
        /// <summary>
        /// Creates a LeadDivision. 
        /// Returns a newly created LeadDivision
        /// </summary>
        /// <exception cref="InvalidEntityException">If LeadDivision are invalid, e.g. ID is not Guid.Empty</exception>
        Task<LeadDivisionDto> CreateAsync(LeadDivisionDto dto);
        
        /// <summary>
        /// Updates a LeadDivision. Returns a updated LeadDivision
        /// </summary>
        /// <exception cref="InvalidEntityException">If LeadDivision are invalid, e.g. ID is Guid.Empty</exception>
        /// <exception cref="EntityNotFoundException">If LeadDivision are not found with this ID</exception>
        Task<LeadDivisionDto> UpdateAsync(LeadDivisionDto dto);
        
        /// <summary>
        /// Get all LeadDivisions with attribute Deleted = false
        /// Returns list of LeadDivisions or EMPTY List, if no LeadDivisions are found
        /// </summary>
        Task<List<LeadDivisionDto>> GetAllActiveDtoAsync();
        
        /// <summary>
        /// Deletes a specific LeadDivision by ID
        /// </summary>
        /// <exception cref="EntityNotFoundException">If no LeadDivisions are found</exception>
        Task<bool> DeleteAsync(Guid id);
        
        /// <summary>
        /// Restores a specific LeadDivision by ID
        /// </summary>
        /// <exception cref="EntityNotFoundException">If no LeadDivisions are found</exception>
        Task<bool> UndeleteAsync(Guid id);
    }
}
