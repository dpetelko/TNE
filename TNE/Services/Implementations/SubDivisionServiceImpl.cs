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
        private readonly ILeadDivisionService _leadDivisionService;

        public SubDivisionServiceImpl(ISubDivisionRepository repo, ILeadDivisionService leadDivisionService, ILogger<SubDivisionServiceImpl> logger)
        {
            _repo = repo;
            _leadDivisionService = leadDivisionService;
        }

        public void CheckExistsById(Guid id)
        {
            _repo.CheckExistsById(id);
        }

        public Task<SubDivisionDto> CreateAsync(SubDivisionDto dto)
        {
            //if (!dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must be empty for CREATE!");
            //var entity = ConvertToEntity(dto);
            //var result = await _repo.CreateAsync(entity);
            return null;// new SubDivisionDto(result);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<SubDivisionDto>> GetAllActiveDtoAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<SubDivisionDto>> GetAllDtoAsync()
        {
            throw new NotImplementedException();
        }

        public SubDivision GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<SubDivision> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<SubDivisionDto> GetDtoByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool IsFieldUnique(Guid id, string fieldName, object fieldValue)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UndeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<SubDivisionDto> UpdateAsync(SubDivisionDto dto)
        {
            throw new NotImplementedException();
        }

        private SubDivision ConvertToEntity(SubDivisionDto dto)
        {
            var entity = new SubDivision();
            if (!dto.Id.Equals(Guid.Empty))
            {
                entity = _repo.GetById(dto.Id);
            }
            entity.Name = dto.Name;
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
