using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNEClient.Data;
using TNEClient.Dtos;

namespace TNEClient.Services.Implementations
{
    public class ProviderServiceImpl : IProviderService
    {
        private readonly IProviderRepository _repo;

        public ProviderServiceImpl(IProviderRepository repo) { _repo = repo; }

        public async Task<ProviderDto> CreateAsync(ProviderDto dto) => await _repo.CreateAsync(dto);

        public async Task<bool> DeleteAsync(Guid id) => await _repo.DeleteAsync(id);

        public async Task<List<ProviderDto>> GetAllActiveAsync() => await _repo.GetAllActiveAsync();

        public async Task<List<ProviderDto>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<ProviderDto> GetAsync(Guid id) => await _repo.GetAsync(id);

        public async Task<ProviderDto> UpdateAsync(ProviderDto dto) => await _repo.UpdateAsync(dto);

        public async Task<bool> UndeleteAsync(Guid id) => await _repo.UndeleteAsync(id);
    }
}
