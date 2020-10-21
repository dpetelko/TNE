using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Data.Exceptions;
using TNE.Dtos;
using TNE.Dtos.SearchFilters;
using TNE.Models;

namespace TNE.Data
{
    /// <summary>
    /// Performs operations on the VoltageTransformers 
    /// </summary>
    public interface IVoltageTransformerRepository : IRepository<VoltageTransformer>
    {


        Task<VoltageTransformer> GetByIdAsyncWithTracking(Guid id);

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
