using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Dto;
using TNE.Models;

namespace TNE.Data
{
    public interface ISubDivisionRepository : IRepository<SubDivision>
    {
        Task<SubDivisionDto> GetDtoByIdAsync(Guid Id);
        Task<List<SubDivisionDto>> GetAllDtoAsync();
    }
}
