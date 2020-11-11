using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNEClient.Data;
using TNEClient.Dtos;
using TNEClient.Dtos.SearchFilters;

namespace TNEClient.Services.Implementations
{
    public class CurrentTransformerServiceImpl : ICurrentTransformerService
    {
        private readonly ICurrentTransformerRepository _repo;

        public CurrentTransformerServiceImpl(ICurrentTransformerRepository repo) { _repo = repo; }

        public async Task<CurrentTransformerDto> CreateAsync(CurrentTransformerDto dto) => await _repo.CreateAsync(dto);

        public async Task<List<CurrentTransformerDto>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<List<CurrentTransformerDto>> GetAllByStatusAsync(Status status) => await _repo.GetAllByStatusAsync(status);

        public async Task<CurrentTransformerDto> GetAsync(Guid id) => await _repo.GetAsync(id);

        public async Task<CurrentTransformerDto> UpdateAsync(CurrentTransformerDto dto) => await _repo.UpdateAsync(dto);

        public async Task<bool> SetStatus(Guid id, Status status) => await _repo.SetStatus(id, status);

        public async Task<CurrentTransformerDto> GetDtoByControlPointId(Guid id) => await _repo.GetByControlPointIdAsync(id);

        public async Task<List<CurrentTransformerDto>> GetAllDtoByFilterAsync(DeviceCalibrationControlDto filter) => await _repo.GetAllDtoByFilterAsync(filter);
    }
}
