using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Dto;
using TNE.Models;

namespace TNE.Services
{
    public interface ISubDivisionService : IService<SubDivision>
    {
        Task<SubDivisionDto> GetDtoByIdAsync(Guid id);
        Task<List<SubDivisionDto>> GetAllDtoAsync();
        Task<SubDivisionDto> CreateAsync(SubDivisionDto dto);
        Task<SubDivisionDto> UpdateAsync(SubDivisionDto dto);
        Task<List<SubDivisionDto>> GetAllActiveDtoAsync();
    }
}
