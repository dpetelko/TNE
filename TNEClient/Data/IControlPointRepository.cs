using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNEClient.Dtos;

namespace TNEClient.Data
{
    public interface IControlPointRepository
    {
        [Get("/api/v1/ControlPoints")]
        Task<List<ControlPointDto>> GetAllAsync();

        [Get("/api/v1/ControlPoints/active")]
        Task<List<ControlPointDto>> GetAllActiveAsync();

        [Get("/api/v1/ControlPoints/{id}")]
        Task<ControlPointDto> GetAsync(Guid id);

        [Post("/api/v1/ControlPoints")]
        Task<ControlPointDto> CreateAsync([Body] ControlPointDto dto);

        [Put("/api/v1/ControlPoints")]
        Task<ControlPointDto> UpdateAsync([Body] ControlPointDto dto);

        [Delete("/api/v1/ControlPoints/{id}")]
        Task<bool> DeleteAsync(Guid id);

        [Delete("/api/v1/ControlPoints/undelete/{id}")]
        Task<bool> UndeleteAsync(Guid id);
    }
}
