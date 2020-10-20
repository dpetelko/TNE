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
    /// Performs operations on the VoltageTransformers 
    /// </summary>
    public interface IVoltageTransformerService : IService<VoltageTransformer>
    {
        /// <summary>
        /// Set new status for VoltageTransformer by ID 
        /// Returns true if done
        /// </summary>
        /// <exception cref="EntityNotFoundException">If no VoltageTransformers are found</exception>
        Task<bool> SetStatus(Guid id, Status newStatus);
        
        /// <summary>
        /// Returns a specific VoltageTransformer by ID
        /// </summary>
        /// <exception cref="EntityNotFoundException">If no VoltageTransformers are found</exception>
        Task<VoltageTransformerDto> GetDtoByIdAsync(Guid id);
        
        /// <summary>
        /// Get all VoltageTransformersDto. 
        /// Returns list of VoltageTransformers or EMPTY List, if no VoltageTransformers are found
        /// </summary>
        Task<List<VoltageTransformerDto>> GetAllDtoAsync();

        /// <summary>
        /// Creates a VoltageTransformer. 
        /// Returns a newly created VoltageTransformer
        /// </summary>
        /// <exception cref="InvalidEntityException">If VoltageTransformer are invalid, e.g. ID is not Guid.Empty</exception>
        Task<VoltageTransformerDto> CreateAsync(VoltageTransformerDto dto);
        
        /// <summary>
        /// Updates a VoltageTransformer. Returns a updated VoltageTransformer
        /// </summary>
        /// <exception cref="InvalidEntityException">If VoltageTransformer are invalid, e.g. ID is Guid.Empty</exception>
        /// <exception cref="EntityNotFoundException">If VoltageTransformer are not found with this ID</exception>
        Task<VoltageTransformerDto> UpdateAsync(VoltageTransformerDto dto);
        
        /// <summary>
        /// Returns list of VoltageTransformers by Status or EMPTY List, if no VoltageTransformers are found
        /// </summary>
        Task<List<VoltageTransformerDto>> GetAllDtoByStatusAsync(Status status);
        
        /// <summary>
        /// Returns list of VoltageTransformers by ControlPoint ID or EMPTY List, if no VoltageTransformers are found
        /// </summary>
        Task<VoltageTransformerDto> GetDtoByControlPointId(Guid id);
        
        /// <summary>
        /// Returns list of VoltageTransformers by DeviceCalibrationControlDto or EMPTY List, if no VoltageTransformers are found
        /// </summary>
        Task<List<VoltageTransformerDto>> GetAllDtoByFilterAsync(DeviceCalibrationControlDto filter);
    }
}
