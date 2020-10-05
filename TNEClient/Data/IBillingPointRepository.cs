using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNEClient.Dtos;

namespace TNEClient.Data
{
    public interface IBillingPointRepository
    {
        [Get("/api/v1/BillingPoints")]
        Task<List<BillingPointDto>> GetAllAsync();

        [Get("/api/v1/BillingPoints/{id}")]
        Task<BillingPointDto> GetAsync(Guid id);

        [Post("/api/v1/BillingPoints")]
        Task<BillingPointDto> CreateAsync([Body] BillingPointDto dto);

        [Put("/api/v1/BillingPoints")]
        Task<BillingPointDto> UpdateAsync([Body] BillingPointDto dto);
    }
}
