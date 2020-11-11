using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Data;
using TNE.Data.Exceptions;
using TNE.Dto;
using TNE.Models;

namespace TNE.Services.Implementations
{
    public class SubDivisionServiceImpl : ISubDivisionService
    {
        private readonly ISubDivisionRepository _repo;

        public SubDivisionServiceImpl(ISubDivisionRepository repo) => _repo = repo;

        public void CheckExistsById(Guid id) => _repo.CheckExistsById(id);

        public async Task<SubDivisionDto> CreateAsync(SubDivisionDto dto)
        {
            if (!dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must be empty for CREATE!");
            var entity = ConvertToEntity(dto);
            var result = await _repo.CreateAsync(entity);
            return new SubDivisionDto(result);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            CheckExistsById(id);
            return await _repo.DeleteAsync(id);
        }

        public async Task<List<SubDivisionDto>> GetAllActiveDtoAsync() => await _repo.GetAllActiveDtoAsync();

        public async Task<List<SubDivisionDto>> GetAllDtoAsync() => await _repo.GetAllDtoAsync();

        public async Task<List<SubDivisionDto>> GetAllDtoByLeadDivisionIdAsync(Guid id) => await _repo.GetAllDtoByLeadDivisionIdAsync(id);

        public SubDivision GetById(Guid id) 
        {
            CheckExistsById(id);
            return _repo.GetById(id); 
        }

        public async Task<SubDivision> GetByIdAsync(Guid id) 
        {
            CheckExistsById(id);
            return await _repo.GetByIdAsync(id); 
        }

        public async Task<SubDivisionDto> GetDtoByIdAsync(Guid id)
        {
            CheckExistsById(id);
            return await _repo.GetDtoByIdAsync(id);
        }

        public bool IsFieldUnique(Guid id, string fieldName, object fieldValue)
        {
            return (id.Equals(Guid.Empty))
                ? !_repo.ExistsByField(fieldName, fieldValue)
                : !_repo.ExistsByFieldAndNotId(id, fieldName, fieldValue);
        }

        public async Task<bool> UndeleteAsync(Guid id) 
        {
            CheckExistsById(id);
            return await _repo.UndeleteAsync(id); 
        }

        public async Task<SubDivisionDto> UpdateAsync(SubDivisionDto dto)
        {
            if (dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must can't be empty for UPDATE!");
            CheckExistsById(dto.Id);
            var entity = ConvertToEntity(dto);
            return new SubDivisionDto(await _repo.UpdateAsync(entity));
        }

        private SubDivision ConvertToEntity(SubDivisionDto dto)
        {
            var entity = new SubDivision();
            entity.Id = dto.Id;
            entity.Name = dto.Name;
            entity.AddressId = dto.AddressId;
            entity.Address.PostCode = dto.PostCode;
            entity.Address.Country = dto.Country;
            entity.Address.Region = dto.Region;
            entity.Address.City = dto.City;
            entity.Address.Street = dto.Street;
            entity.Address.Building = dto.Building;
            entity.Deleted = dto.Deleted;
            entity.LeadDivisionId = dto.LeadDivisionId;
            return entity;
        }
    }
}
