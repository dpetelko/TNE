using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNEClient.Data;
using TNEClient.Dtos;

namespace TNEClient.Services.Implementations
{
    public class BillingPointServiceImpl : IBillingPointService
    {
        private readonly IBillingPointRepository _repo;

        public BillingPointServiceImpl(IBillingPointRepository repo) => _repo = repo;

        public async Task<BillingPointDto> CreateAsync(BillingPointDto dto) => await _repo.CreateAsync(dto);

        public async Task<List<BillingPointDto>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<List<BillingPointDto>> GetAllDtoByControlPointIdAsync(Guid id) => await _repo.GetByControlPointAsync(id);

        public async Task<List<BillingPointDto>> GetAllDtoByDeliveryPointIdAsync(Guid id) => await _repo.GetByControlPointAsync(id);

        public async Task<BillingPointDto> GetAsync(Guid id) => await _repo.GetAsync(id);

        public async Task<BillingPointDto> UpdateAsync(BillingPointDto dto) => await _repo.UpdateAsync(dto);

    }
}
