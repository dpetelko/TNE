using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Data.Exceptions;
using TNE.Dto;
using TNE.Models;

namespace TNE.Data
{
    /// <summary>
    /// Performs operations on the SubDivisions 
    /// </summary>
    public interface ISubDivisionRepository : IRepository<SubDivision>
    {
        /// <summary>
        /// Deletes a specific SubDivision by ID
        /// </summary>
        /// <exception cref="EntityNotFoundException">If no SubDivisions are found</exception>
        Task<bool> DeleteAsync(Guid id);
        
        /// <summary>
        /// Restores a specific SubDivision by ID
        /// </summary>
        /// <exception cref="EntityNotFoundException">If no SubDivisions are found</exception>
        Task<bool> UndeleteAsync(Guid id);
        
        /// <summary>
        /// Returns a specific SubDivision by ID
        /// </summary>
        /// <exception cref="EntityNotFoundException">If no SubDivisions are found</exception>
        Task<SubDivisionDto> GetDtoByIdAsync(Guid id);
        
        /// <summary>
        /// Get all SubDivisionsDto. 
        /// Returns list of SubDivisions or EMPTY List, if no SubDivisions are found
        /// </summary>
        Task<List<SubDivisionDto>> GetAllDtoAsync();
        
        /// <summary>
        /// Get all SubDivisions with attribute Deleted = false
        /// Returns list of SubDivisions or EMPTY List, if no SubDivisions are found
        /// </summary>
        Task<List<SubDivisionDto>> GetAllActiveDtoAsync();
        
        /// <summary>
        /// Returns list of SubDivisions by LeadDivision ID or EMPTY List, if no SubDivisions are found
        /// </summary>
        Task<List<SubDivisionDto>> GetAllDtoByLeadDivisionIdAsync(Guid id);
    }
}
