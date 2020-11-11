using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNE.Data;
using TNE.Data.Exceptions;
using TNE.Dtos;
using TNE.Dtos.SearchFilters;
using TNE.Models;

namespace TNE.Services.Implementations
{
    public class VoltageTransformerServiceImpl : IVoltageTransformerService
    {
        private readonly IVoltageTransformerRepository _repo;

        public VoltageTransformerServiceImpl(IVoltageTransformerRepository repo) => _repo = repo;

        public void CheckExistsById(Guid id) => _repo.CheckExistsById(id);

        public async Task<VoltageTransformerDto> CreateAsync(VoltageTransformerDto dto)
        {
            if (!dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must be empty for CREATE!");
            var entity = ConvertToEntity(dto);
            var result = await _repo.CreateAsync(entity);
            return new VoltageTransformerDto(result);
        }

        public async Task<List<VoltageTransformerDto>> GetAllDtoAsync() => await _repo.GetAllDtoAsync();

        public async Task<List<VoltageTransformerDto>> GetAllDtoByStatusAsync(Status status) => await _repo.GetAllDtoByStatusAsync(status);

        public VoltageTransformer GetById(Guid id) => _repo.GetById(id);

        public async Task<List<VoltageTransformerDto>> GetAllDtoByFilterAsync(DeviceCalibrationControlDto filter) => await _repo.GetAllDtoByFilterAsync(filter);


        public async Task<VoltageTransformer> GetByIdAsync(Guid id) => await _repo.GetByIdAsync(id);

        public async Task<VoltageTransformerDto> GetDtoByControlPointId(Guid id) => await _repo.GetDtoByControlPointId(id);

        public async Task<VoltageTransformerDto> GetDtoByIdAsync(Guid id) => await _repo.GetDtoByIdAsync(id);

        public bool IsFieldUnique(Guid id, string fieldName, object fieldValue)
        {
            return (id.Equals(Guid.Empty))
                ? !_repo.ExistsByField(fieldName, fieldValue)
                : !_repo.ExistsByFieldAndNotId(id, fieldName, fieldValue);
        }

        public async Task<bool> SetStatus(Guid id, Status newStatus) => await _repo.SetStatus(id, newStatus);

        public async Task<VoltageTransformerDto> UpdateAsync(VoltageTransformerDto dto)
        {
            if (dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must can't be empty for UPDATE!");
            CheckExistsById(dto.Id);
            var entity = ConvertToEntity(dto);
            return new VoltageTransformerDto(await _repo.UpdateAsync(entity));
        }

        private VoltageTransformer ConvertToEntity(VoltageTransformerDto dto)
        {
            return new VoltageTransformer
            {
                Id = dto.Id,
                Number = dto.Number,
                Type = dto.Type,
                LastVerificationDate = dto.LastVerificationDate,
                InterTestingPeriodInDays = dto.InterTestingPeriodInDays,
                Status = dto.Status,
                TransformationRate = dto.TransformationRate,
                ControlPointId = dto.ControlPointId
            };
        }
    }
}
