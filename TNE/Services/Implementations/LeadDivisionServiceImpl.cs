using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Data;
using TNE.Data.Exceptions;
using TNE.Dto.LeadDivisions;
using TNE.Models;

namespace TNE.Services.Implementations
{
    public class LeadDivisionServiceImpl : ILeadDivisionService
    {
        private readonly ILeadDivisionRepository _repo;

        public LeadDivisionServiceImpl(ILeadDivisionRepository repo) { _repo = repo; }

        public async Task<LeadDivisionDto> CreateAsync(LeadDivisionDto dto)
        {
            if (!dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must be empty for CREATE!");
            var entity = ConvertToEntity(dto);
            var result = await _repo.CreateAsync(entity);
            return new LeadDivisionDto(result);
        }

        public void CheckExistsById(Guid id) { _repo.CheckExistsById(id); }

        public async Task<List<LeadDivisionDto>> GetAllDtoAsync() { return await _repo.GetAllDtoAsync(); }

        public async Task<LeadDivisionDto> GetDtoByIdAsync(Guid id)
        {
            CheckExistsById(id);
            return await _repo.GetDtoByIdAsync(id);
        }

        public async Task<LeadDivisionDto> UpdateAsync(LeadDivisionDto dto)
        {
            if (dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must can't be empty for UPDATE!");
            CheckExistsById(dto.Id);
            var entity = ConvertToEntity(dto);
            return new LeadDivisionDto(await _repo.UpdateAsync(entity));
        }

        public LeadDivision GetById(Guid id) { return _repo.GetById(id); }

        public async Task<LeadDivision> GetByIdAsync(Guid id) { return await _repo.GetByIdAsync(id); }

        public bool IsFieldUnique(Guid id, string fieldName, object fieldValue)
        {
            return (id.Equals(Guid.Empty))
                ? _repo.ExistsByField(fieldName, fieldValue)
                : _repo.ExistsByFieldAndNotId(id, fieldName, fieldValue);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<bool> UndeleteAsync(Guid id)
        {
            return await _repo.UndeleteAsync(id);
        }

        public async Task<List<LeadDivisionDto>> GetAllActiveDtoAsync()
        {
            return await _repo.GetAllActiveDtoAsync();
        }

        private LeadDivision ConvertToEntity(LeadDivisionDto dto)
        {
            var entity = new LeadDivision();
            if (!dto.Id.Equals(Guid.Empty))
            {
                entity = _repo.GetById(dto.Id);
            }
            entity.Name = dto.Name;
            entity.AddressId = dto.AddressId;
            entity.Address.PostCode = dto.PostCode;
            entity.Address.Country = dto.Country;
            entity.Address.Region = dto.Region;
            entity.Address.City = dto.City;
            entity.Address.Street = dto.Street;
            entity.Address.Building = dto.Building;
            entity.Deleted = dto.Deleted;
            return entity;
        }
    }
}
