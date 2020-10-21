using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TNEClient.Dtos;
using TNEClient.Dtos.SearchFilters;

namespace TNEClient.Data
{
    /// <summary>
    /// Performs operations on the VoltageTransformers 
    /// </summary>
    [Headers("Accept: application/json")]
    public interface IVoltageTransformerRepository
    {
        /// <summary>
        /// Get all VoltageTransformersDto. 
        /// Returns list of VoltageTransformers or EMPTY List, if no VoltageTransformers are found
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/VoltageTransformers")]
        Task<List<VoltageTransformerDto>> GetAllAsync();

        /// <summary>
        /// Returns list of VoltageTransformers by Status or EMPTY List, if no VoltageTransformers are found
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/VoltageTransformers/status/{status}")]
        Task<List<VoltageTransformerDto>> GetAllByStatusAsync(Status status);

        /// <summary>
        /// Returns a specific VoltageTransformer by ID
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/VoltageTransformers/{id}")]
        Task<VoltageTransformerDto> GetAsync(Guid id);

        /// <summary>
        /// Returns list of VoltageTransformers by ControlPoint ID or EMPTY List, if no VoltageTransformers are found
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/VoltageTransformers/ControlPoint/{id}")]
        Task<VoltageTransformerDto> GetByControlPointIdAsync(Guid id);

        /// <summary>
        /// Returns list list of VoltageTransformers by DeviceCalibrationControlDto or EMPTY List, if no VoltageTransformers are found
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/VoltageTransformers/checkCalibration")]
        Task<List<VoltageTransformerDto>> GetAllDtoByFilterAsync([Body] DeviceCalibrationControlDto filter);

        /// <summary>
        /// Creates a VoltageTransformer. 
        /// Returns a newly created VoltageTransformer
        /// </summary>
        /// <exception cref="ValidationApiException">If VoltageTransformer validation fail on server-side</exception>
        /// <exception cref="ApiException">If Response HttpStatus not equal 201</exception>
        [Post("/api/v1/VoltageTransformers")]
        Task<VoltageTransformerDto> CreateAsync([Body] VoltageTransformerDto dto);

        /// <summary>
        /// Updates a VoltageTransformer. 
        /// Returns a updated VoltageTransformer
        /// </summary>
        /// <exception cref="ValidationApiException">If VoltageTransformer validation fail on server-side</exception>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Put("/api/v1/VoltageTransformers")]
        Task<VoltageTransformerDto> UpdateAsync([Body] VoltageTransformerDto dto);

        /// <summary>
        /// Set new status for VoltageTransformer by ID 
        /// Returns true if done
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Put("/api/v1/VoltageTransformers/{id}/{status}")]
        Task<bool> SetStatus(Guid id, Status status);
    }
}
