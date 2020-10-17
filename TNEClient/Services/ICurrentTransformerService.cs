using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TNEClient.Dtos;
using TNEClient.Dtos.SearchFilters;

namespace TNEClient.Services
{
    public interface ICurrentTransformerService
    {
        Task<List<CurrentTransformerDto>> GetAllAsync();
        Task<List<CurrentTransformerDto>> GetAllByStatusAsync(Status status);
        Task<CurrentTransformerDto> GetAsync(Guid id);
        Task<CurrentTransformerDto> CreateAsync(CurrentTransformerDto dto);
        Task<CurrentTransformerDto> UpdateAsync(CurrentTransformerDto dto);
        Task<bool> SetStatus(Guid id, Status status);
        Task<CurrentTransformerDto> GetDtoByControlPointId(Guid id);
        Task<List<CurrentTransformerDto>> GetAllDtoByFilterAsync(DeviceCalibrationControlDto filter);
    }
}
