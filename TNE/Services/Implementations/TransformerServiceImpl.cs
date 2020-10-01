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
    public class TransformerServiceImpl : ITransformerService
    {
        private readonly ITransformerRepository _repo;
        //private readonly IControlPointService _controlPointService;

        public TransformerServiceImpl(ITransformerRepository repo) { _repo = repo; }

        public void CheckExistsById(Guid id)
        {
            _repo.CheckExistsById(id);
        }

        public async Task<TransformerDto> CreateAsync(TransformerDto dto)
        {
            if (!dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must be empty for CREATE!");
            var entity = ConvertToEntity(dto);
            var result = await _repo.CreateAsync(entity);
            return new TransformerDto(result);
        }

        public async Task<List<TransformerDto>> GetAllDtoAsync()
        {
            return await _repo.GetAllDtoAsync();
        }

        public async Task<List<TransformerDto>> GetAllDtoByStatusAsync(Status status)
        {
            return await _repo.GetAllDtoByStatusAsync(status);
        }

        public Transformer GetById(Guid id)
        {
            return _repo.GetById(id);
        }

        public async Task<Transformer> GetByIdAsync(Guid id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<TransformerDto> GetDtoByIdAsync(Guid id)
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

        public async Task<TransformerDto> UpdateAsync(TransformerDto dto)
        {
            if (dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must can't be empty for UPDATE!");
            CheckExistsById(dto.Id);
            var entity = ConvertToEntity(dto);
            return new TransformerDto(await _repo.UpdateAsync(entity));
        }

        private Transformer ConvertToEntity(TransformerDto dto)
        {
            var entity = new Transformer();
            if (!dto.Id.Equals(Guid.Empty))
            {
                entity = _repo.GetById(dto.Id);
            }
            entity.Number = dto.Number;
            entity.Type = dto.Type;
            entity.VerificationDate = dto.VerificationDate;
            entity.Status = dto.Status;
            entity.TransformationRate = dto.TransformationRate;
            //if (!entity.ControlPointId.Equals(dto.ControlPointId))
            //{
            //    entity.ControlPoint = _controlPointService.GetById(dto.ControlPointId);
            //}
            return entity;
        }
    }
}
