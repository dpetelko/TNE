using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNEClient.Data;
using TNEClient.Dtos;

namespace TNEClient.Services.Implementations
{
    public class SubDivisionServiceImpl : ISubDivisionService
    {
        private readonly ISubDivisionRepository _repo;

        public SubDivisionServiceImpl(ISubDivisionRepository repo) { _repo = repo; }

        public async Task<SubDivisionDto> CreateAsync(SubDivisionDto dto) => await _repo.CreateAsync(dto);

        public async Task<bool> DeleteAsync(Guid id) => await _repo.DeleteAsync(id);

        public async Task<List<SubDivisionDto>> GetAllActiveAsync() => await _repo.GetAllActiveAsync();

        public async Task<List<SubDivisionDto>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<SubDivisionDto> GetAsync(Guid id) => await _repo.GetAsync(id);

        public async Task<SubDivisionDto> UpdateAsync(SubDivisionDto dto) => await _repo.UpdateAsync(dto);

        public async Task<bool> UndeleteAsync(Guid id) => await _repo.UndeleteAsync(id);
    }
}
