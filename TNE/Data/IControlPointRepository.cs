using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNE.Data.Exceptions;
using TNE.Dtos;
using TNE.Dtos.SearchFilters;
using TNE.Models;

namespace TNE.Data
{
    public interface IControlPointRepository : IRepository<ControlPoint>
    {
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
        /// Get all ControlPoints with attribute Deleted = false
        /// Returns list of ControlPoints or EMPTY List, if no ControlPoints are found
        /// </summary>
        Task<List<ControlPointDto>> GetAllActiveDtoAsync();
        
        /// <summary>
        /// Returns list of ControlPoints by Provider ID or EMPTY List, if no ControlPoints are found
        /// </summary>
        Task<List<ControlPointDto>> GetAllDtoByProviderIdAsync(Guid id);
    }
}
