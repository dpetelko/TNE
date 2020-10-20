using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Data.Exceptions;
using TNE.Dto;
using TNE.Models;

namespace TNE.Services
{
    /// <summary>
    /// Performs operations on the SubDivisions 
    /// </summary>
    public interface ISubDivisionService : IService<SubDivision>
    {
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
        /// Creates a SubDivision. 
        /// Returns a newly created SubDivision
        /// </summary>
        /// <exception cref="InvalidEntityException">If SubDivision are invalid, e.g. ID is not Guid.Empty</exception>
        Task<SubDivisionDto> CreateAsync(SubDivisionDto dto);
        
        /// <summary>
        /// Updates a SubDivision. Returns a updated SubDivision
        /// </summary>
        /// <exception cref="InvalidEntityException">If SubDivision are invalid, e.g. ID is Guid.Empty</exception>
        /// <exception cref="EntityNotFoundException">If SubDivision are not found with this ID</exception>
        Task<SubDivisionDto> UpdateAsync(SubDivisionDto dto);
        
        /// <summary>
        /// Get all SubDivisions with attribute Deleted = false
        /// Returns list of SubDivisions or EMPTY List, if no SubDivisions are found
        /// </summary>
        Task<List<SubDivisionDto>> GetAllActiveDtoAsync();
        
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
        /// Returns list of SubDivisions by LeadDivision ID or EMPTY List, if no SubDivisions are found
        /// </summary>
        Task<List<SubDivisionDto>> GetAllDtoByLeadDivisionIdAsync(Guid id);
    }
}
