using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TNEClient.Dtos;

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

        [Post("/api/v1/VoltageTransformers")]
        Task<List<HttpResponseMessage>> CreateAsync([Body] VoltageTransformerDto dto);

        [Put("/api/v1/VoltageTransformers")]
        Task<VoltageTransformerDto> UpdateAsync([Body] VoltageTransformerDto dto);

        [Put("/api/v1/VoltageTransformers/{id}/{status}")]
        Task<bool> SetStatus(Guid id, Status status);
    }
}
