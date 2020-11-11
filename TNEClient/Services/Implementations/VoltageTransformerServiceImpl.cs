using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNEClient.Data;
using TNEClient.Dtos;
using TNEClient.Dtos.SearchFilters;

namespace TNEClient.Services.Implementations
{
    public class VoltageTransformerServiceImpl : IVoltageTransformerService
    {
        private readonly IVoltageTransformerRepository _repo;

        public VoltageTransformerServiceImpl(IVoltageTransformerRepository repo) { _repo = repo; }

        public async Task<VoltageTransformerDto> CreateAsync(VoltageTransformerDto dto) => await _repo.CreateAsync(dto);

        public async Task<List<VoltageTransformerDto>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<List<VoltageTransformerDto>> GetAllByStatusAsync(Status status) => await _repo.GetAllByStatusAsync(status);

        public async Task<VoltageTransformerDto> GetAsync(Guid id) => await _repo.GetAsync(id);

        public async Task<VoltageTransformerDto> UpdateAsync(VoltageTransformerDto dto) => await _repo.UpdateAsync(dto);

        public async Task<bool> SetStatus(Guid id, Status status) => await _repo.SetStatus(id, status);

        public async Task<VoltageTransformerDto> GetDtoByControlPointId(Guid id) => await _repo.GetByControlPointIdAsync(id);

        public async Task<List<VoltageTransformerDto>> GetAllDtoByFilterAsync(DeviceCalibrationControlDto filter) => await _repo.GetAllDtoByFilterAsync(filter);
    }
}
