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
    public class ProviderRepositoryImpl : IProviderRepository
    {
        private readonly DatabaseContext _context;

        public ProviderRepositoryImpl(DatabaseContext context) { _context = context; }

        public void CheckExistsById(Guid id)
        {
            Log.Debug("Check exists Provider by Id: '{Id}'", id);
            bool result = _context.Providers.Any(b => b.Id == id);
            if (!result) { throw new EntityNotFoundException($"Provider with Id='{id}' not exist!"); }
        }

        public async Task<Provider> CreateAsync(Provider entity)
        {
            Log.Debug("Creating Provider: {entity}", entity);
            _context.Providers.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var obj = new Provider { Id = id };
            _context.Providers.Attach(obj);
            _context.Entry(obj).Property(x => x.Deleted).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public bool ExistsByField(string fieldName, object fieldValue)
        {
            Log.Debug("ExistsByField Provider: field name - '{fieldName}', value = '{fieldValue}' ", fieldName, fieldValue);
            return fieldName.Equals("Name")
                ? _context.Providers.FromSqlRaw($"SELECT * FROM dbo.Divisions WHERE {fieldName}='{fieldValue}'").Count() == 0
                : _context.Addresses.FromSqlRaw($"SELECT * FROM dbo.Addresses WHERE {fieldName}='{fieldValue}'").Count() == 0;
        }

        public bool ExistsByFieldAndNotId(Guid id, string fieldName, object fieldValue)
        {
            Log.Debug("ExistsByFieldAndNotId Provider: Id - 'id', field name - '{fieldName}', value = '{fieldValue}' ", id, fieldName, fieldValue);
            return fieldName.Equals("Name")
            ? _context.Providers.FromSqlRaw($"SELECT * FROM dbo.Divisions WHERE {fieldName}='{fieldValue}' AND Id <> '{id}'").Count() == 0
            : _context.Addresses.FromSqlRaw($"SELECT * FROM dbo.Divisions WHERE {fieldName}='{fieldValue}' AND Id <> '{id}'").Count() == 0;
        }

        public async Task<List<ProviderDto>> GetAllActiveDtoAsync()
        {
            Log.Debug("GetAllActive ProviderDto");
            var result = await _context.Providers
                .AsNoTracking()
                .Include(s => s.Address)
                .Where(s => s.Deleted == false)
                .Select(s => new ProviderDto
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
                    SubDivisionId = s.SubDivision.Id,
                    SubDivisionName = s.SubDivision.Name
                }).ToListAsync();
            result.TrimExcess();
            return result;
        }

        public async Task<List<ProviderDto>> GetAllDtoAsync()
        {
            Log.Debug("GetAll ProviderDto");
            var result = await _context.Providers
                .AsNoTracking()
                .Include(s => s.Address)
                .Include(b => b.SubDivision)
                .Select(s => new ProviderDto
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
                    SubDivisionId = s.SubDivision.Id,
                    SubDivisionName = s.SubDivision.Name
                }).ToListAsync();
            result.TrimExcess();
            return result;
        }

        public Provider GetById(Guid id)
        {
            Log.Debug("Get Provider by Id: '{Id}'", id);
            var result = _context.Providers.AsNoTracking()
                .Include(b => b.Address)
                .Include(b => b.SubDivision)
                .SingleOrDefault(b => b.Id == id);
            return (result is null)
                ? throw new EntityNotFoundException($"Provider with Id='{id}' not found!")
                : result;
        }

        public async Task<Provider> GetByIdAsync(Guid id)
        {
            Log.Debug("Get Provider by Id: '{Id}'", id);
            var result = await _context.Providers.AsNoTracking().Include(b => b.Address).Include(b => b.SubDivision).SingleOrDefaultAsync(b => b.Id == id);
            return (result is null)
                ? throw new EntityNotFoundException($"Provider with Id='{id}' not found!")
                : result;
        }

        public async Task<ProviderDto> GetDtoByIdAsync(Guid Id)
        {
            Log.Debug("Get ProviderDto by Id: '{Id}'", Id);
            var result = await _context.Providers.AsNoTracking()
                .Include(s => s.Address)
                .Include(b => b.SubDivision)
                .Where(s => s.Id == Id)
                .Select(s => new ProviderDto
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
                    SubDivisionId = s.SubDivision.Id,
                    SubDivisionName = s.SubDivision.Name
                }).SingleOrDefaultAsync();
            if (result is null) throw new EntityNotFoundException($"Provider with ID = '{Id}' not found!");
            return result;
        }

        public async Task<bool> UndeleteAsync(Guid id)
        {
            var obj = new Provider { Id = id };
            _context.Providers.Attach(obj);
            _context.Entry(obj).Property(x => x.Deleted).IsModified = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Provider> UpdateAsync(Provider entity)
        {
            Log.Debug("Updating Provider: '{entity}'", entity);
            _context.Providers.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
