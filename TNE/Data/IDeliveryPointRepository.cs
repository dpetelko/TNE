using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNE.Dtos;
using TNE.Models;

namespace TNE.Data
{
    interface IDeliveryPointRepository : IRepository<DeliveryPoint>
    {
        Task<DeliveryPointDto> GetDtoByIdAsync(Guid Id);
        Task<List<DeliveryPointDto>> GetAllDtoAsync();
        Task<List<DeliveryPointDto>> GetAllActiveDtoAsync();
    }
}
