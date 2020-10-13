using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNEClient.Data;
using TNEClient.Dtos;

namespace TNEClient.Services.Implementations
{
    public class ControlPointServiceImpl : IControlPointService
    {
        private readonly IControlPointRepository _repo;

        public ControlPointServiceImpl(IControlPointRepository repo) => _repo = repo;

        public async Task<ControlPointDto> CreateAsync(ControlPointDto dto) => await _repo.CreateAsync(dto);

        public async Task<bool> DeleteAsync(Guid id) => await _repo.DeleteAsync(id);

        public async Task<List<ControlPointDto>> GetAllActiveAsync() => await _repo.GetAllActiveAsync();

        public async Task<List<ControlPointDto>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<ControlPointDto> GetAsync(Guid id) => await _repo.GetAsync(id);

        public async Task<ControlPointDto> UpdateAsync(ControlPointDto dto) => await _repo.UpdateAsync(dto);

        public async Task<bool> UndeleteAsync(Guid id) => await _repo.UndeleteAsync(id);

        public async Task<List<ControlPointDto>> GetAllDtoByProviderIdAsync(Guid id) => await _repo.GetByProviderAsync(id);
    }
}
