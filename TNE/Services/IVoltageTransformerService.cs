using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNE.Data.Exceptions;
using TNE.Dtos;
using TNE.Dtos.SearchFilters;
using TNE.Models;

namespace TNE.Services
{
    /// <summary>
    /// Performs operations on the CurrentTransformers 
    /// </summary>
    public interface IVoltageTransformerService : IService<VoltageTransformer>
    {
        /// <summary>
        /// Set new status for CurrentTransformer by ID 
        /// Returns true if done
        /// </summary>
        /// <exception cref="EntityNotFoundException">If no CurrentTransformers are found</exception>
        Task<bool> SetStatus(Guid id, Status newStatus);
        
        /// <summary>
        /// Returns a specific CurrentTransformer by ID
        /// </summary>
        /// <exception cref="EntityNotFoundException">If no CurrentTransformers are found</exception>
        Task<VoltageTransformerDto> GetDtoByIdAsync(Guid id);
        
        /// <summary>
        /// Get all CurrentTransformersDto. 
        /// Returns list of CurrentTransformers or EMPTY List, if no CurrentTransformers are found
        /// </summary>
        Task<List<VoltageTransformerDto>> GetAllDtoAsync();

        /// <summary>
        /// Creates a CurrentTransformer. 
        /// Returns a newly created CurrentTransformer
        /// </summary>
        /// <exception cref="InvalidEntityException">If CurrentTransformer are invalid, e.g. ID is not Guid.Empty</exception>
        Task<VoltageTransformerDto> CreateAsync(VoltageTransformerDto dto);
        
        /// <summary>
        /// Updates a CurrentTransformer. Returns a updated CurrentTransformer
        /// </summary>
        /// <exception cref="InvalidEntityException">If CurrentTransformer are invalid, e.g. ID is Guid.Empty</exception>
        /// <exception cref="EntityNotFoundException">If CurrentTransformer are not found with this ID</exception>
        Task<VoltageTransformerDto> UpdateAsync(VoltageTransformerDto dto);
        
        /// <summary>
        /// Returns list of CurrentTransformers by Status or EMPTY List, if no CurrentTransformers are found
        /// </summary>
        Task<List<VoltageTransformerDto>> GetAllDtoByStatusAsync(Status status);
        
        /// <summary>
        /// Returns list of CurrentTransformers by ControlPoint ID or EMPTY List, if no CurrentTransformers are found
        /// </summary>
        Task<VoltageTransformerDto> GetDtoByControlPointId(Guid id);
        
        /// <summary>
        /// Returns list of CurrentTransformers by DeviceCalibrationControlDto or EMPTY List, if no CurrentTransformers are found
        /// </summary>
        Task<List<VoltageTransformerDto>> GetAllDtoByFilterAsync(DeviceCalibrationControlDto filter);
    }
}
