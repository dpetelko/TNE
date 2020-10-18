using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TNEClient.Dtos;
using TNEClient.Dtos.SearchFilters;

namespace TNEClient.Data
{
    [Headers("Accept: application/json")]
    public interface IVoltageTransformerRepository
    {
        [Get("/api/v1/VoltageTransformers")]
        Task<List<VoltageTransformerDto>> GetAllAsync();

        [Get("/api/v1/VoltageTransformers/status/{status}")]
        Task<List<VoltageTransformerDto>> GetAllByStatusAsync(Status status);

        [Get("/api/v1/VoltageTransformers/{id}")]
        Task<VoltageTransformerDto> GetAsync(Guid id);

        [Get("/api/v1/VoltageTransformers/ControlPoint/{id}")]
        Task<VoltageTransformerDto> GetByControlPointIdAsync(Guid id);

        [Get("/api/v1/VoltageTransformers/checkCalibration")]
        Task<List<VoltageTransformerDto>> GetAllDtoByFilterAsync([Body] DeviceCalibrationControlDto filter);

        [Post("/api/v1/VoltageTransformers")]
        Task<VoltageTransformerDto> CreateAsync([Body] VoltageTransformerDto dto);

        [Put("/api/v1/VoltageTransformers")]
        Task<VoltageTransformerDto> UpdateAsync([Body] VoltageTransformerDto dto);

        [Put("/api/v1/VoltageTransformers/{id}/{status}")]
        Task<bool> SetStatus(Guid id, Status status);
    }
}
