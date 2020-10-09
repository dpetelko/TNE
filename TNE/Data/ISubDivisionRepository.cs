﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Dto;
using TNE.Models;

namespace TNE.Data
{
    public interface ISubDivisionRepository : IRepository<SubDivision>
    {
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UndeleteAsync(Guid id);
        Task<SubDivisionDto> GetDtoByIdAsync(Guid Id);
        Task<List<SubDivisionDto>> GetAllDtoAsync();
        Task<List<SubDivisionDto>> GetAllActiveDtoAsync();
        Task<List<SubDivisionDto>> GetAllDtoByLeadDivisionIdAsync(Guid id);
    }
}
