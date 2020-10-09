using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNE.Data.Exceptions;
using TNE.Dtos;
using TNE.Models;

namespace TNE.Data.Implementations
{
    public class CurrentTransformerRepositoryImpl : ICurrentTransformerRepository
    {
        private readonly DatabaseContext _context;

        public CurrentTransformerRepositoryImpl(DatabaseContext context) { _context = context; }

        public void CheckExistsById(Guid id)
        {
            Log.Debug("Check exists CurrentTransformer by Id: '{Id}'", id);
            bool result = _context.CurrentTransformers.Any(b => b.Id == id);
            if (!result) { throw new EntityNotFoundException($"CurrentTransformer with Id='{id}' not exist!"); }
        }

        public async Task<CurrentTransformer> CreateAsync(CurrentTransformer entity)
        {
            Log.Debug("Creating CurrentTransformer: {entity}", entity);
            _context.CurrentTransformers.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public bool ExistsByField(string fieldName, object fieldValue)
        {
            Log.Debug("ExistsByField CurrentTransformer: field name - '{fieldName}', value = '{fieldValue}' ", fieldName, fieldValue);
            return _context.CurrentTransformers.FromSqlRaw($"SELECT * FROM dbo.Transformers WHERE {fieldName}='{fieldValue}'").Count() == 0;
        }

        public bool ExistsByFieldAndNotId(Guid id, string fieldName, object fieldValue)
        {
            Log.Debug("ExistsByFieldAndNotId CurrentTransformer: Id - 'id', field name - '{fieldName}', value = '{fieldValue}' ", id, fieldName, fieldValue);
            return _context.CurrentTransformers.FromSqlRaw($"SELECT * FROM dbo.Transformers WHERE {fieldName}='{fieldValue}' AND Id <> '{id}'").Count() == 0;


        }

        public async Task<List<CurrentTransformerDto>> GetAllDtoAsync()
        {
            Log.Debug("GetAll CurrentTransformerDto");
            var result = await _context.CurrentTransformers
                .AsNoTracking()
                .Include(s => s.ControlPoint)
                .Select(s => new CurrentTransformerDto(s))
                .ToListAsync();
            result.TrimExcess();
            return result;
        }

        public async Task<List<CurrentTransformerDto>> GetAllDtoByStatusAsync(Status status)
        {
            Log.Debug("GetAll CurrentTransformerDto");
            var result = await _context.CurrentTransformers
                .AsNoTracking()
                .Include(s => s.ControlPoint)
                .Where(s => s.Status == status)
                .Select(s => new CurrentTransformerDto(s))
                .ToListAsync();
            result.TrimExcess();
            return result;
        }

        public CurrentTransformer GetById(Guid id)
        {
            Log.Debug("Get CurrentTransformer by Id: '{Id}'", id);
            var result = _context.CurrentTransformers
                .AsNoTracking()
                .Include(b => b.ControlPoint)
                .SingleOrDefault(b => b.Id == id);
            return (result is null)
                ? throw new EntityNotFoundException($"CurrentTransformer with Id='{id}' not found!")
                : result;
        }

        public async Task<CurrentTransformer> GetByIdAsync(Guid id)
        {
            Log.Debug("Get CurrentTransformer by Id: '{Id}'", id);
            var result = await _context.CurrentTransformers
                .AsNoTracking()
                .Include(b => b.ControlPoint)
                .SingleOrDefaultAsync(b => b.Id == id);
            return (result is null)
                ? throw new EntityNotFoundException($"CurrentTransformer with Id='{id}' not found!")
                : result;
        }

        public async Task<CurrentTransformerDto> GetDtoByIdAsync(Guid Id)
        {
            Log.Debug("Get CurrentTransformerDto by Id: '{Id}'", Id);
            var result = await _context.CurrentTransformers
                .AsNoTracking()
                .Include(b => b.ControlPoint)
                .Where(s => s.Id == Id)
                .Select(s => new CurrentTransformerDto(s))
                .SingleOrDefaultAsync();
            if (result is null) throw new EntityNotFoundException($"CurrentTransformer with ID = '{Id}' not found!");
            return result;
        }

        public async Task<bool> SetStatus(Guid id, Status newStatus)
        {
            Log.Debug("Setting new Status= '{newStatus}' for CurrentTransformer ID= '{id}'", newStatus, id);
            var obj = await GetByIdAsync(id);
            obj.Status = newStatus;
            _context.CurrentTransformers.Attach(obj);
            _context.Entry(obj).Property(x => x.Status).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CurrentTransformer> UpdateAsync(CurrentTransformer entity)
        {
            Log.Debug("Updating CurrentTransformer: '{entity}'", entity);
            _context.CurrentTransformers.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
