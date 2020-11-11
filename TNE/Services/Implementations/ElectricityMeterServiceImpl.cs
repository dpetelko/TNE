﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Data;
using TNE.Data.Exceptions;
using TNE.Dtos;
using TNE.Dtos.SearchFilters;
using TNE.Models;

namespace TNE.Services.Implementations
{
    public class ElectricityMeterServiceImpl : IElectricityMeterService
    {
        private readonly IElectricityMeterRepository _repo;

        public ElectricityMeterServiceImpl(IElectricityMeterRepository repo) => _repo = repo;

        public void CheckExistsById(Guid id) => _repo.CheckExistsById(id);

        public async Task<ElectricityMeterDto> CreateAsync(ElectricityMeterDto dto)
        {
            if (!dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must be empty for CREATE!");
            var result = await _repo.CreateAsync(new ElectricityMeter(dto));
            return new ElectricityMeterDto(result);
        }

        public async Task<List<ElectricityMeterDto>> GetAllDtoAsync() => await _repo.GetAllDtoAsync();

        public async Task<List<ElectricityMeterDto>> GetAllDtoByStatusAsync(Status status) => await _repo.GetAllDtoByStatusAsync(status);

        public async Task<List<ElectricityMeterDto>> GetAllDtoByFilterAsync(DeviceCalibrationControlDto filter) => await _repo.GetAllDtoByFilterAsync(filter);

        public ElectricityMeter GetById(Guid id) => _repo.GetById(id);

        public async Task<ElectricityMeter> GetByIdAsync(Guid id) => await _repo.GetByIdAsync(id);

        public async Task<ElectricityMeterDto> GetDtoByControlPointId(Guid id) => await _repo.GetDtoByControlPointId(id);

        public async Task<ElectricityMeterDto> GetDtoByIdAsync(Guid id) => await _repo.GetDtoByIdAsync(id);

        public bool IsFieldUnique(Guid id, string fieldName, object fieldValue)
        {
            return (id.Equals(Guid.Empty))
                ? !_repo.ExistsByField(fieldName, fieldValue)
                : !_repo.ExistsByFieldAndNotId(id, fieldName, fieldValue);
        }

        public async Task<bool> SetStatus(Guid id, Status newStatus) => await _repo.SetStatus(id, newStatus);

        public async Task<ElectricityMeterDto> UpdateAsync(ElectricityMeterDto dto)
        {
            if (dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must can't be empty for UPDATE!");
            CheckExistsById(dto.Id);
            return new ElectricityMeterDto(await _repo.UpdateAsync(new ElectricityMeter(dto)));
        }
    }
}
