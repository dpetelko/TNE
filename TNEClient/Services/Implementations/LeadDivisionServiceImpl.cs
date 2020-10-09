using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNEClient.Data;
using TNEClient.Dtos;

namespace TNEClient.Services.Implementations
{
    public class LeadDivisionServiceImpl : ILeadDivisionService
    {
        private readonly ILeadDivisionRepository _repo;

        public LeadDivisionServiceImpl(ILeadDivisionRepository repo) { _repo = repo; }

        public Task<LeadDivisionDto> CreateAsync(LeadDivisionDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<List<LeadDivisionDto>> GetAllActiveAsync()
        {
            return await _repo.GetAllActiveAsync();
        }

        public async Task<List<LeadDivisionDto>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public Task<LeadDivisionDto> GetAsync(Guid id)
        {
            return _repo.GetAsync(id);
        }

        public Task<LeadDivisionDto> UpdateAsync(LeadDivisionDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UndeleteAsync(Guid id)
        {
            return await _repo.UndeleteAsync(id);
        }
    }
}
