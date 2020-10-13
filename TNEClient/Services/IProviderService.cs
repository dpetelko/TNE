using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNEClient.Dtos;

namespace TNEClient.Services
{
    public interface IProviderService
    {
        Task<List<ProviderDto>> GetAllAsync();
        Task<List<ProviderDto>> GetAllActiveAsync();
        Task<ProviderDto> GetAsync(Guid id);
        Task<ProviderDto> CreateAsync(ProviderDto dto);
        Task<ProviderDto> UpdateAsync(ProviderDto dto);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UndeleteAsync(Guid id);
        Task<List<ProviderDto>> GetAllDtoBySubDivisionIdAsync(Guid id);
    }
}
