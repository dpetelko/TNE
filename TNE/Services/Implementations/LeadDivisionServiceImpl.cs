﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Data;
using TNE.Data.Exceptions;
using TNE.Dto;
using TNE.Models;

namespace TNE.Services.Implementations
{
    public class LeadDivisionServiceImpl : ILeadDivisionService
    {
        private readonly ILeadDivisionRepository _repo;
        private readonly IMapper _mapper;

        public LeadDivisionServiceImpl(ILeadDivisionRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<LeadDivisionDto> CreateAsync(LeadDivisionDto dto)
        {
            if (!dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must be empty for CREATE!");
            var entity = _mapper.Map<LeadDivision>(dto);
            var result = await _repo.CreateAsync(entity);
            return _mapper.Map<LeadDivisionDto>(result);
        }

        public void CheckExistsById(Guid id) => _repo.CheckExistsById(id);

        public async Task<List<LeadDivisionDto>> GetAllDtoAsync() => await _repo.GetAllDtoAsync();

        public async Task<LeadDivisionDto> GetDtoByIdAsync(Guid id)
        {
            CheckExistsById(id);
            return await _repo.GetDtoByIdAsync(id);
        }

        public async Task<LeadDivisionDto> UpdateAsync(LeadDivisionDto dto)
        {
            if (dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must can't be empty for UPDATE!");
            CheckExistsById(dto.Id);
            var result = await _repo.UpdateAsync(new LeadDivision(dto));
            return new LeadDivisionDto(result);
        }

        public LeadDivision GetById(Guid id)
        {
            CheckExistsById(id);
            return _repo.GetById(id);
        }

        public async Task<LeadDivision> GetByIdAsync(Guid id)
        {
            CheckExistsById(id);
            return await _repo.GetByIdAsync(id);
        }

        public bool IsFieldUnique(Guid id, string fieldName, object fieldValue)
        {
            return (id.Equals(Guid.Empty))
                ? !_repo.ExistsByField(fieldName, fieldValue)
                : !_repo.ExistsByFieldAndNotId(id, fieldName, fieldValue);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            CheckExistsById(id);
            return await _repo.DeleteAsync(id);
        }

        public async Task<bool> UndeleteAsync(Guid id)
        {
            CheckExistsById(id);
            return await _repo.UndeleteAsync(id);
        }

        public async Task<List<LeadDivisionDto>> GetAllActiveDtoAsync() => await _repo.GetAllActiveDtoAsync();
    }
}
