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
    public class VoltageTransformerServiceImpl : IVoltageTransformerService
    {
        private readonly IVoltageTransformerRepository _repo;
        private readonly IControlPointRepository _controlPointRepository;

        public VoltageTransformerServiceImpl(IVoltageTransformerRepository repo, IControlPointRepository controlPointRepository)
        {
            _repo = repo;
            _controlPointRepository = controlPointRepository;
        }

        public void CheckExistsById(Guid id)
        {
            _repo.CheckExistsById(id);
        }

        public async Task<VoltageTransformerDto> CreateAsync(VoltageTransformerDto dto)
        {
            if (!dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must be empty for CREATE!");
            var entity = ConvertToEntity(dto);
            var result = await _repo.CreateAsync(entity);
            return new VoltageTransformerDto(result);
        }

        public async Task<List<VoltageTransformerDto>> GetAllDtoAsync()
        {
            return await _repo.GetAllDtoAsync();
        }

        public async Task<List<VoltageTransformerDto>> GetAllDtoByStatusAsync(Status status)
        {
            return await _repo.GetAllDtoByStatusAsync(status);
        }

        public VoltageTransformer GetById(Guid id)
        {
            return _repo.GetById(id);
        }

        public async Task<VoltageTransformer> GetByIdAsync(Guid id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<VoltageTransformerDto> GetDtoByIdAsync(Guid id)
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

        public async Task<VoltageTransformerDto> UpdateAsync(VoltageTransformerDto dto)
        {
            if (dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must can't be empty for UPDATE!");
            CheckExistsById(dto.Id);
            var entity = ConvertToEntity(dto);
            return new VoltageTransformerDto(await _repo.UpdateAsync(entity));
        }

        private VoltageTransformer ConvertToEntity(VoltageTransformerDto dto)
        {
            var entity = new VoltageTransformer();
            if (!dto.Id.Equals(Guid.Empty))
            {
                entity = _repo.GetById(dto.Id);
            }
            entity.Number = dto.Number;
            entity.Type = dto.Type;
            entity.VerificationDate = dto.VerificationDate;
            entity.Status = dto.Status;
            entity.TransformationRate = dto.TransformationRate;
            if (!Equals(dto.ControlPointId, Guid.Empty) && !Equals(entity.ControlPointId, dto.ControlPointId))
            {
                entity.ControlPoint = _controlPointRepository.GetById(dto.ControlPointId);
            }
            else
            {
                entity.ControlPointId = dto.ControlPointId;
            }
            return entity;
        }
    }
}
