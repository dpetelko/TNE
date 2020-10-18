using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNEClient.Dtos;

namespace TNEClient.Data
{
    [Headers("Accept: application/json")]
    public interface IDeliveryPointRepository
    {
        [Get("/api/v1/DeliveryPoints")]
        Task<List<DeliveryPointDto>> GetAllAsync();

        [Get("/api/v1/DeliveryPoints/active")]
        Task<List<DeliveryPointDto>> GetAllActiveAsync();

        [Get("/api/v1/DeliveryPoints/{id}")]
        Task<DeliveryPointDto> GetAsync(Guid id);

        [Get("/api/v1/DeliveryPoints/byProvider/{id}")]
        Task<List<DeliveryPointDto>> GetByProviderAsync(Guid id);

        [Post("/api/v1/DeliveryPoints")]
        Task<DeliveryPointDto> CreateAsync([Body] DeliveryPointDto dto);

        [Put("/api/v1/DeliveryPoints")]
        Task<DeliveryPointDto> UpdateAsync([Body] DeliveryPointDto dto);

        [Delete("/api/v1/DeliveryPoints/{id}")]
        Task<bool> DeleteAsync(Guid id);

        [Delete("/api/v1/DeliveryPoints/undelete/{id}")]
        Task<bool> UndeleteAsync(Guid id);
    }
}
