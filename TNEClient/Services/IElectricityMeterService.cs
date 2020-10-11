using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TNEClient.Dtos;

namespace TNEClient.Services
{
    public interface IElectricityMeterService
    {
        Task<List<ElectricityMeterDto>> GetAllAsync();
        Task<List<ElectricityMeterDto>> GetAllByStatusAsync(Status status);
        Task<ElectricityMeterDto> GetAsync(Guid id);
        Task<ElectricityMeterDto> CreateAsync(ElectricityMeterDto dto);
        Task<ElectricityMeterDto> UpdateAsync(ElectricityMeterDto dto);
        Task<bool> SetStatus(Guid id, Status status);
    }
}
