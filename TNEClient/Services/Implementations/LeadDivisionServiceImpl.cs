using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TNEClient.Data;
using TNEClient.Dtos;

namespace TNEClient.Services.Implementations
{
    public class LeadDivisionServiceImpl : ILeadDivisionService
    {
        private readonly ILeadDivisionRepository _repo;

        public LeadDivisionServiceImpl(ILeadDivisionRepository repo) { _repo = repo; }

        public async Task<HttpResponseMessage> CreateAsync(LeadDivisionDto dto) => await _repo.CreateAsync(dto);

        public async Task<bool> DeleteAsync(Guid id) => await _repo.DeleteAsync(id);

        public async Task<List<LeadDivisionDto>> GetAllActiveAsync() => await _repo.GetAllActiveAsync();

        public async Task<List<LeadDivisionDto>> GetAllAsync() => await _repo.GetAllAsync();

        public Task<LeadDivisionDto> GetAsync(Guid id) => _repo.GetAsync(id);

        public async Task<LeadDivisionDto> UpdateAsync(LeadDivisionDto dto) => await _repo.UpdateAsync(dto);

        public async Task<bool> UndeleteAsync(Guid id) => await _repo.UndeleteAsync(id);
    }
}
