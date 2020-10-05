using System.Collections.Generic;
using System.Threading.Tasks;
using TNEClient.Dtos;

namespace TNEClient.Services
{
    public interface ILeadDivisionService
    {
        Task<List<LeadDivisionDto>> GetAllAsync();
        Task<List<LeadDivisionDto>> GetAllActiveAsync();
        Task<LeadDivisionDto> GetAsync(int id);
        Task<LeadDivisionDto> CreateAsync(LeadDivisionDto dto);
        Task<LeadDivisionDto> ReplaceAsync(LeadDivisionDto dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> UndeleteAsync(int id);
    }
}
