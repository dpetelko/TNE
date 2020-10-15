using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNEClient.Dtos;
using TNEClient.Dtos.SearchFilters;

namespace TNEClient.Services
{
    public interface IBillingPointService
    {
        Task<List<BillingPointDto>> GetAllAsync();
        Task<BillingPointDto> GetAsync(Guid id);
        Task<BillingPointDto> CreateAsync(BillingPointDto dto);
        Task<BillingPointDto> UpdateAsync(BillingPointDto dto);
        Task<List<BillingPointDto>> GetAllDtoByControlPointIdAsync(Guid id);
        Task<List<BillingPointDto>> GetAllDtoByDeliveryPointIdAsync(Guid id);
        Task<List<BillingPointDto>> GetAllDtoByFilterAsync(BillingPointFilter filter);
    }
}
