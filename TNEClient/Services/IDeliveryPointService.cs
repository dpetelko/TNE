using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNEClient.Dtos;

namespace TNEClient.Services
{
    public interface IDeliveryPointService
    {
        Task<List<DeliveryPointDto>> GetAllAsync();
        Task<List<DeliveryPointDto>> GetAllActiveAsync();
        Task<DeliveryPointDto> GetAsync(Guid id);
        Task<DeliveryPointDto> CreateAsync(DeliveryPointDto dto);
        Task<DeliveryPointDto> UpdateAsync(DeliveryPointDto dto);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UndeleteAsync(Guid id);
        Task<List<DeliveryPointDto>> GetAllDtoByProviderIdAsync(Guid id);
    }
}
