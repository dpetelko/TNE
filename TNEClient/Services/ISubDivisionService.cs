using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNEClient.Dtos;

namespace TNEClient.Services
{
    public interface ISubDivisionService
    {
        Task<List<SubDivisionDto>> GetAllAsync();
        Task<List<SubDivisionDto>> GetAllActiveAsync();
        Task<SubDivisionDto> GetAsync(Guid id);
        Task<SubDivisionDto> CreateAsync(SubDivisionDto dto);
        Task<SubDivisionDto> UpdateAsync(SubDivisionDto dto);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UndeleteAsync(Guid id);
    }
}
