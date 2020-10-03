﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Dtos;
using TNE.Models;

namespace TNE.Data
{
    public interface IElectricityMeterRepository : IRepository<ElectricityMeter>
    {
        Task<bool> SetStatus(Guid id, Status newStatus);
        Task<ElectricityMeterDto> GetDtoByIdAsync(Guid Id);
        Task<List<ElectricityMeterDto>> GetAllDtoAsync();
        Task<List<ElectricityMeterDto>> GetAllDtoByStatusAsync(Status status);
    }
}
