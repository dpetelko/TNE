using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNE.Dtos;
using TNE.Dtos.SearchFilters;
using TNE.Models;

namespace TNE.Data
{
    public interface IControlPointRepository : IRepository<ControlPoint>
    {
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UndeleteAsync(Guid id);
        Task<ControlPointDto> GetDtoByIdAsync(Guid Id);
        Task<List<ControlPointDto>> GetAllDtoAsync();
        Task<List<ControlPointDto>> GetAllActiveDtoAsync();
        Task<List<ControlPointDto>> GetAllDtoByFilterAsync(DeviceCalibrationControlDto filter);
        Task<List<ControlPointDto>> GetAllDtoByProviderIdAsync(Guid id);
    }
}
