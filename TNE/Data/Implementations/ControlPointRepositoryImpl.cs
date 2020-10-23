using LinqKit;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNE.Data.Exceptions;
using TNE.Dtos;
using TNE.Dtos.SearchFilters;
using TNE.Models;

namespace TNE.Data.Implementations
{
    public class ControlPointRepositoryImpl : IControlPointRepository
    {
        private readonly DatabaseContext _context;

        public ControlPointRepositoryImpl(DatabaseContext context)
        {
            _context = context;
        }

        public void CheckExistsById(Guid id)
        {
            Log.Debug("Check exists ControlPoint by Id: '{Id}'", id);
            var result = _context.ControlPoints.Any(b => b.Id == id);
            if (!result)
            {
                throw new EntityNotFoundException($"ControlPoint with Id='{id}' not exist!");
            }
        }

        public async Task<ControlPoint> CreateAsync(ControlPoint entity)
        {
            Log.Debug("Creating ControlPoint: {entity}", entity);

            var currentTransformer =
                await _context.CurrentTransformers.SingleOrDefaultAsync(b => b.Id == entity.CurrentTransformerId);
            var voltageTransformer =
                await _context.VoltageTransformers.SingleOrDefaultAsync(b => b.Id == entity.VoltageTransformerId);
            var electricityMeter =
                await _context.ElectricityMeters.SingleOrDefaultAsync(b => b.Id == entity.ElectricityMeterId);
            if (currentTransformer != null && voltageTransformer != null && electricityMeter != null)
            {
                currentTransformer.Status = Status.InWork;
                voltageTransformer.Status = Status.InWork;
                electricityMeter.Status = Status.InWork;
            }
            else
            {
                throw new InvalidEntityException();
            }

            await _context.ControlPoints.AddAsync(entity);
            await _context.SaveChangesAsync();
            currentTransformer.ControlPointId = entity.Id;
            voltageTransformer.ControlPointId = entity.Id;
            electricityMeter.ControlPointId = entity.Id;
            await _context.SaveChangesAsync();
            await _context.Entry(entity)
                .Reference(c => c.Provider)
                .LoadAsync();
            return entity;
        }

        public async Task<ControlPoint> UpdateAsync(ControlPoint entity)
        {
            Log.Debug("Updating ControlPoint '{entity}'", entity);
            var oldEntity = await _context.ControlPoints.AsNoTracking().SingleOrDefaultAsync(b => b.Id == entity.Id);
            var oldCurrentTransformer =
                await _context.CurrentTransformers.SingleOrDefaultAsync(b => b.Id == oldEntity.CurrentTransformerId);
            var oldVoltageTransformer =
                await _context.VoltageTransformers.SingleOrDefaultAsync(b => b.Id == oldEntity.VoltageTransformerId);
            var oldElectricityMeter =
                await _context.ElectricityMeters.SingleOrDefaultAsync(b => b.Id == oldEntity.ElectricityMeterId);
            if (oldCurrentTransformer != null && oldVoltageTransformer != null && oldElectricityMeter != null)
            {
                oldCurrentTransformer.Status = Status.InStorage;
                oldVoltageTransformer.Status = Status.InStorage;
                oldElectricityMeter.Status = Status.InStorage;
                oldCurrentTransformer.ControlPointId = null;
                oldVoltageTransformer.ControlPointId = null;
                oldElectricityMeter.ControlPointId = null;
            }
            else
            {
                throw new InvalidEntityException();
            }

            var newCurrentTransformer =
                await _context.CurrentTransformers.SingleOrDefaultAsync(b => b.Id == entity.CurrentTransformerId);
            var newVoltageTransformer =
                await _context.VoltageTransformers.SingleOrDefaultAsync(b => b.Id == entity.VoltageTransformerId);
            var newElectricityMeter =
                await _context.ElectricityMeters.SingleOrDefaultAsync(b => b.Id == entity.ElectricityMeterId);
            if (newCurrentTransformer != null && newVoltageTransformer != null && newElectricityMeter != null)
            {
                newCurrentTransformer.Status = Status.InWork;
                newVoltageTransformer.Status = Status.InWork;
                newElectricityMeter.Status = Status.InWork;
                newCurrentTransformer.ControlPointId = entity.Id;
                newVoltageTransformer.ControlPointId = entity.Id;
                newElectricityMeter.ControlPointId = entity.Id;
            }
            else
            {
                throw new InvalidEntityException();
            }

            _context.ControlPoints.Update(entity);
            await _context.SaveChangesAsync();
            await _context.Entry(entity)
                .Reference(c => c.Provider)
                .LoadAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Log.Debug("Deleting ControlPoint ID = {id}", id);
            var obj = await GetByIdAsync(id);
            obj.Deleted = true;
            _context.ControlPoints.Attach(obj);
            _context.Entry(obj).Property(x => x.Deleted).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public bool ExistsByField(string fieldName, object fieldValue)
        {
            Log.Debug("ExistsByField ControlPoint: field name - '{fieldName}', value = '{fieldValue}' ", fieldName,
                fieldValue);
            return _context.ControlPoints
                .AsNoTracking()
                .Select(x => x.GetType().GetProperty(fieldName).GetValue(x).Equals(fieldValue))
                .ToList().Count != 0;
        }

        public bool ExistsByFieldAndNotId(Guid id, string fieldName, object fieldValue)
        {
            Log.Debug(
                "ExistsByFieldAndNotId ControlPoint: Id - '{id}', field name - '{fieldName}', value = '{fieldValue}' ",
                id, fieldName, fieldValue);
            return _context.ControlPoints
                .AsNoTracking()
                .Where(s => s.Id != id)
                .Select(x => x.GetType().GetProperty(fieldName).GetValue(x).Equals(fieldValue))
                .ToList().Count != 0;
        }

        public async Task<List<ControlPointDto>> GetAllActiveDtoAsync()
        {
            Log.Debug("GetAllActive ControlPointDto");
            var result = await _context.ControlPoints
                .AsNoTracking()
                .Include(s => s.Provider)
                .Where(s => s.Deleted == false)
                .Select(s => new ControlPointDto(s))
                .ToListAsync();
            result.TrimExcess();
            return result;
        }

        public async Task<List<ControlPointDto>> GetAllDtoAsync()
        {
            Log.Debug("GetAll ControlPointDto");
            var result = await _context.ControlPoints
                .AsNoTracking()
                .Include(s => s.Provider)
                .Select(s => new ControlPointDto(s))
                .ToListAsync();
            result.TrimExcess();
            return result;
        }

        public ControlPoint GetById(Guid id)
        {
            Log.Debug("Get ControlPoint by Id: '{Id}'", id);
            var result = _context.ControlPoints
                .AsNoTracking()
                .Include(s => s.Provider)
                .SingleOrDefault(b => b.Id == id);
            return (result is null)
                ? throw new EntityNotFoundException($"ControlPoint with Id='{id}' not found!")
                : result;
        }

        public async Task<ControlPoint> GetByIdAsync(Guid id)
        {
            Log.Debug("Get ControlPoint by Id: '{Id}'", id);
            var result = await _context.ControlPoints
                .AsNoTracking()
                .Include(s => s.Provider)
                .SingleOrDefaultAsync(b => b.Id == id);
            return (result is null)
                ? throw new EntityNotFoundException($"ControlPoint with Id='{id}' not found!")
                : result;
        }

        public async Task<ControlPointDto> GetDtoByIdAsync(Guid id)
        {
            Log.Debug("Get ControlPointDto by Id: '{id}'", id);
            var result = await _context.ControlPoints
                .AsNoTracking()
                .Include(s => s.Provider)
                .Where(s => s.Id == id)
                .Select(s => new ControlPointDto(s))
                .SingleOrDefaultAsync();
            if (result is null) throw new EntityNotFoundException($"ControlPoint with ID = '{id}' not found!");
            return result;
        }

        public async Task<bool> UndeleteAsync(Guid id)
        {
            Log.Debug("Undeleting ControlPoint ID = {id}", id);
            var obj = await GetByIdAsync(id);
            obj.Deleted = false;
            _context.ControlPoints.Attach(obj);
            _context.Entry(obj).Property(x => x.Deleted).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ControlPointDto>> GetAllDtoByProviderIdAsync(Guid id)
        {
            Log.Debug("Get GetAllDtoByProviderIdAsync by Id: '{id}'", id);
            var result = await _context.ControlPoints
                .AsNoTracking()
                .Include(s => s.Provider)
                .Where(s => s.ProviderId == id)
                .Select(s => new ControlPointDto(s))
                .ToListAsync();
            result.TrimExcess();
            return result;
        }
    }
}