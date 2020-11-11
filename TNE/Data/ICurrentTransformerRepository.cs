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
    /// Performs operations on the CurrentTransformers 
    /// </summary>
    public interface ICurrentTransformerRepository : IRepository<CurrentTransformer>
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
        Task<CurrentTransformerDto> GetDtoByIdAsync(Guid id);

        /// <summary>
        /// Get all CurrentTransformersDto. 
        /// Returns list of CurrentTransformers or EMPTY List, if no CurrentTransformers are found
        /// </summary>
        Task<List<CurrentTransformerDto>> GetAllDtoAsync();

        /// <summary>
        /// Returns list of CurrentTransformers by Status or EMPTY List, if no CurrentTransformers are found
        /// </summary>
        Task<List<CurrentTransformerDto>> GetAllDtoByStatusAsync(Status status);

        /// <summary>
        /// Returns list of CurrentTransformers by ControlPoint ID or EMPTY List, if no CurrentTransformers are found
        /// </summary>
        Task<CurrentTransformerDto> GetDtoByControlPointId(Guid id);

        /// <summary>
        /// Returns list of CurrentTransformers by DeviceCalibrationControlDto or EMPTY List, if no CurrentTransformers are found
        /// </summary>
        Task<List<CurrentTransformerDto>> GetAllDtoByFilterAsync(DeviceCalibrationControlDto filter);
    }
}
