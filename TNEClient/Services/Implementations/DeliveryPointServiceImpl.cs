using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNEClient.Data;
using TNEClient.Dtos;

namespace TNEClient.Services.Implementations
{
    public class DeliveryPointServiceImpl : IDeliveryPointService
    {
        private readonly IDeliveryPointRepository _repo;

        public DeliveryPointServiceImpl(IDeliveryPointRepository repo) => _repo = repo;

        public async Task<DeliveryPointDto> CreateAsync(DeliveryPointDto dto) => await _repo.CreateAsync(dto);

        public async Task<bool> DeleteAsync(Guid id) => await _repo.DeleteAsync(id);

        public async Task<List<DeliveryPointDto>> GetAllActiveAsync() => await _repo.GetAllActiveAsync();

        public async Task<List<DeliveryPointDto>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<DeliveryPointDto> GetAsync(Guid id) => await _repo.GetAsync(id);

        public async Task<DeliveryPointDto> UpdateAsync(DeliveryPointDto dto) => await _repo.UpdateAsync(dto);

        public async Task<bool> UndeleteAsync(Guid id) => await _repo.UndeleteAsync(id);

        public async Task<List<DeliveryPointDto>> GetAllDtoByProviderIdAsync(Guid id) => await _repo.GetByProviderAsync(id);
    }
}
