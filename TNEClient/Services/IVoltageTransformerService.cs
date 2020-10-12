using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TNEClient.Dtos;

namespace TNEClient.Services
{
    public interface IVoltageTransformerService
    {
        Task<List<VoltageTransformerDto>> GetAllAsync();
        Task<List<VoltageTransformerDto>> GetAllByStatusAsync(Status status);
        Task<VoltageTransformerDto> GetAsync(Guid id);
        Task<VoltageTransformerDto> CreateAsync(VoltageTransformerDto dto);
        Task<VoltageTransformerDto> UpdateAsync(VoltageTransformerDto dto);
        Task<bool> SetStatus(Guid id, Status status);
        Task<VoltageTransformerDto> GetDtoByControlPointId(Guid id);
    }
}
