using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNEClient.Dtos;

namespace TNEClient.Services
{
    public interface IBillingPointService
    {
        Task<List<BillingPointDto>> GetAllAsync();
        Task<BillingPointDto> GetAsync(Guid id);
        Task<BillingPointDto> CreateAsync(BillingPointDto dto);
        Task<BillingPointDto> UpdateAsync(BillingPointDto dto);
    }
}
