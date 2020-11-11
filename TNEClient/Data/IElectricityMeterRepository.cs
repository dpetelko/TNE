using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNEClient.Dtos;
using TNEClient.Dtos.SearchFilters;

namespace TNEClient.Data
{

    [Headers("Accept: application/json")]
    public interface IElectricityMeterRepository
    {
        /// <summary>
        /// Performs operations on the ElectricityMeters 
        /// </summary>
        [Get("/api/v1/ElectricityMeters")]
        Task<List<ElectricityMeterDto>> GetAllAsync();

        /// <summary>
        /// Returns list of ElectricityMeters by Status or EMPTY List, if no ElectricityMeters are found
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/ElectricityMeters/status/{status}")]
        Task<List<ElectricityMeterDto>> GetAllByStatusAsync(Status status);

        /// <summary>
        /// Returns a specific ElectricityMeter by ID
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/ElectricityMeters/{id}")]
        Task<ElectricityMeterDto> GetAsync(Guid id);

        /// <summary>
        /// Returns list of ElectricityMeters by ControlPoint ID or EMPTY List, if no ElectricityMeters are found
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/ElectricityMeters/ControlPoint/{id}")]
        Task<ElectricityMeterDto> GetByControlPointIdAsync(Guid id);

        /// <summary>
        /// Returns list list of ElectricityMeters by DeviceCalibrationControlDto or EMPTY List, if no ElectricityMeters are found
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/ElectricityMeters/checkCalibration")]
        Task<List<ElectricityMeterDto>> GetAllDtoByFilterAsync([Body] DeviceCalibrationControlDto filter);

        /// <summary>
        /// Creates a ElectricityMeter. 
        /// Returns a newly created ElectricityMeter
        /// </summary>
        /// <exception cref="ValidationApiException">If ElectricityMeter validation fail on server-side</exception>
        /// <exception cref="ApiException">If Response HttpStatus not equal 201</exception>
        [Post("/api/v1/ElectricityMeters")]
        Task<ElectricityMeterDto> CreateAsync([Body] ElectricityMeterDto dto);

        /// <summary>
        /// Updates a ElectricityMeter. 
        /// Returns a updated ElectricityMeter
        /// </summary>
        /// <exception cref="ValidationApiException">If ElectricityMeter validation fail on server-side</exception>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Put("/api/v1/ElectricityMeters")]
        Task<ElectricityMeterDto> UpdateAsync([Body] ElectricityMeterDto dto);

        /// <summary>
        /// Set new status for ElectricityMeter by ID 
        /// Returns true if done
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Put("/api/v1/ElectricityMeters/{id}/{status}")]
        Task<bool> SetStatus(Guid id, Status status);
    }
}
