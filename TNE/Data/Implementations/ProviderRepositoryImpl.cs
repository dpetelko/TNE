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
            _context.Entry(entity).Reference(c => c.SubDivision).Load();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Log.Debug("Deleting Provider ID = {id}", id);
            var obj = await GetByIdAsync(id);
            obj.Deleted = true;
            _context.Providers.Attach(obj);
            _context.Entry(obj).Property(x => x.Deleted).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public bool ExistsByField(string fieldName, object fieldValue)
        {
            Log.Debug("ExistsByField Provider: field name - '{fieldName}', value = '{fieldValue}' ", fieldName, fieldValue);
            return _context.Providers
                .AsNoTracking()
                .Include(s => s.Address)
                .Select(x => x.GetType().GetProperty(fieldName).GetValue(x))
                .ToList().Contains(fieldValue);
        }

        public bool ExistsByFieldAndNotId(Guid id, string fieldName, object fieldValue)
        {
            Log.Debug("ExistsByFieldAndNotId Provider: Id - '{id}', field name - '{fieldName}', value = '{fieldValue}' ", id, fieldName, fieldValue);
            return _context.Providers
                .AsNoTracking()
                .Include(s => s.Address)
                .Where(s => s.Id != id)
                .Select(x => x.GetType().GetProperty(fieldName).GetValue(x))
                .ToList().Contains(fieldValue);
        }

        public async Task<List<ProviderDto>> GetAllActiveDtoAsync()
        {
            Log.Debug("GetAllActive ProviderDto");
            var result = await _context.Providers
                .AsNoTracking()
                .Include(s => s.Address)
                .Include(b => b.SubDivision)
                .Where(s => s.Deleted == false)
                .Select(s => new ProviderDto(s))
                .ToListAsync();
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
                .Select(s => new ProviderDto(s))
                .ToListAsync();
            result.TrimExcess();
            return result;
        }

        public async Task<List<ProviderDto>> GetAllDtoBySubDivisionIdAsync(Guid id)
        {
            Log.Debug("Get GetAllDtoBySubDivisionIdAsync by Id: '{id}'", id);
            var result = await _context.Providers.AsNoTracking()
                .Include(s => s.Address)
                .Include(b => b.SubDivision)
                .Where(s => s.SubDivisionId == id)
                .Select(s => new ProviderDto(s))
                .ToListAsync();
            result.TrimExcess();
            return result;
        }

        public Provider GetById(Guid id)
        {
            Log.Debug("Get Provider by Id: '{id}'", id);
            var result = _context.Providers.AsNoTracking()
                .Include(b => b.Address)
                .Include(b => b.SubDivision)
                .SingleOrDefault(b => b.Id == id);
            return (result is null)
                ? throw new EntityNotFoundException($"Provider with id='{id}' not found!")
                : result;
        }

        public async Task<Provider> GetByIdAsync(Guid id)
        {
            Log.Debug("Get Provider by Id: '{id}'", id);
            var result = await _context.Providers
                .AsNoTracking()
                .Include(b => b.Address)
                .Include(b => b.SubDivision)
                .SingleOrDefaultAsync(b => b.Id == id);
            return (result is null)
                ? throw new EntityNotFoundException($"Provider with Id='{id}' not found!")
                : result;
        }

        public async Task<ProviderDto> GetDtoByIdAsync(Guid id)
        {
            Log.Debug("Get ProviderDto by Id: '{id}'", id);
            var result = await _context.Providers.AsNoTracking()
                .Include(s => s.Address)
                .Include(b => b.SubDivision)
                .Where(s => s.Id == id)
                .Select(s => new ProviderDto(s))
                .SingleOrDefaultAsync();
            if (result is null) throw new EntityNotFoundException($"Provider with ID = '{id}' not found!");
            return result;
        }

        public async Task<bool> UndeleteAsync(Guid id)
        {
            Log.Debug("Undeleting Provider ID = {id}", id);
            var obj = await GetByIdAsync(id);
            obj.Deleted = false;
            _context.Providers.Attach(obj);
            _context.Entry(obj).Property(x => x.Deleted).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Provider> UpdateAsync(Provider entity)
        {
            Log.Debug("Updating Provider: '{entity}'", entity);
            _context.Providers.Update(entity);
            await _context.SaveChangesAsync();
            _context.Entry(entity).Reference(c => c.SubDivision).Load();
            return entity;
        }
    }
}
