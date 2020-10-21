using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNE.Data.Exceptions;
using TNE.Dto.LeadDivisions;
using TNE.Models;

namespace TNE.Data.Implementations
{
    public class LeadDivisionRepositoryImpl : ILeadDivisionRepository
    {
        private readonly DatabaseContext _context;

        public LeadDivisionRepositoryImpl(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<LeadDivision> CreateAsync(LeadDivision entity)
        {
            Log.Debug("Creating LeadDivision: {entity}", entity);
            _context.LeadDivisions.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public void CheckExistsById(Guid id)
        {
            Log.Debug("Check exists LeadDivision by Id: '{id}'", id);
            var result = _context.LeadDivisions.Any(b => b.Id == id);
            if (!result)
            {
                throw new EntityNotFoundException($"LeadDivision with Id='{id}' not exist!");
            }
        }

        public async Task<List<LeadDivisionDto>> GetAllDtoAsync()
        {
            Log.Debug("GetAll LeadDivisionDto");
            var result = await _context.LeadDivisions
                .AsNoTracking()
                .Include(s => s.Address)
                .Select(s => new LeadDivisionDto(s))
                .ToListAsync();
            result.TrimExcess();
            return result;
        }

        public async Task<LeadDivision> GetByIdAsync(Guid id)
        {
            Log.Debug("Get LeadDivision by Id: '{Id}'", id);
            var result = await _context.LeadDivisions
                .AsNoTracking()
                .Include(b => b.Address)
                .SingleOrDefaultAsync(b => b.Id == id);
            return (result is null)
                ? throw new EntityNotFoundException($"LeadDivision with Id='{id}' not found!")
                : result;
        }

        public LeadDivision GetById(Guid id)
        {
            Log.Debug("Get LeadDivision by Id: '{Id}'", id);
            var result = _context.LeadDivisions
                .AsNoTracking()
                .Include(b => b.Address)
                .SingleOrDefault(b => b.Id == id);
            return (result is null)
                ? throw new EntityNotFoundException($"LeadDivision with Id='{id}' not found!")
                : result;
        }

        public async Task<LeadDivisionDto> GetDtoByIdAsync(Guid id)
        {
            Log.Debug("Get LeadDivisionDto by Id: '{Id}'", id);
            var result = await _context.LeadDivisions
                .AsNoTracking()
                .Include(s => s.Address)
                .Where(s => s.Id == id)
                .Select(s => new LeadDivisionDto(s))
                .SingleOrDefaultAsync();
            if (result is null) throw new EntityNotFoundException($"LeadDivision with ID = '{id}' not found!");
            return result;
        }

        public async Task<LeadDivision> UpdateAsync(LeadDivision entity)
        {
            Log.Debug("Updating LeadDivision: '{entity}'", entity);
            _context.LeadDivisions.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public bool ExistsByField(string fieldName, object fieldValue)
        {
            Log.Debug("ExistsByField LeadDivision: field name - '{fieldName}', value = '{fieldValue}' ", fieldName, fieldValue);
            return _context.LeadDivisions
                .AsNoTracking()
                .Include(s => s.Address)
                .Select(x => x.GetType().GetProperty(fieldName).GetValue(x).Equals(fieldValue))
                .ToList().Count != 0;
        }

        public bool ExistsByFieldAndNotId(Guid id, string fieldName, object fieldValue)
        {
            Log.Debug("ExistsByFieldAndNotId LeadDivision: Id - '{id}', field name - '{fieldName}', value = '{fieldValue}' ", id, fieldName, fieldValue);
            return _context.LeadDivisions
                .AsNoTracking()
                .Include(s => s.Address)
                .Where(s => s.Id != id)
                .Select(x => x.GetType().GetProperty(fieldName).GetValue(x).Equals(fieldValue))
                .ToList().Count != 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Log.Debug("Deleting LeadDivision ID = {id}", id);
            var obj = await GetByIdAsync(id);
            obj.Deleted = true;
            _context.LeadDivisions.Attach(obj);
            _context.Entry(obj).Property(x => x.Deleted).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UndeleteAsync(Guid id)
        {
            Log.Debug("Undeleting LeadDivision ID = {id}", id);
            var obj = await GetByIdAsync(id);
            obj.Deleted = false;
            _context.LeadDivisions.Attach(obj);
            _context.Entry(obj).Property(x => x.Deleted).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<LeadDivisionDto>> GetAllActiveDtoAsync()
        {
            Log.Debug("GetAllActive LeadDivisionDto");
            var result = await _context.LeadDivisions
                .AsNoTracking()
                .Include(s => s.Address)
                .Where(s => s.Deleted == false)
                .Select(s => new LeadDivisionDto(s))
                .ToListAsync();
            result.TrimExcess();
            return result;
        }
    }
}
