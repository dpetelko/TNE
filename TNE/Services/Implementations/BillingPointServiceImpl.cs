using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Data;
using TNE.Data.Exceptions;
using TNE.Dtos;
using TNE.Dtos.SearchFilters;
using TNE.Models;

namespace TNE.Services.Implementations
{
    public class BillingPointServiceImpl : IBillingPointService
    {
        private readonly IBillingPointRepository _repo;

        public BillingPointServiceImpl(IBillingPointRepository repo) => _repo = repo;

        public void CheckExistsById(Guid id) => _repo.CheckExistsById(id);

        public async Task<BillingPointDto> CreateAsync(BillingPointDto dto)
        {
            if (!dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must be empty for CREATE!");
            var entity = ConvertToEntity(dto);
            var result = await _repo.CreateAsync(entity);
            return new BillingPointDto(result);
        }


        public async Task<List<BillingPointDto>> GetAllDtoAsync() => await _repo.GetAllDtoAsync();

        public async Task<List<BillingPointDto>> GetAllDtoByControlPointIdAsync(Guid id) => await _repo.GetAllDtoByControlPointIdAsync(id);

        public async Task<List<BillingPointDto>> GetAllDtoByDeliveryPointIdAsync(Guid id) => await _repo.GetAllDtoByDeliveryPointIdAsync(id);

        public async Task<List<BillingPointDto>> GetAllDtoByFilterAsync(BillingPointFilter filter)
        {
            return filter.IsEmpty()
               ? await GetAllDtoAsync()
               : await _repo.GetAllDtoByFilterAsync(filter);
        }

        public BillingPoint GetById(Guid id) => _repo.GetById(id);

        public async Task<BillingPoint> GetByIdAsync(Guid id) => await _repo.GetByIdAsync(id);

        public async Task<BillingPointDto> GetDtoByIdAsync(Guid id) => await _repo.GetDtoByIdAsync(id);

        public bool IsFieldUnique(Guid id, string fieldName, object fieldValue)
        {
            return id.Equals(Guid.Empty)
                ? !_repo.ExistsByField(fieldName, fieldValue)
                : !_repo.ExistsByFieldAndNotId(id, fieldName, fieldValue);
        }

        public async Task<BillingPointDto> UpdateAsync(BillingPointDto dto)
        {
            if (dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must can't be empty for UPDATE!");
            CheckExistsById(dto.Id);
            var entity = ConvertToEntity(dto);
            return new BillingPointDto(await _repo.UpdateAsync(entity));
        }

        private BillingPoint ConvertToEntity(BillingPointDto dto)
        {
            var entity = new BillingPoint
            {
                Id = dto.Id,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                ControlPointId = dto.ControlPointId,
                DeliveryPointId = dto.DeliveryPointId
            };
            return entity;
        }
    }
}
