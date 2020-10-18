using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNE.Dtos;
using TNE.Dtos.SearchFilters;
using TNE.Models;

namespace TNE.Services
{
    public interface IVoltageTransformerService : IService<VoltageTransformer>
    {
        Task<bool> SetStatus(Guid id, Status newStatus);
        Task<VoltageTransformerDto> GetDtoByIdAsync(Guid id);
        Task<List<VoltageTransformerDto>> GetAllDtoAsync();
        Task<VoltageTransformerDto> CreateAsync(VoltageTransformerDto dto);
        Task<VoltageTransformerDto> UpdateAsync(VoltageTransformerDto dto);
        Task<List<VoltageTransformerDto>> GetAllDtoByStatusAsync(Status status);
        Task<VoltageTransformerDto> GetDtoByControlPointId(Guid id);
        Task<List<VoltageTransformerDto>> GetAllDtoByFilterAsync(DeviceCalibrationControlDto filter);
    }
}
