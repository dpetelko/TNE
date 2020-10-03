using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNE.Dtos;
using TNE.Models;

namespace TNE.Data
{
    interface IBillingPointRepository : IRepository<BillingPoint>
    {
        Task<BillingPointDto> GetDtoByIdAsync(Guid Id);
        Task<List<BillingPointDto>> GetAllDtoAsync();
    }
}
