using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNE.Dtos;
using TNE.Dtos.SearchFilters;
using TNE.Models;

namespace TNE.Services
{
    public interface IControlPointService : IService<ControlPoint>
    {
        Task<ControlPointDto> GetDtoByIdAsync(Guid id);
        Task<List<ControlPointDto>> GetAllDtoAsync();
        Task<ControlPointDto> CreateAsync(ControlPointDto dto);
        Task<ControlPointDto> UpdateAsync(ControlPointDto dto);
        Task<List<ControlPointDto>> GetAllActiveDtoAsync();
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UndeleteAsync(Guid id);
        Task<List<ControlPointDto>> GetAllDtoByFilterAsync(InterTestingFilter filter);
        Task<List<ControlPointDto>> GetAllDtoByProviderIdAsync(Guid id);
    }
}
