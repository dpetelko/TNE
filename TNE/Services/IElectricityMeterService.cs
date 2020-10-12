using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Dtos;
using TNE.Models;

namespace TNE.Services
{
    public interface IElectricityMeterService : IService<ElectricityMeter>
    {
        Task<bool> SetStatus(Guid id, Status newStatus);
        Task<ElectricityMeterDto> GetDtoByIdAsync(Guid id);
        Task<List<ElectricityMeterDto>> GetAllDtoAsync();
        Task<ElectricityMeterDto> CreateAsync(ElectricityMeterDto dto);
        Task<ElectricityMeterDto> UpdateAsync(ElectricityMeterDto dto);
        Task<List<ElectricityMeterDto>> GetAllDtoByStatusAsync(Status status);
        Task<ElectricityMeterDto> GetDtoByControlPointId(Guid id);
    }
}