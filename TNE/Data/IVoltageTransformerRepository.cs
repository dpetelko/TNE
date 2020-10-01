using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Dtos;
using TNE.Models;

namespace TNE.Data
{
    public interface IVoltageTransformerRepository : IRepository<VoltageTransformer>
    {
        Task<bool> SetStatus(Guid id, Status newStatus);
        Task<VoltageTransformerDto> GetDtoByIdAsync(Guid Id);
        Task<List<VoltageTransformerDto>> GetAllDtoAsync();
        Task<List<VoltageTransformerDto>> GetAllDtoByStatusAsync(Status status);
    }
}
