using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNEClient.Data;
using TNEClient.Dtos;
using TNEClient.Dtos.SearchFilters;

namespace TNEClient.Services.Implementations
{
    public class ElectricityMeterServiceImpl : IElectricityMeterService
    {
        private readonly IElectricityMeterRepository _repo;

        public ElectricityMeterServiceImpl(IElectricityMeterRepository repo) => _repo = repo;

        public async Task<ElectricityMeterDto> CreateAsync(ElectricityMeterDto dto) => await _repo.CreateAsync(dto);

        public async Task<List<ElectricityMeterDto>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<List<ElectricityMeterDto>> GetAllByStatusAsync(Status status) => await _repo.GetAllByStatusAsync(status);

        public async Task<ElectricityMeterDto> GetAsync(Guid id) => await _repo.GetAsync(id);

        public async Task<ElectricityMeterDto> UpdateAsync(ElectricityMeterDto dto) => await _repo.UpdateAsync(dto);

        public async Task<bool> SetStatus(Guid id, Status status) => await _repo.SetStatus(id, status);

        public async Task<ElectricityMeterDto> GetDtoByControlPointId(Guid id) => await _repo.GetByControlPointIdAsync(id);

        public async Task<List<ElectricityMeterDto>> GetAllDtoByFilterAsync(DeviceCalibrationControlDto filter) => await _repo.GetAllDtoByFilterAsync(filter);
    }
}
