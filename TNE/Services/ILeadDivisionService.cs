using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Dto.LeadDivisions;
using TNE.Models;

namespace TNE.Services
{
    public interface ILeadDivisionService : IService<LeadDivision>
    {
        Task<LeadDivisionDto> GetDtoByIdAsync(Guid id);
        Task<List<LeadDivisionDto>> GetAllDtoAsync();
        Task<LeadDivisionDto> CreateAsync(LeadDivisionDto dto);
        Task<LeadDivisionDto> UpdateAsync(LeadDivisionDto dto);
    }
}
