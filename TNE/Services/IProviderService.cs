using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Dto;
using TNE.Models;

namespace TNE.Services
{
    public interface IProviderService : IService<Provider>
    {
        Task<ProviderDto> GetDtoByIdAsync(Guid id);
        Task<List<ProviderDto>> GetAllDtoAsync();
        Task<ProviderDto> CreateAsync(ProviderDto dto);
        Task<ProviderDto> UpdateAsync(ProviderDto dto);
        Task<List<ProviderDto>> GetAllActiveDtoAsync();
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UndeleteAsync(Guid id);
        Task<List<ProviderDto>> GetAllDtoBySubDivisionIdAsync(Guid id);
    }
}
