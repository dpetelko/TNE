using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNE.Dtos;
using TNE.Models;

namespace TNE.Data
{
    public interface IDeliveryPointRepository : IRepository<DeliveryPoint>
    {
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UndeleteAsync(Guid id);
        Task<DeliveryPointDto> GetDtoByIdAsync(Guid Id);
        Task<List<DeliveryPointDto>> GetAllDtoAsync();
        Task<List<DeliveryPointDto>> GetAllActiveDtoAsync();
        Task<List<DeliveryPointDto>> GetAllDtoByProviderIdAsync(Guid id);
    }
}
