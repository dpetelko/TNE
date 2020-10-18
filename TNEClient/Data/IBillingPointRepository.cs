using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNEClient.Dtos;
using TNEClient.Dtos.SearchFilters;

namespace TNEClient.Data
{
    [Headers("Accept: application/json")]
    public interface IBillingPointRepository
    {
        [Get("/api/v1/BillingPoints")]
        Task<List<BillingPointDto>> GetAllAsync();

        [Get("/api/v1/BillingPoints/{id}")]
        Task<BillingPointDto> GetAsync(Guid id);

        [Get("/api/v1/BillingPoints/ControlPoint/{id}")]
        Task<List<BillingPointDto>> GetByControlPointAsync(Guid id);

        [Get("/api/v1/BillingPoints/DeliveryPoint/{id}")]
        Task<List<BillingPointDto>> GetByDeliveryPointAsync(Guid id);

        [Get("/api/v1/BillingPoints/filter")]
        Task<List<BillingPointDto>> GetByFilterAsync([Body] BillingPointFilter filter);

        [Post("/api/v1/BillingPoints")]
        Task<BillingPointDto> CreateAsync([Body] BillingPointDto dto);

        [Put("/api/v1/BillingPoints")]
        Task<BillingPointDto> UpdateAsync([Body] BillingPointDto dto);
    }
}
