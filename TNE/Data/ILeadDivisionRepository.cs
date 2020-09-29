﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Dto.LeadDivisions;
using TNE.Models;

namespace TNE.Data
{
    public interface ILeadDivisionRepository : IRepository<LeadDivision>
    {
        Task<LeadDivisionDto> GetDtoByIdAsync(Guid Id);
        Task<List<LeadDivisionDto>> GetAllDtoAsync();
        Task<List<LeadDivisionDto>> GetAllActiveDtoAsync();

    }
}
