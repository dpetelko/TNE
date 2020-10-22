using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqKit;
using TNE.Data.Exceptions;
using TNE.Dtos;
using TNE.Dtos.SearchFilters;
using TNE.Models;

namespace TNE.Data.Implementations
{
    public class ElectricityMeterRepositoryImpl : IElectricityMeterRepository
    {
        private readonly DatabaseContext _context;

        public ElectricityMeterRepositoryImpl(DatabaseContext context) { _context = context; }

        public void CheckExistsById(Guid id)
        {
            Log.Debug("Check exists ElectricityMeter by Id: '{Id}'", id);
            bool result = _context.ElectricityMeters.Any(b => b.Id == id);
            if (!result) { throw new EntityNotFoundException($"ElectricityMeter with Id='{id}' not exist!"); }
        }

        public async Task<ElectricityMeter> CreateAsync(ElectricityMeter entity)
        {
            Log.Debug("Creating ElectricityMeter: {entity}", entity);
            _context.ElectricityMeters.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public bool ExistsByField(string fieldName, object fieldValue)
        {
            Log.Debug("ExistsByField ElectricityMeter: field name - '{fieldName}', value = '{fieldValue}' ", fieldName, fieldValue);
            return _context.ElectricityMeters
                .AsNoTracking()
                .Select(x => x.GetType().GetProperty(fieldName).GetValue(x).Equals(fieldValue))
                .ToList().Count != 0;
        }

        public bool ExistsByFieldAndNotId(Guid id, string fieldName, object fieldValue)
        {
            Log.Debug("ExistsByFieldAndNotId ElectricityMeter: Id - '{id}', field name - '{fieldName}', value = '{fieldValue}' ", id, fieldName, fieldValue);
            return _context.ElectricityMeters
                .AsNoTracking()
                .Where(s => s.Id != id)
                .Select(x => x.GetType().GetProperty(fieldName).GetValue(x).Equals(fieldValue))
                .ToList().Count != 0;
        }

        public async Task<List<ElectricityMeterDto>> GetAllDtoAsync()
        {
            Log.Debug("GetAll ElectricityMeterDto");
            var result = await _context.ElectricityMeters
                .AsNoTracking()
                .Include(s => s.ControlPoint)
                .Select(s => new ElectricityMeterDto(s))
                .ToListAsync();
            result.TrimExcess();
            return result;
        }
        
        public async Task<List<ElectricityMeterDto>> GetAllDtoByFilterAsync(DeviceCalibrationControlDto filter)
        {
            Log.Debug("GetAllDtoByFilterAsync ElectricityMeterDto by Filter: {filter}", filter);

            var predicate = PredicateBuilder.New<ElectricityMeter>(true);

            var providerId = filter.ProviderId;
            if (IsNotEmptyOrNull(providerId))
                predicate = predicate.And(s => s.ControlPoint.Provider.Id == filter.ProviderId);

            var checkDate = filter.CheckDate;
            if (checkDate.HasValue)
                predicate = predicate.And(s => (DateTime.Compare(s.LastVerificationDate.AddDays(s.InterTestingPeriodInDays), (DateTime)filter.CheckDate) < 0));

            var result = await _context.ElectricityMeters
                .AsNoTracking()
                .Include(s => s.ControlPoint)
                .Where(predicate)
                .Select(s => new ElectricityMeterDto(s))
                .ToListAsync();
            result.TrimExcess();
            return result;
        }

        public async Task<List<ElectricityMeterDto>> GetAllDtoByStatusAsync(Status status)
        {
            Log.Debug("GetAll ElectricityMeterDto");
            var result = await _context.ElectricityMeters
                .AsNoTracking()
                .Include(s => s.ControlPoint)
                .Where(s => s.Status == status)
                .Select(s => new ElectricityMeterDto(s))
                .ToListAsync();
            result.TrimExcess();
            return result;
        }

        public ElectricityMeter GetById(Guid id)
        {
            Log.Debug("Get ElectricityMeter by Id: '{Id}'", id);
            var result = _context.ElectricityMeters
                .AsNoTracking()
                .Include(b => b.ControlPoint)
                .SingleOrDefault(b => b.Id == id);
            return (result is null)
                ? throw new EntityNotFoundException($"ElectricityMeter with Id='{id}' not found!")
                : result;
        }

        public async Task<ElectricityMeter> GetByIdAsync(Guid id)
        {
            Log.Debug("Get ElectricityMeter by Id: '{Id}'", id);
            var result = await _context.ElectricityMeters
                .AsNoTracking()
                .Include(b => b.ControlPoint)
                .SingleOrDefaultAsync(b => b.Id == id);
            return (result is null)
                ? throw new EntityNotFoundException($"ElectricityMeter with Id='{id}' not found!")
                : result;
        }

        public async Task<ElectricityMeterDto> GetDtoByControlPointId(Guid id)
        {
            Log.Debug("Get GetDtoByControlPointId by Id: '{id}'", id);
            var result = await _context.ElectricityMeters
                .AsNoTracking()
                .Include(b => b.ControlPoint)
                .Where(s => s.ControlPoint.Id == id)
                .Select(s => new ElectricityMeterDto(s))
                .SingleOrDefaultAsync();
            if (result is null) throw new EntityNotFoundException($"ElectricityMeter with ControlPointId = '{id}' not found!");
            return result;
        }

        public async Task<ElectricityMeterDto> GetDtoByIdAsync(Guid id)
        {
            Log.Debug("Get ElectricityMeterDto by Id: '{id}'", id);
            var result = await _context.ElectricityMeters
                .AsNoTracking()
                .Include(b => b.ControlPoint)
                .Where(s => s.Id == id)
                .Select(s => new ElectricityMeterDto(s))
                .SingleOrDefaultAsync();
            if (result is null) throw new EntityNotFoundException($"ElectricityMeter with ID = '{id}' not found!");
            return result;
        }

        public async Task<bool> SetStatus(Guid id, Status newStatus)
        {
            Log.Debug("Setting new Status= '{newStatus}' for ElectricityMeter ID= '{id}'", newStatus, id);
            var obj = await GetByIdAsync(id);
            obj.Status = newStatus;
            _context.ElectricityMeters.Attach(obj);
            _context.Entry(obj).Property(x => x.Status).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ElectricityMeter> UpdateAsync(ElectricityMeter entity)
        {
            Log.Debug("Updating ElectricityMeter: '{entity}'", entity);
            _context.ElectricityMeters.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        
        private static bool IsNotEmptyOrNull(Guid? id) => id != null && id != Guid.Empty;
        
        public async Task<ElectricityMeter> GetByIdAsyncWithTracking(Guid id)
        {
            Log.Debug("Get ElectricityMeter by Id: '{id}'", id);
            var result = await _context.ElectricityMeters
                //.Include(b => b.ControlPoint)
                .SingleOrDefaultAsync(b => b.Id == id);
            return (result is null)
                ? throw new EntityNotFoundException($"CurrentTransformer with id='{id}' not found!")
                : result;
        }
    }
}
