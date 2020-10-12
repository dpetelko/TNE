using Serilog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TNEClient.Data;
using TNEClient.Dtos;

namespace TNEClient.Services.Implementations
{
    public class ElectricityMeterServiceImpl : IElectricityMeterService
    {
        private readonly IElectricityMeterRepository _repo;

        public ElectricityMeterServiceImpl(IElectricityMeterRepository repo) { _repo = repo; }

        public async Task<ElectricityMeterDto> CreateAsync(ElectricityMeterDto dto)
        {
            return await _repo.CreateAsync(dto);
        }

        public async Task<List<ElectricityMeterDto>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<List<ElectricityMeterDto>> GetAllByStatusAsync(Status status)
        {
            return await _repo.GetAllByStatusAsync(status);
        }

        public async Task<ElectricityMeterDto> GetAsync(Guid id)
        {
            return await _repo.GetAsync(id);
        }

        public async Task<ElectricityMeterDto> UpdateAsync(ElectricityMeterDto dto)
        {
            return await _repo.UpdateAsync(dto);
        }

        public async Task<bool> SetStatus(Guid id, Status status)
        {
            return await _repo.SetStatus(id, status);
        }

        public async Task<ElectricityMeterDto> GetDtoByControlPointId(Guid id)
        {
            return await _repo.GetByControlPointIdAsync(id);
        }
    }
}
