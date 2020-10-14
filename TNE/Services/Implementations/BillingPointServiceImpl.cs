using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNE.Data;
using TNE.Data.Exceptions;
using TNE.Dtos;
using TNE.Models;

namespace TNE.Services.Implementations
{
    public class BillingPointServiceImpl : IBillingPointService
    {
        private readonly IBillingPointRepository _repo;
        private readonly IControlPointRepository _controlPointRepository;
        private readonly IDeliveryPointRepository _deliveryPointRepository;

        public BillingPointServiceImpl(
            IBillingPointRepository repo,
            IControlPointRepository controlPointRepository,
            IDeliveryPointRepository deliveryPointRepository)
        {
            _repo = repo;
            _controlPointRepository = controlPointRepository;
            _deliveryPointRepository = deliveryPointRepository;
        }

        public void CheckExistsById(Guid id)
        {
            _repo.CheckExistsById(id);
        }

        public async Task<BillingPointDto> CreateAsync(BillingPointDto dto)
        {
            if (!dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must be empty for CREATE!");
            var entity = ConvertToEntity(dto);
            var result = await _repo.CreateAsync(entity);
            return new BillingPointDto(result);
        }

        public async Task<List<BillingPointDto>> GetAllDtoAsync()
        {
            return await _repo.GetAllDtoAsync();
        }

        public BillingPoint GetById(Guid id)
        {
            return _repo.GetById(id);
        }

        public async Task<BillingPoint> GetByIdAsync(Guid id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<BillingPointDto> GetDtoByIdAsync(Guid id)
        {
            return await _repo.GetDtoByIdAsync(id);
        }

        public bool IsFieldUnique(Guid id, string fieldName, object fieldValue)
        {
            return (id.Equals(Guid.Empty))
                ? _repo.ExistsByField(fieldName, fieldValue)
                : _repo.ExistsByFieldAndNotId(id, fieldName, fieldValue);
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
