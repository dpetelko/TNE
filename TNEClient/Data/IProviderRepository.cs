using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNEClient.Dtos;

namespace TNEClient.Data
{
    public interface IProviderRepository
    {
        [Get("/api/v1/Providers")]
        Task<List<ProviderDto>> GetAllAsync();

        [Get("/api/v1/Providers/active")]
        Task<List<ProviderDto>> GetAllActiveAsync();

        [Get("/api/v1/Providers/{id}")]
        Task<ProviderDto> GetAsync(Guid id);

        [Post("/api/v1/Providers")]
        Task<ProviderDto> CreateAsync([Body] ProviderDto dto);

        [Put("/api/v1/Providers")]
        Task<ProviderDto> UpdateAsync([Body] ProviderDto dto);

        [Delete("/api/v1/Providers/{id}")]
        Task<bool> DeleteAsync(Guid id);

        [Delete("/api/v1/Providers/undelete/{id}")]
        Task<bool> UndeleteAsync(Guid id);
    }
}
