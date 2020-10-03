using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNE.Data.Exceptions;
using TNE.Dtos;
using TNE.Models;

namespace TNE.Services.Implementations
{
    public class ElectricityMeterServiceImpl : IElectricityMeterService
    {
        private readonly IElectricityMeterRepository _repo;
        private readonly IControlPointService _controlPointService;

        public ElectricityMeterServiceImpl(IElectricityMeterRepository repo, IControlPointService controlPointService)
        {
            _repo = repo;
            _controlPointService = controlPointService;
        }

        public void CheckExistsById(Guid id)
        {
            _repo.CheckExistsById(id);
        }

        public async Task<ElectricityMeterDto> CreateAsync(ElectricityMeterDto dto)
        {
            if (!dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must be empty for CREATE!");
            var entity = ConvertToEntity(dto);
            var result = await _repo.CreateAsync(entity);
            return new ElectricityMeterDto(result);
        }

        public async Task<List<ElectricityMeterDto>> GetAllDtoAsync()
        {
            return await _repo.GetAllDtoAsync();
        }

        public async Task<List<ElectricityMeterDto>> GetAllDtoByStatusAsync(Status status)
        {
            return await _repo.GetAllDtoByStatusAsync(status);
        }

        public ElectricityMeter GetById(Guid id)
        {
            return _repo.GetById(id);
        }

        public async Task<ElectricityMeter> GetByIdAsync(Guid id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<ElectricityMeterDto> GetDtoByIdAsync(Guid id)
        {
            return await _repo.GetDtoByIdAsync(id);
        }

        public bool IsFieldUnique(Guid id, string fieldName, object fieldValue)
        {
            return (id.Equals(Guid.Empty))
                ? _repo.ExistsByField(fieldName, fieldValue)
                : _repo.ExistsByFieldAndNotId(id, fieldName, fieldValue);
        }

        public async Task<bool> SetStatus(Guid id, Status newStatus)
        {
            return await _repo.SetStatus(id, newStatus);
        }

        public async Task<ElectricityMeterDto> UpdateAsync(ElectricityMeterDto dto)
        {
            if (dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must can't be empty for UPDATE!");
            CheckExistsById(dto.Id);
            var entity = ConvertToEntity(dto);
            return new ElectricityMeterDto(await _repo.UpdateAsync(entity));
        }

        private ElectricityMeter ConvertToEntity(ElectricityMeterDto dto)
        {
            var entity = new ElectricityMeter();
            if (!dto.Id.Equals(Guid.Empty))
            {
                entity = _repo.GetById(dto.Id);
            }
            entity.Number = dto.Number;
            entity.Type = dto.Type;
            entity.VerificationDate = dto.VerificationDate;
            entity.Status = dto.Status;
            if (!Equals(entity.ControlPoint.Id, dto.ControlPointId))
            {
                entity.ControlPoint = _controlPointService.GetById(dto.ControlPointId);
            }
            return entity;
        }
    }
}
