using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Data.Exceptions;
using TNE.Dtos;
using TNE.Models;

namespace TNE.Services
{
    /// <summary>
    /// Performs operations on the ControlPoints 
    /// </summary>
    public interface IControlPointService : IService<ControlPoint>
    {
        /// <summary>
        /// Returns a specific ControlPoint by ID
        /// </summary>
        /// <exception cref="EntityNotFoundException">If no ControlPoints are found</exception>
        Task<ControlPointDto> GetDtoByIdAsync(Guid id);
        
        /// <summary>
        /// Get all ControlPointsDto. 
        /// Returns list of ControlPoints or EMPTY List, if no ControlPoints are found
        /// </summary>
        Task<List<ControlPointDto>> GetAllDtoAsync();
        
        /// <summary>
        /// Creates a ControlPoint. 
        /// Returns a newly created ControlPoint
        /// </summary>
        /// <exception cref="InvalidEntityException">If ControlPoint are invalid, e.g. ID is not Guid.Empty</exception>
        Task<ControlPointDto> CreateAsync(ControlPointDto dto);
        
        /// <summary>
        /// Updates a ControlPoint. Returns a updated ControlPoint
        /// </summary>
        /// <exception cref="InvalidEntityException">If ControlPoint are invalid, e.g. ID is Guid.Empty</exception>
        /// <exception cref="EntityNotFoundException">If ControlPoint are not found with this ID</exception>
        Task<ControlPointDto> UpdateAsync(ControlPointDto dto);
        
        /// <summary>
        /// Get all ControlPointsDto. 
        /// Returns list of ControlPoints or EMPTY List, if no ControlPoints are found
        /// </summary>
        Task<List<ControlPointDto>> GetAllActiveDtoAsync();
        
        /// <summary>
        /// Deletes a specific ControlPoint by ID
        /// </summary>
        /// <exception cref="EntityNotFoundException">If no ControlPoints are found</exception>
        Task<bool> DeleteAsync(Guid id);
        
        /// <summary>
        /// Restores a specific ControlPoint by ID
        /// </summary>
        /// <exception cref="EntityNotFoundException">If no ControlPoints are found</exception>
        Task<bool> UndeleteAsync(Guid id);
        
        /// <summary>
        /// Returns list of ControlPoints by Provider ID or EMPTY List, if no ControlPoints are found
        /// </summary>
        Task<List<ControlPointDto>> GetAllDtoByProviderIdAsync(Guid id);
    }
}
