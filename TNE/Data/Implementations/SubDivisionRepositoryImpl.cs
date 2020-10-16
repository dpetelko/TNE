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
            _context.Entry(entity).Reference(c => c.LeadDivision).Load();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Log.Debug("Deleting SubDivision ID = {id}", id);
            var obj = await GetByIdAsync(id);
            obj.Deleted = true;
            _context.SubDivisions.Attach(obj);
            _context.Entry(obj).Property(x => x.Deleted).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UndeleteAsync(Guid id)
        {
            Log.Debug("Undeleting SubDivision ID = {id}", id);
            var obj = await GetByIdAsync(id);
            obj.Deleted = false;
            _context.SubDivisions.Attach(obj);
            _context.Entry(obj).Property(x => x.Deleted).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public bool ExistsByField(string fieldName, object fieldValue)
        {
            Log.Debug("ExistsByField SubDivision: field name - '{fieldName}', value = '{fieldValue}' ", fieldName, fieldValue);
            return _context.SubDivisions
                .AsNoTracking()
                .Include(s => s.Address)
                .Select(x => x.GetType().GetProperty(fieldName).GetValue(x))
                .ToList().Contains(fieldValue);
        }

        public bool ExistsByFieldAndNotId(Guid id, string fieldName, object fieldValue)
        {
            Log.Debug("ExistsByFieldAndNotId SubDivision: Id - '{id}', field name - '{fieldName}', value = '{fieldValue}' ", id, fieldName, fieldValue);
            return _context.SubDivisions
                .AsNoTracking()
                .Include(s => s.Address)
                .Where(s => s.Id != id)
                .Select(x => x.GetType().GetProperty(fieldName).GetValue(x))
                .ToList().Contains(fieldValue);
        }

        public async Task<List<SubDivisionDto>> GetAllDtoAsync()
        {
            Log.Debug("GetAll SubDivisionDto");
            var result = await _context.SubDivisions
                .AsNoTracking()
                .Include(s => s.Address)
                .Include(b => b.LeadDivision)
                .Select(s => new SubDivisionDto(s))
                .ToListAsync();
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
            var result = await _context.SubDivisions
                .AsNoTracking()
                .Include(b => b.Address)
                .Include(b => b.LeadDivision)
                .SingleOrDefaultAsync(b => b.Id == id);
            return (result is null)
                ? throw new EntityNotFoundException($"SubDivision with Id='{id}' not found!")
                : result;
        }

        public async Task<SubDivisionDto> GetDtoByIdAsync(Guid id)
        {
            Log.Debug("Get SubDivisionDto by Id: '{Id}'", id);
            var result = await _context.SubDivisions.AsNoTracking()
                .Include(s => s.Address)
                .Include(b => b.LeadDivision)
                .Where(s => s.Id == id)
                .Select(s => new SubDivisionDto(s))
                .SingleOrDefaultAsync();
            if (result is null) throw new EntityNotFoundException($"SubDivision with ID = '{id}' not found!");
            return result;
        }

        public async Task<SubDivision> UpdateAsync(SubDivision entity)
        {
            Log.Debug("Updating SubDivision: '{entity}'", entity);
            _context.SubDivisions.Update(entity);
            await _context.SaveChangesAsync();
            _context.Entry(entity).Reference(c => c.LeadDivision).Load();
            return entity;
        }

        public async Task<List<SubDivisionDto>> GetAllActiveDtoAsync()
        {
            Log.Debug("GetAllActive SubDivisionDto");
            var result = await _context.SubDivisions
                .AsNoTracking()
                .Include(b => b.LeadDivision)
                .Include(s => s.Address)
                .Where(s => s.Deleted == false)
                .Select(s => new SubDivisionDto(s))
                .ToListAsync();
            result.TrimExcess();
            return result;
        }

        public async Task<List<SubDivisionDto>> GetAllDtoByLeadDivisionIdAsync(Guid id)
        {
            Log.Debug("GetAllDtoByLeadDivisionIdAsync SubDivisionDto");
            var result = await _context.SubDivisions
                .AsNoTracking()
                .Include(b => b.LeadDivision)
                .Include(s => s.Address)
                .Where(s => s.LeadDivisionId == id)
                .Select(s => new SubDivisionDto(s))
                .ToListAsync();
            result.TrimExcess();
            return result;
        }
    }
}
