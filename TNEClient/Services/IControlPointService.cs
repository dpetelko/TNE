using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNEClient.Dtos;

namespace TNEClient.Services
{
    public interface IControlPointService
    {
        Task<List<ControlPointDto>> GetAllAsync();
        Task<List<ControlPointDto>> GetAllActiveAsync();
        Task<ControlPointDto> GetAsync(Guid id);
        Task<ControlPointDto> CreateAsync(ControlPointDto dto);
        Task<ControlPointDto> UpdateAsync(ControlPointDto dto);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UndeleteAsync(Guid id);
        Task<List<ControlPointDto>> GetAllDtoByProviderIdAsync(Guid id);
    }
}
