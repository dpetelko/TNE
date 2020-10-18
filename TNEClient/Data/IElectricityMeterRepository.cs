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
        [Get("/api/v1/ElectricityMeters")]
        Task<List<ElectricityMeterDto>> GetAllAsync();

        [Get("/api/v1/ElectricityMeters/status/{status}")]
        Task<List<ElectricityMeterDto>> GetAllByStatusAsync(Status status);

        [Get("/api/v1/ElectricityMeters/{id}")]
        Task<ElectricityMeterDto> GetAsync(Guid id);

        [Get("/api/v1/ElectricityMeters/ControlPoint/{id}")]
        Task<ElectricityMeterDto> GetByControlPointIdAsync(Guid id);
        
        [Get("/api/v1/ElectricityMeters/checkCalibration")]
        Task<List<ElectricityMeterDto>> GetAllDtoByFilterAsync([Body] DeviceCalibrationControlDto filter);

        [Post("/api/v1/ElectricityMeters")]
        Task<ElectricityMeterDto> CreateAsync([Body] ElectricityMeterDto dto);

        [Put("/api/v1/ElectricityMeters")]
        Task<ElectricityMeterDto> UpdateAsync([Body] ElectricityMeterDto dto);

        [Put("/api/v1/ElectricityMeters/{id}/{status}")]
        Task<bool> SetStatus(Guid id, Status status);
    }
}
