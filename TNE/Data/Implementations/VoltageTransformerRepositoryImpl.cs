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
    public class VoltageTransformerRepositoryImpl : IVoltageTransformerRepository
    {
        private readonly DatabaseContext _context;

        public VoltageTransformerRepositoryImpl(DatabaseContext context) { _context = context; }

        public void CheckExistsById(Guid id)
        {
            Log.Debug("Check exists VoltageTransformer by Id: '{Id}'", id);
            bool result = _context.VoltageTransformers.Any(b => b.Id == id);
            if (!result) { throw new EntityNotFoundException($"VoltageTransformer with Id='{id}' not exist!"); }
        }

        public async Task<VoltageTransformer> CreateAsync(VoltageTransformer entity)
        {
            Log.Debug("Creating VoltageTransformer: {entity}", entity);
            _context.VoltageTransformers.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public bool ExistsByField(string fieldName, object fieldValue)
        {
            Log.Debug("ExistsByField VoltageTransformer: field name - '{fieldName}', value = '{fieldValue}' ", fieldName, fieldValue);
            return _context.VoltageTransformers
                .AsNoTracking()
                .Select(x => x.GetType().GetProperty(fieldName).GetValue(x))
                .ToList().Contains(fieldValue);
        }

        public bool ExistsByFieldAndNotId(Guid id, string fieldName, object fieldValue)
        {
            Log.Debug("ExistsByFieldAndNotId VoltageTransformer: Id - '{id}', field name - '{fieldName}', value = '{fieldValue}' ", id, fieldName, fieldValue);
            return _context.VoltageTransformers
                .AsNoTracking()
                .Where(s => s.Id != id)
                .Select(x => x.GetType().GetProperty(fieldName).GetValue(x))
                .ToList().Contains(fieldValue);
        }

        public async Task<List<VoltageTransformerDto>> GetAllDtoAsync()
        {
            Log.Debug("GetAll VoltageTransformerDto");
            var result = await _context.VoltageTransformers
                .AsNoTracking()
                .Include(s => s.ControlPoint)
                .Select(s => new VoltageTransformerDto(s))
                .ToListAsync();
            result.TrimExcess();
            return result;
        }

        public async Task<List<VoltageTransformerDto>> GetAllDtoByStatusAsync(Status status)
        {
            Log.Debug("GetAll VoltageTransformerDto");
            var result = await _context.VoltageTransformers
                .AsNoTracking()
                .Include(s => s.ControlPoint)
                .Where(s => s.Status == status)
                .Select(s => new VoltageTransformerDto(s))
                .ToListAsync();
            result.TrimExcess();
            return result;
        }

        public VoltageTransformer GetById(Guid id)
        {
            Log.Debug("Get VoltageTransformer by Id: '{Id}'", id);
            var result = _context.VoltageTransformers
                .AsNoTracking()
                .Include(b => b.ControlPoint)
                .SingleOrDefault(b => b.Id == id);
            return (result is null)
                ? throw new EntityNotFoundException($"VoltageTransformer with Id='{id}' not found!")
                : result;
        }

        public async Task<VoltageTransformer> GetByIdAsync(Guid id)
        {
            Log.Debug("Get VoltageTransformer by Id: '{Id}'", id);
            var result = await _context.VoltageTransformers
                .AsNoTracking()
                .Include(b => b.ControlPoint)
                .SingleOrDefaultAsync(b => b.Id == id);
            return (result is null)
                ? throw new EntityNotFoundException($"VoltageTransformer with Id='{id}' not found!")
                : result;
        }

        public async Task<VoltageTransformerDto> GetDtoByControlPointId(Guid id)
        {
            Log.Debug("Get GetDtoByControlPointId by Id: '{id}'", id);
            var result = await _context.VoltageTransformers
                .AsNoTracking()
                .Include(b => b.ControlPoint)
                .Where(s => s.ControlPointId == id)
                .Select(s => new VoltageTransformerDto(s))
                .SingleOrDefaultAsync();
            if (result is null) throw new EntityNotFoundException($"VoltageTransformer with ControlPointId = '{id}' not found!");
            return result;
        }

        public async Task<VoltageTransformerDto> GetDtoByIdAsync(Guid Id)
        {
            Log.Debug("Get VoltageTransformerDto by Id: '{Id}'", Id);
            var result = await _context.VoltageTransformers
                .AsNoTracking()
                .Include(b => b.ControlPoint)
                .Where(s => s.Id == Id)
                .Select(s => new VoltageTransformerDto(s))
                .SingleOrDefaultAsync();
            if (result is null) throw new EntityNotFoundException($"VoltageTransformer with ID = '{Id}' not found!");
            return result;
        }

        public async Task<bool> SetStatus(Guid id, Status newStatus)
        {
            Log.Debug("Setting new Status= '{newStatus}' for VoltageTransformer ID= '{id}'", newStatus, id);
            var obj = await GetByIdAsync(id);
            obj.Status = newStatus;
            _context.VoltageTransformers.Attach(obj);
            _context.Entry(obj).Property(x => x.Status).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<VoltageTransformer> UpdateAsync(VoltageTransformer entity)
        {
            Log.Debug("Updating VoltageTransformer: '{entity}'", entity);
            _context.VoltageTransformers.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
