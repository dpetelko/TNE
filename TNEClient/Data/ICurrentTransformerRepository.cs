using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNEClient.Dtos;
using TNEClient.Dtos.SearchFilters;

namespace TNEClient.Data
{
    /// <summary>
    /// Performs operations on the CurrentTransformers 
    /// </summary>
    [Headers("Accept: application/json")]
    public interface ICurrentTransformerRepository
    {
        /// <summary>
        /// Get all CurrentTransformersDto. 
        /// Returns list of CurrentTransformers or EMPTY List, if no CurrentTransformers are found
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/CurrentTransformers")]
        Task<List<CurrentTransformerDto>> GetAllAsync();
        
        /// <summary>
        /// Returns list of CurrentTransformers by Status or EMPTY List, if no CurrentTransformers are found
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/CurrentTransformers/status/{status}")]
        Task<List<CurrentTransformerDto>> GetAllByStatusAsync(Status status);

        /// <summary>
        /// Returns a specific CurrentTransformer by ID
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/CurrentTransformers/{id}")]
        Task<CurrentTransformerDto> GetAsync(Guid id);

        /// <summary>
        /// Returns list of CurrentTransformers by ControlPoint ID or EMPTY List, if no CurrentTransformers are found
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/CurrentTransformers/ControlPoint/{id}")]
        Task<CurrentTransformerDto> GetByControlPointIdAsync(Guid id);

        /// <summary>
        /// Returns list list of CurrentTransformers by DeviceCalibrationControlDto or EMPTY List, if no CurrentTransformers are found
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/CurrentTransformers/checkCalibration")]
        Task<List<CurrentTransformerDto>> GetAllDtoByFilterAsync([Body] DeviceCalibrationControlDto filter);

        /// <summary>
        /// Creates a CurrentTransformer. 
        /// Returns a newly created CurrentTransformer
        /// </summary>
        /// <exception cref="ValidationApiException">If CurrentTransformer validation fail on server-side</exception>
        /// <exception cref="ApiException">If Response HttpStatus not equal 201</exception>
        [Post("/api/v1/CurrentTransformers")]
        Task<CurrentTransformerDto> CreateAsync([Body] CurrentTransformerDto dto);

        /// <summary>
        /// Updates a CurrentTransformer. 
        /// Returns a updated CurrentTransformer
        /// </summary>
        /// <exception cref="ValidationApiException">If CurrentTransformer validation fail on server-side</exception>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Put("/api/v1/CurrentTransformers")]
        Task<CurrentTransformerDto> UpdateAsync([Body] CurrentTransformerDto dto);

        /// <summary>
        /// Set new status for CurrentTransformer by ID 
        /// Returns true if done
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Put("/api/v1/CurrentTransformers/{id}/{status}")]
        Task<bool> SetStatus(Guid id, Status status);
    }
}
