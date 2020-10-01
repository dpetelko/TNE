﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Dtos;
using TNE.Models;

namespace TNE.Data
{
    public interface ICurrentTransformerRepository : IRepository<CurrentTransformer>
    {
        Task<bool> SetStatus(Guid id, Status newStatus);
        Task<CurrentTransformerDto> GetDtoByIdAsync(Guid Id);
        Task<List<CurrentTransformerDto>> GetAllDtoAsync();
        Task<List<CurrentTransformerDto>> GetAllDtoByStatusAsync(Status status);
    }
}
