using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNE.Data.Exceptions;
using TNE.Dto;
using TNE.Models;
using static System.String;

namespace TNE.Data.Implementations
{
    public class SubDivisionRepositoryImpl : ISubDivisionRepository
    {
        private readonly DatabaseContext _context;

        public SubDivisionRepositoryImpl(DatabaseContext context)
        {
            _context = context;
        }

        public async void CheckExistsByIdAsync(Guid id)
        {
            Log.Debug("Check exists SubDivision by Id: '{Id}'", id);
            bool result = await _context.SubDivisions.AnyAsync(b => b.Id == id);
            if (!result)
            {
                throw new EntityNotFoundException($"SubDivision with Id='{id}' not exist!");
            }
        }

        public async Task<SubDivision> CreateAsync(SubDivision entity)
        {
            Log.Debug("Creating SubDivision: {entity}", entity);
            _context.SubDivisions.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public bool ExistsByField(string fieldName, object fieldValue)
        {
            throw new NotImplementedException();
        }

        public bool ExistsByFieldAndNotId(Guid id, string fieldName, object fieldValue)
        {
            throw new NotImplementedException();
        }

        public Task<List<SubDivisionDto>> GetAllDtoAsync()
        {
            throw new NotImplementedException();
        }

        public SubDivision GetById(Guid id)
        {
            Log.Debug("Get SubDivision by Id: '{Id}'", id);
            var result = _context.SubDivisions.AsNoTracking().Include(b => b.Address).Include(b => b.LeadDivision).SingleOrDefault(b => b.Id == id);
            return (result is null)
                ? throw new EntityNotFoundException($"SubDivision with Id='{id}' not found!")
                : result;
        }

        public async Task<SubDivision> GetByIdAsync(Guid id)
        {
            Log.Debug("Get SubDivision by Id: '{Id}'", id);
            var result = await _context.SubDivisions.AsNoTracking().Include(b => b.Address).Include(b => b.LeadDivision).SingleOrDefaultAsync(b => b.Id == id);
            return (result is null)
                ? throw new EntityNotFoundException($"SubDivision with Id='{id}' not found!")
                : result;
        }

        public async Task<SubDivisionDto> GetDtoByIdAsync(Guid Id)
        {
            Log.Debug("Get SubDivisionDto by Id: '{Id}'", Id);
            var result = await _context.SubDivisions.AsNoTracking().Include(s => s.Address).Include(b => b.LeadDivision)
                       .Where(s => s.Id == Id)
                       .Select(s => new SubDivisionDto
                       {
                           Id = s.Id,
                           Name = s.Name,
                           AddressId = s.Address.Id,
                           PostCode = s.Address.PostCode,
                           Country = s.Address.Country,
                           Region = s.Address.Region,
                           City = s.Address.City,
                           Street = s.Address.Street,
                           Building = s.Address.Building,
                           LeadDivisionId = s.LeadDivision.Id,
                           LeadDivisionName = s.LeadDivision.Name
                       }).SingleOrDefaultAsync();
            if (result is null) throw new EntityNotFoundException($"SubDivision with ID = '{Id}' not found!");
            return result;
        }

        public async Task<SubDivision> UpdateAsync(SubDivision entity)
        {
            Log.Debug("Updating SubDivision: '{entity}'", entity);
            _context.SubDivisions.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
