using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using TNE.Data;
using TNE.Data.Exceptions;
using TNE.Dto;
using TNE.Models;

namespace TNE.Services.Implementations
{
    public class SubDivisionServiceImpl //: ISubDivisionService
    {
        //private readonly ISubDivisionRepository _repo;
        //private readonly ILeadDivisionService _leadDivisionService;
        //private readonly ILogger<SubDivisionServiceImpl> _logger;

        //public SubDivisionServiceImpl(ISubDivisionRepository repo, ILeadDivisionService leadDivisionService, ILogger<SubDivisionServiceImpl> logger)
        //{
        //    _repo = repo;
        //    _leadDivisionService = leadDivisionService;
        //    _logger = logger;
        //}

        //public SubDivision Create(SubDivision model) { return _repo.Create(model); }

        //public SubDivisionDto Create(SubDivisionDto dto)
        //{
        //    if (dto.Id != Guid.Empty)
        //    {
        //        _logger.LogWarning("Id must be empty for CREATE operation!");
        //        throw new InvalidEntityException("Id must be empty for CREATE operation!");
        //    }
        //    var entity = ConvertToEntity(dto);
        //    return new SubDivisionDto(Create(entity));
        //}

        //public void CheckExistsById(Guid id) { _repo.CheckExistsById(id); }

        //public List<SubDivisionListViewModel> GetAllViewModels() { return _repo.GetAllViewModels(); }

        //public SubDivisionElementViewModel GetViewModelById(Guid id) { return _repo.GetViewModelById(id); }

        //public SubDivision Update(SubDivision model) { return _repo.Update(model); }

        //public SubDivisionDto Update(SubDivisionDto dto)
        //{
        //    CheckExistsById(dto.Id);
        //    var entity = ConvertToEntity(dto);
        //    return new SubDivisionDto(Update(entity));
        //}

        //public SubDivision GetById(Guid id) { return _repo.GetById(id); }

        //private SubDivision ConvertToEntity(SubDivisionDto dto)
        //{
        //    var result = new SubDivision();
        //    result.Id = dto.Id;
        //    result.Name = dto.Name;
        //    result.AddressId = dto.AddressId;
        //    result.Address.Id = dto.AddressId;
        //    result.Address.PostCode = dto.PostCode;
        //    result.Address.Country = dto.Country;
        //    result.Address.Region = dto.Region;
        //    result.Address.City = dto.City;
        //    result.Address.Street = dto.Street;
        //    result.Address.Building = dto.Building;
        //    result.LeadDivision = _leadDivisionService.GetById(dto.LeadDivisionId);
        //    return result;
        //}
    }
}
