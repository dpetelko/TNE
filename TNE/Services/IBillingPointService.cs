using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNE.Dtos;
using TNE.Models;

namespace TNE.Services
{
    public interface IBillingPointService : IService<BillingPoint>
    {
        Task<BillingPointDto> GetDtoByIdAsync(Guid id);
        Task<List<BillingPointDto>> GetAllDtoAsync();
        Task<BillingPointDto> CreateAsync(BillingPointDto dto);
        Task<BillingPointDto> UpdateAsync(BillingPointDto dto);
        Task<List<BillingPointDto>> GetAllDtoByControlPointIdAsync(Guid id);
        Task<List<BillingPointDto>> GetAllDtoByDeliveryPointIdAsync(Guid id);
    }
}
