using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Data;
using TNE.Data.Exceptions;
using TNE.Dtos;
using TNE.Models;

namespace TNE.Services.Implementations
{
    public class DeliveryPointServiceImpl : IDeliveryPointService
    {
        private readonly IDeliveryPointRepository _repo;

        public DeliveryPointServiceImpl(IDeliveryPointRepository repo) => _repo = repo;

        public void CheckExistsById(Guid id) => _repo.CheckExistsById(id);

        public async Task<DeliveryPointDto> CreateAsync(DeliveryPointDto dto)
        {
            if (!dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must be empty for CREATE!");
            var result = await _repo.CreateAsync(new DeliveryPoint(dto));
            return new DeliveryPointDto(result);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            CheckExistsById(id);
            return await _repo.DeleteAsync(id);
        }

        public async Task<List<DeliveryPointDto>> GetAllActiveDtoAsync() => await _repo.GetAllActiveDtoAsync();

        public async Task<List<DeliveryPointDto>> GetAllDtoAsync() => await _repo.GetAllDtoAsync();

        public async Task<List<DeliveryPointDto>> GetAllDtoByProviderIdAsync(Guid id) => await _repo.GetAllDtoByProviderIdAsync(id);

        public DeliveryPoint GetById(Guid id)
        {
            CheckExistsById(id);
            return _repo.GetById(id);
        }

        public async Task<DeliveryPoint> GetByIdAsync(Guid id)
        {
            CheckExistsById(id);
            return await _repo.GetByIdAsync(id);
        }

        public async Task<DeliveryPointDto> GetDtoByIdAsync(Guid id)
        {
            CheckExistsById(id);
            return await _repo.GetDtoByIdAsync(id);
        }

        public bool IsFieldUnique(Guid id, string fieldName, object fieldValue)
        {
            return (id.Equals(Guid.Empty))
                ? !_repo.ExistsByField(fieldName, fieldValue)
                : !_repo.ExistsByFieldAndNotId(id, fieldName, fieldValue);
        }

        public async Task<bool> UndeleteAsync(Guid id)
        {
            CheckExistsById(id);
            return await _repo.UndeleteAsync(id);
        }

        public async Task<DeliveryPointDto> UpdateAsync(DeliveryPointDto dto)
        {
            if (dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must can't be empty for UPDATE!");
            CheckExistsById(dto.Id);
            var result = await _repo.UpdateAsync(new DeliveryPoint(dto));
            return new DeliveryPointDto(result);
        }
    }
}
