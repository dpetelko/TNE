using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Dto;
using TNE.Models;

namespace TNE.Data
{
    public interface IProviderRepository : IRepository<Provider>
    {
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UndeleteAsync(Guid id);
        Task<ProviderDto> GetDtoByIdAsync(Guid Id);
        Task<List<ProviderDto>> GetAllDtoAsync();
        Task<List<ProviderDto>> GetAllActiveDtoAsync();
    }
}
