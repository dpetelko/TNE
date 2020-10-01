using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNE.Dtos;
using TNE.Models;

namespace TNE.Services
{
    public interface IDeliveryPointService : IService<DeliveryPoint>
    {
        Task<DeliveryPointDto> GetDtoByIdAsync(Guid id);
        Task<List<DeliveryPointDto>> GetAllDtoAsync();
        Task<DeliveryPointDto> CreateAsync(DeliveryPointDto dto);
        Task<DeliveryPointDto> UpdateAsync(DeliveryPointDto dto);
        Task<List<DeliveryPointDto>> GetAllActiveDtoAsync();
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UndeleteAsync(Guid id);
    }
}
