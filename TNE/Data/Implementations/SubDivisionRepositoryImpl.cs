using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNE.Data.Exceptions;
using TNE.Dto;
using TNE.Models;

namespace TNE.Data.Implementations
{
    public class SubDivisionRepositoryImpl : ISubDivisionRepository
    {
        private readonly DatabaseContext _context;

        public SubDivisionRepositoryImpl(DatabaseContext context) {  _context = context; }

        public void CheckExistsById(Guid id)
        {
            Log.Debug("Check exists SubDivision by Id: '{Id}'", id);
            bool result = _context.SubDivisions.Any(b => b.Id == id);
            if (!result) { throw new EntityNotFoundException($"SubDivision with Id='{id}' not exist!"); }
        }

        public async Task<SubDivision> CreateAsync(SubDivision entity)
        {
            Log.Debug("Creating SubDivision: {entity}", entity);
            _context.SubDivisions.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var obj = new SubDivision { Id = id, Deleted = true };
            _context.SubDivisions.Attach(obj);
            _context.Entry(obj).Property(x => x.Deleted).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UndeleteAsync(Guid id)
        {
            var obj = new SubDivision { Id = id, Deleted = false };
            _context.SubDivisions.Attach(obj);
            _context.Entry(obj).Property(x => x.Deleted).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public bool ExistsByField(string fieldName, object fieldValue)
        {
            Log.Debug("ExistsByField SubDivision: field name - '{fieldName}', value = '{fieldValue}' ", fieldName, fieldValue);
            return fieldName.Equals("Name")
                ? _context.SubDivisions.FromSqlRaw($"SELECT * FROM dbo.Divisions WHERE {fieldName}='{fieldValue}'").Count() == 0
                : _context.Addresses.FromSqlRaw($"SELECT * FROM dbo.Addresses WHERE {fieldName}='{fieldValue}'").Count() == 0;
        }

        public bool ExistsByFieldAndNotId(Guid id, string fieldName, object fieldValue)
        {
            Log.Debug("ExistsByFieldAndNotId SubDivision: Id - 'id', field name - '{fieldName}', value = '{fieldValue}' ", id, fieldName, fieldValue);
            return fieldName.Equals("Name")
            ? _context.SubDivisions.FromSqlRaw($"SELECT * FROM dbo.Divisions WHERE {fieldName}='{fieldValue}' AND Id <> '{id}'").Count() == 0
            : _context.Addresses.FromSqlRaw($"SELECT * FROM dbo.Divisions WHERE {fieldName}='{fieldValue}' AND Id <> '{id}'").Count() == 0;
        }

        public async Task<List<SubDivisionDto>> GetAllDtoAsync()
        {
            Log.Debug("GetAll SubDivisionDto");
            var result = await _context.SubDivisions
                .AsNoTracking()
                .Include(s => s.Address)
                .Include(b => b.LeadDivision)
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
                    Deleted = s.Deleted,
                    LeadDivisionId = s.LeadDivision.Id,
                    LeadDivisionName = s.LeadDivision.Name
                }).ToListAsync();
            result.TrimExcess();
            return result;
        }

        public SubDivision GetById(Guid id)
        {
            Log.Debug("Get SubDivision by Id: '{Id}'", id);
            var result = _context.SubDivisions.AsNoTracking()
                .Include(b => b.Address)
                .Include(b => b.LeadDivision)
                .SingleOrDefault(b => b.Id == id);
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
            var result = await _context.SubDivisions.AsNoTracking()
                .Include(s => s.Address)
                .Include(b => b.LeadDivision)
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
                    Deleted = s.Deleted,
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

        public async Task<List<SubDivisionDto>> GetAllActiveDtoAsync()
        {
            Log.Debug("GetAllActive SubDivisionDto");
            var result = await _context.SubDivisions
                .AsNoTracking()
                .Include(s => s.Address)
                .Where(s => s.Deleted == false)
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
                    Deleted = s.Deleted,
                    LeadDivisionId = s.LeadDivision.Id,
                    LeadDivisionName = s.LeadDivision.Name
                }).ToListAsync();
            result.TrimExcess();
            return result;
        }
    }
}
