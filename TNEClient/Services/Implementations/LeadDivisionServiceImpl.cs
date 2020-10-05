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

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LeadDivisionDto>> GetAllActiveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<LeadDivisionDto>> GetAllAsync()
        {
            return _repo.GetAllAsync();
        }

        public Task<LeadDivisionDto> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<LeadDivisionDto> ReplaceAsync(LeadDivisionDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UndeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
