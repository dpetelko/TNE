using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Data;
using TNE.Data.Exceptions;
using TNE.Dtos;
using TNE.Models;

namespace TNE.Services.Implementations
{
    public class ControlPointServiceImpl : IControlPointService
    {
        private readonly IControlPointRepository _repo;
        private readonly IProviderService _providerService;
        private readonly ICurrentTransformerService _currentTransformerService;
        private readonly IVoltageTransformerService _voltageTransformerService;
        private readonly IElectricityMeterService _electricityMeterService;

        public ControlPointServiceImpl(
            IControlPointRepository repo,
            IProviderService providerService,
            ICurrentTransformerService currentTransformerService,
            IVoltageTransformerService voltageTransformerService,
            IElectricityMeterService electricityMeterService)
        {
            _repo = repo;
            _providerService = providerService;
            _currentTransformerService = currentTransformerService;
            _voltageTransformerService = voltageTransformerService;
            _electricityMeterService = electricityMeterService;
        }

        public void CheckExistsById(Guid id) { _repo.CheckExistsById(id); }

        public async Task<ControlPointDto> CreateAsync(ControlPointDto dto)
        {
            if (!dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must be empty for CREATE!");
            var entity = ConvertToEntity(dto);
            var result = await _repo.CreateAsync(entity);
            return new ControlPointDto(result);
        }

        public async Task<bool> DeleteAsync(Guid id) { return await _repo.DeleteAsync(id); }

        public async Task<List<ControlPointDto>> GetAllActiveDtoAsync() { return await _repo.GetAllActiveDtoAsync(); }

        public async Task<List<ControlPointDto>> GetAllDtoAsync() { return await _repo.GetAllDtoAsync(); }

        public ControlPoint GetById(Guid id) { return _repo.GetById(id); }

        public async Task<ControlPoint> GetByIdAsync(Guid id) { return await _repo.GetByIdAsync(id); }

        public async Task<ControlPointDto> GetDtoByIdAsync(Guid id) { return await _repo.GetDtoByIdAsync(id); }

        public bool IsFieldUnique(Guid id, string fieldName, object fieldValue)
        {
            return (id.Equals(Guid.Empty))
                ? _repo.ExistsByField(fieldName, fieldValue)
                : _repo.ExistsByFieldAndNotId(id, fieldName, fieldValue);
        }

        public async Task<bool> UndeleteAsync(Guid id) { return await _repo.UndeleteAsync(id); }

        public async Task<ControlPointDto> UpdateAsync(ControlPointDto dto)
        {
            if (dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must can't be empty for UPDATE!");
            CheckExistsById(dto.Id);
            var entity = ConvertToEntity(dto);
            return new ControlPointDto(await _repo.UpdateAsync(entity));
        }

        private ControlPoint ConvertToEntity(ControlPointDto dto)
        {
            var entity = new ControlPoint();
            if (!dto.Id.Equals(Guid.Empty))
            {
                entity = _repo.GetById(dto.Id);
            }
            entity.Name = dto.Name;
            entity.Deleted = dto.Deleted;
            if (!Equals(dto.CurrentTransformer.Id, entity.CurrentTransformerId))
            {
                entity.CurrentTransformer = _currentTransformerService.GetById(dto.CurrentTransformer.Id);
            }
            if (!Equals(entity.VoltageTransformerId, dto.VoltageTransformer.Id))
            {
                entity.VoltageTransformer = _voltageTransformerService.GetById(dto.VoltageTransformer.Id);
            }
            if (!Equals(entity.ElectricityMeterId, dto.ElectricityMeter.Id))
            {
                entity.ElectricityMeter = _electricityMeterService.GetById(dto.VoltageTransformer.Id);
            }
            return entity;
        }
    }
}
