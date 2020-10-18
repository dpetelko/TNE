using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNEClient.Dtos;
using TNEClient.Dtos.SearchFilters;

namespace TNEClient.Data
{
    [Headers("Accept: application/json")]
    public interface ICurrentTransformerRepository
    {
        [Get("/api/v1/CurrentTransformers")]
        Task<List<CurrentTransformerDto>> GetAllAsync();

        [Get("/api/v1/CurrentTransformers/status/{status}")]
        Task<List<CurrentTransformerDto>> GetAllByStatusAsync(Status status);

        [Get("/api/v1/CurrentTransformers/{id}")]
        Task<CurrentTransformerDto> GetAsync(Guid id);

        [Get("/api/v1/CurrentTransformers/ControlPoint/{id}")]
        Task<CurrentTransformerDto> GetByControlPointIdAsync(Guid id);

        [Get("/api/v1/CurrentTransformers/checkCalibration")]
        Task<List<CurrentTransformerDto>> GetAllDtoByFilterAsync([Body] DeviceCalibrationControlDto filter);

        [Post("/api/v1/CurrentTransformers")]
        Task<CurrentTransformerDto> CreateAsync([Body] CurrentTransformerDto dto);

        [Put("/api/v1/CurrentTransformers")]
        Task<CurrentTransformerDto> UpdateAsync([Body] CurrentTransformerDto dto);

        [Put("/api/v1/CurrentTransformers/{id}/{status}")]
        Task<bool> SetStatus(Guid id, Status status);
    }
}
