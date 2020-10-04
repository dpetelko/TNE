using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNE.Data;
using TNE.Data.Exceptions;
using TNE.Dto;
using TNE.Models;

namespace TNE.Services.Implementations
{
    public class ProviderServiceImpl : IProviderService
    {
        private readonly IProviderRepository _repo;
        private readonly ISubDivisionService _subDivisionService;

        public ProviderServiceImpl(IProviderRepository repo, ISubDivisionService subDivisionService)
        {
            _repo = repo;
            _subDivisionService = subDivisionService;
        }

        public void CheckExistsById(Guid id) { _repo.CheckExistsById(id); }

        public async Task<ProviderDto> CreateAsync(ProviderDto dto)
        {
            if (!dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must be empty for CREATE!");
            var entity = ConvertToEntity(dto);
            var result = await _repo.CreateAsync(entity);
            return new ProviderDto(result);
        }

        public async Task<bool> DeleteAsync(Guid id) 
        {
            CheckExistsById(id);
            return await _repo.DeleteAsync(id);
        }

        public async Task<List<ProviderDto>> GetAllActiveDtoAsync() { return await _repo.GetAllActiveDtoAsync(); }

        public async Task<List<ProviderDto>> GetAllDtoAsync() { return await _repo.GetAllDtoAsync(); }

        public Provider GetById(Guid id) 
        {
            CheckExistsById(id);
            return _repo.GetById(id); 
        }

        public async Task<Provider> GetByIdAsync(Guid id) 
        {
            CheckExistsById(id);
            return await _repo.GetByIdAsync(id); 
        }

        public async Task<ProviderDto> GetDtoByIdAsync(Guid id)
        {
            CheckExistsById(id);
            return await _repo.GetDtoByIdAsync(id);
        }

        public bool IsFieldUnique(Guid id, string fieldName, object fieldValue)
        {
            return (id.Equals(Guid.Empty))
                ? _repo.ExistsByField(fieldName, fieldValue)
                : _repo.ExistsByFieldAndNotId(id, fieldName, fieldValue);
        }

        public async Task<bool> UndeleteAsync(Guid id) 
        {
            CheckExistsById(id);
            return await _repo.UndeleteAsync(id); 
        }

        public async Task<ProviderDto> UpdateAsync(ProviderDto dto)
        {
            if (dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must can't be empty for UPDATE!");
            CheckExistsById(dto.Id);
            var entity = ConvertToEntity(dto);
            return new ProviderDto(await _repo.UpdateAsync(entity));
        }

        private Provider ConvertToEntity(ProviderDto dto)
        {
            var entity = new Provider();
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
            if (!Equals(dto.SubDivisionId, Guid.Empty) && !entity.SubDivisionId.Equals(dto.SubDivisionId))
            {
                entity.SubDivision = _subDivisionService.GetById(dto.SubDivisionId);
            }
            return entity;
        }
    }
}
