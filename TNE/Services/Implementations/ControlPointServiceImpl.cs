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
        private readonly ICurrentTransformerRepository _currentTransformerRepository;
        private readonly IVoltageTransformerRepository _voltageTransformerRepository;
        private readonly IElectricityMeterRepository _electricityMeterRepository;

        public ControlPointServiceImpl(IControlPointRepository repo,
            ICurrentTransformerRepository currentTransformerRepository,
            IVoltageTransformerRepository voltageTransformerRepository,
            IElectricityMeterRepository electricityMeterRepository)
        {
            _repo = repo;
            _currentTransformerRepository = currentTransformerRepository;
            _voltageTransformerRepository = voltageTransformerRepository;
            _electricityMeterRepository = electricityMeterRepository;
        }

        public void CheckExistsById(Guid id)
        {
            _repo.CheckExistsById(id);
        }

        public async Task<ControlPointDto> CreateAsync(ControlPointDto dto)
        {
            if (!dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must be empty for CREATE!");
            var entity = ConvertToEntity(dto);
            var result = await _repo.CreateAsync(entity);
            return await ConvertToDto(result);
        }

        public async Task<ControlPointDto> UpdateAsync(ControlPointDto dto)
        {
            var entity = ConvertToEntity(dto);
            var result = await _repo.UpdateAsync(entity);
            return await ConvertToDto(result);
        }

        public async Task<bool> DeleteAsync(Guid id) => await _repo.DeleteAsync(id);

        public async Task<List<ControlPointDto>> GetAllActiveDtoAsync()
        {
            var list = await _repo.GetAllActiveDtoAsync();
            var newList = new List<ControlPointDto>();
            foreach (var item in list)
            {
                newList.Add(await AddDevices(item));
            }
            return newList;
        }

        public async Task<List<ControlPointDto>> GetAllDtoAsync()
        {
            var list = await _repo.GetAllDtoAsync();
            var newList = new List<ControlPointDto>();
            foreach (var item in list)
            {
                newList.Add(await AddDevices(item));
            }
            return newList;
        }

        public async Task<List<ControlPointDto>> GetAllDtoByProviderIdAsync(Guid id)
        {
            var list = await _repo.GetAllDtoByProviderIdAsync(id);
            var newList = new List<ControlPointDto>();
            foreach (var item in list)
            {
                newList.Add(await AddDevices(item));
            }
            return newList;
        }

        public ControlPoint GetById(Guid id) => _repo.GetById(id);

        public async Task<ControlPoint> GetByIdAsync(Guid id) => await _repo.GetByIdAsync(id);

        public async Task<ControlPointDto> GetDtoByIdAsync(Guid id)
        {
            return await AddDevices(await _repo.GetDtoByIdAsync(id));
        }

        public bool IsFieldUnique(Guid id, string fieldName, object fieldValue)
        {
            return (id.Equals(Guid.Empty))
                ? !_repo.ExistsByField(fieldName, fieldValue)
                : !_repo.ExistsByFieldAndNotId(id, fieldName, fieldValue);
        }

        public async Task<bool> UndeleteAsync(Guid id) => await _repo.UndeleteAsync(id);

        private static ControlPoint ConvertToEntity(ControlPointDto dto)
        {
            return new ControlPoint
            {
                Id = dto.Id,
                Name = dto.Name,
                Deleted = dto.Deleted,
                ProviderId = dto.ProviderId,
                CurrentTransformerId = dto.CurrentTransformerId,
                VoltageTransformerId = dto.VoltageTransformerId,
                ElectricityMeterId = dto.ElectricityMeterId
            };
        }

        private async Task<ControlPointDto> ConvertToDto(ControlPoint entity)
        {
            var currentTransformer = await _currentTransformerRepository.GetDtoByControlPointId(entity.Id);
            var voltageTransformer = await _voltageTransformerRepository.GetDtoByControlPointId(entity.Id);
            var electricityMeter = await _electricityMeterRepository.GetDtoByControlPointId(entity.Id);
            return new ControlPointDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Deleted = entity.Deleted,

                ProviderId = entity.ProviderId,
                ProviderName = entity.Provider.Name,

                ElectricityMeterId = electricityMeter.Id,
                ElectricityMeterNumber = electricityMeter.Number,
                ElectricityMeterType = electricityMeter.Type,
                ElectricityMeterLastVerificationDate = electricityMeter.LastVerificationDate,

                CurrentTransformerId = currentTransformer.Id,
                CurrentTransformerNumber = currentTransformer.Number,
                CurrentTransformerType = currentTransformer.Type,
                CurrentTransformerTransformationRate = currentTransformer.TransformationRate,
                CurrentTransformerLastVerificationDate = currentTransformer.LastVerificationDate,

                VoltageTransformerId = voltageTransformer.Id,
                VoltageTransformerNumber = voltageTransformer.Number,
                VoltageTransformerType = voltageTransformer.Type,
                VoltageTransformerTransformationRate = voltageTransformer.TransformationRate,
                VoltageTransformerLastVerificationDate = voltageTransformer.LastVerificationDate
            };
        }

        private async Task<ControlPointDto> AddDevices(ControlPointDto entity)
        {
            var currentTransformer = await _currentTransformerRepository.GetDtoByControlPointId(entity.Id);
            var voltageTransformer = await _voltageTransformerRepository.GetDtoByControlPointId(entity.Id);
            var electricityMeter = await _electricityMeterRepository.GetDtoByControlPointId(entity.Id);

            entity.ElectricityMeterId = electricityMeter.Id;
            entity.ElectricityMeterNumber = electricityMeter.Number;
            entity.ElectricityMeterType = electricityMeter.Type;
            entity.ElectricityMeterLastVerificationDate = electricityMeter.LastVerificationDate;

            entity.CurrentTransformerId = currentTransformer.Id;
            entity.CurrentTransformerNumber = currentTransformer.Number;
            entity.CurrentTransformerType = currentTransformer.Type;
            entity.CurrentTransformerTransformationRate = currentTransformer.TransformationRate;
            entity.CurrentTransformerLastVerificationDate = currentTransformer.LastVerificationDate;

            entity.VoltageTransformerId = voltageTransformer.Id;
            entity.VoltageTransformerNumber = voltageTransformer.Number;
            entity.VoltageTransformerType = voltageTransformer.Type;
            entity.VoltageTransformerTransformationRate = voltageTransformer.TransformationRate;
            entity.VoltageTransformerLastVerificationDate = voltageTransformer.LastVerificationDate;
            return entity;
        }
    }
}