using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Serilog;
using TNE.Data;
using TNE.Data.Exceptions;
using TNE.Dtos;
using TNE.Dtos.SearchFilters;
using TNE.Models;

namespace TNE.Services.Implementations
{
    public class ControlPointServiceImpl : IControlPointService
    {
        private readonly IControlPointRepository _repo;
        private readonly IProviderService _providerService;
        private readonly ICurrentTransformerRepository _currentTransformerRepository;
        private readonly IVoltageTransformerRepository _voltageTransformerRepository;
        private readonly IElectricityMeterRepository _electricityMeterRepository;

        public ControlPointServiceImpl(IControlPointRepository repo, IProviderService providerService, ICurrentTransformerRepository currentTransformerRepository, IVoltageTransformerRepository voltageTransformerRepository, IElectricityMeterRepository electricityMeterRepository)
        {
            _repo = repo;
            _providerService = providerService;
            _currentTransformerRepository = currentTransformerRepository;
            _voltageTransformerRepository = voltageTransformerRepository;
            _electricityMeterRepository = electricityMeterRepository;
        }

        public void CheckExistsById(Guid id) { _repo.CheckExistsById(id); }

        public async Task<ControlPointDto> CreateAsync(ControlPointDto dto)
        {
            if (!dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must be empty for CREATE!");
            var entity = ConvertToEntity(dto);
            var result = await _repo.CreateAsync(entity);
            return new ControlPointDto(result);
        }
        
        // public async Task<ControlPointDto> CreateAsync(ControlPointDto dto)
        // {
        //     if (!dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must be empty for CREATE!");
        //     var entity = ConvertToEntity(dto);
        //     var currentTransformer = await _currentTransformerRepository.GetByIdAsyncWithTracking((Guid) dto.CurrentTransformerId);
        //     var voltageTransformer = await _voltageTransformerRepository.GetByIdAsyncWithTracking((Guid) dto.VoltageTransformerId);
        //     var electricityMeter = await _electricityMeterRepository.GetByIdAsyncWithTracking((Guid) dto.ElectricityMeterId);
        //     currentTransformer.Status = Status.InWork;
        //     voltageTransformer.Status = Status.InWork;
        //     electricityMeter.Status = Status.InWork;
        //     entity.CurrentTransformer = currentTransformer;
        //     entity.VoltageTransformer = voltageTransformer;
        //     entity.ElectricityMeter = electricityMeter;
        //     var result = await _repo.CreateAsync(entity);
        //     return new ControlPointDto(result);
        // }
        
        public async Task<ControlPointDto> UpdateAsync(ControlPointDto dto)
        {
            if (dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must can't be empty for UPDATE!");
            CheckExistsById(dto.Id);
            var entity = ConvertToEntity(dto);
            return new ControlPointDto(await _repo.UpdateAsync(entity));
        }
        
        // public async Task<ControlPointDto> UpdateAsync(ControlPointDto dto)
        // {
        //     
        //     //TODO Need to Refactoring...
        //     
        //     if (dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must can't be empty for UPDATE!");
        //     CheckExistsById(dto.Id);
        //     var oldDto = await _repo.GetDtoByIdAsync(dto.Id);
        //     var entity = new ControlPoint();//_repo.GetById(dto.Id);
        //     Log.Error("Entity is ... {entity}", entity);
        //     Log.Error("Start matching...");
        //     entity.CurrentTransformerId = dto.CurrentTransformerId;
        //     entity.VoltageTransformerId = dto.VoltageTransformerId;
        //     entity.ElectricityMeterId = dto.ElectricityMeterId;
        //     if (oldDto.CurrentTransformerId != dto.CurrentTransformerId)
        //     {
        //         Log.Error("Changing CurrentTransformer");
        //         var newCurrentTransformer = await _currentTransformerRepository.GetByIdAsyncWithTracking((Guid) dto.CurrentTransformerId);
        //         newCurrentTransformer.Status = Status.InWork;
        //         var oldCurrentTransformer = await _currentTransformerRepository.GetByIdAsyncWithTracking((Guid) oldDto.CurrentTransformerId);
        //         oldCurrentTransformer.Status = Status.InStorage;
        //         entity.CurrentTransformerId = dto.CurrentTransformerId;
        //         //entity.CurrentTransformer = newCurrentTransformer;
        //     }
        //
        //     if (oldDto.VoltageTransformerId != dto.VoltageTransformerId)
        //     {
        //         Log.Error("Changing VoltageTransformer");
        //         var newVoltageTransformer = await _voltageTransformerRepository.GetByIdAsyncWithTracking((Guid) dto.VoltageTransformerId);
        //         newVoltageTransformer.Status = Status.InWork;
        //         var oldVoltageTransformer = await _voltageTransformerRepository.GetByIdAsyncWithTracking((Guid) oldDto.VoltageTransformerId);
        //         oldVoltageTransformer.Status = Status.InStorage;
        //         entity.VoltageTransformerId = dto.VoltageTransformerId;
        //         //entity.VoltageTransformer = newVoltageTransformer;
        //     }
        //
        //     if (oldDto.ElectricityMeterId != dto.ElectricityMeterId)
        //     {
        //         Log.Error("Changing ElectricityTransformer");
        //         var newElectricityMeter = await _electricityMeterRepository.GetByIdAsyncWithTracking((Guid) dto.ElectricityMeterId);
        //         newElectricityMeter.Status = Status.InWork;
        //         var oldElectricityMeter = await _electricityMeterRepository.GetByIdAsyncWithTracking((Guid) oldDto.ElectricityMeterId);
        //         oldElectricityMeter.Status = Status.InStorage;
        //         entity.ElectricityMeterId = dto.ElectricityMeterId;
        //         //entity.ElectricityMeter = newElectricityMeter;
        //     }
        //
        //     entity.Id = dto.Id;
        //     entity.Name = dto.Name;
        //     entity.Deleted = dto.Deleted;
        //     entity.ProviderId = dto.ProviderId;
        //     
        //     return new ControlPointDto(await _repo.UpdateAsync(entity));
        //     //return new ControlPointDto();
        //}

        public async Task<bool> DeleteAsync(Guid id) => await _repo.DeleteAsync(id);

        public async Task<List<ControlPointDto>> GetAllActiveDtoAsync() => await _repo.GetAllActiveDtoAsync();

        public async Task<List<ControlPointDto>> GetAllDtoAsync() => await _repo.GetAllDtoAsync();

        public async Task<List<ControlPointDto>> GetAllDtoByProviderIdAsync(Guid id) => await _repo.GetAllDtoByProviderIdAsync(id);

        public ControlPoint GetById(Guid id) => _repo.GetById(id);

        public async Task<ControlPoint> GetByIdAsync(Guid id) => await _repo.GetByIdAsync(id);

        public async Task<ControlPointDto> GetDtoByIdAsync(Guid id) => await _repo.GetDtoByIdAsync(id);

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
    }
}
