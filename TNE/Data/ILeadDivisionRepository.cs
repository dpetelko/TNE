using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Data.Exceptions;
using TNE.Dto;
using TNE.Models;

namespace TNE.Data
{
    /// <summary>
    /// Performs operations on the LeadDivisions 
    /// </summary>
    public interface ILeadDivisionRepository : IRepository<LeadDivision>
    {
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
        /// Get all LeadDivisions with attribute Deleted = false
        /// Returns list of LeadDivisions or EMPTY List, if no LeadDivisions are found
        /// </summary>
        Task<List<LeadDivisionDto>> GetAllActiveDtoAsync();

    }
}
