using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNE.Dtos;
using TNE.Dtos.SearchFilters;
using TNE.Models;

namespace TNE.Services
{
    public interface ICurrentTransformerService : IService<CurrentTransformer>
    {
        Task<bool> SetStatus(Guid id, Status newStatus);
        Task<CurrentTransformerDto> GetDtoByIdAsync(Guid id);
        Task<List<CurrentTransformerDto>> GetAllDtoAsync();
        Task<CurrentTransformerDto> CreateAsync(CurrentTransformerDto dto);
        Task<CurrentTransformerDto> UpdateAsync(CurrentTransformerDto dto);
        Task<List<CurrentTransformerDto>> GetAllDtoByStatusAsync(Status status);
        Task<CurrentTransformerDto> GetDtoByControlPointId(Guid id);
        Task<List<CurrentTransformerDto>> GetAllDtoByFilterAsync(DeviceCalibrationControlDto filter);
    }
}
