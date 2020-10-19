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

        public ControlPointRepositoryImpl(DatabaseContext context) { _context = context; }

        public void CheckExistsById(Guid id)
        {
            Log.Debug("Check exists ControlPoint by Id: '{Id}'", id);
            bool result = _context.ControlPoints.Any(b => b.Id == id);
            if (!result) { throw new EntityNotFoundException($"ControlPoint with Id='{id}' not exist!"); }
        }

        public async Task<ControlPoint> CreateAsync(ControlPoint entity)
        {
            Log.Debug("Creating ControlPoint: {entity}", entity);
            _context.ControlPoints.Add(entity);
            await _context.SaveChangesAsync();
            _context.Entry(entity)
                .Reference(c => c.Provider)
                .Load();
            _context.Entry(entity)
                .Reference(c => c.CurrentTransformer)
                .Load();
            _context.Entry(entity)
                .Reference(c => c.VoltageTransformer)
                .Load();
            _context.Entry(entity)
                .Reference(c => c.ElectricityMeter)
                .Load();
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
            Log.Debug("ExistsByField ControlPoint: field name - '{fieldName}', value = '{fieldValue}' ", fieldName, fieldValue);
            return _context.ControlPoints
                .AsNoTracking()
                .Select(x => x.GetType().GetProperty(fieldName).GetValue(x).Equals(fieldValue))
                .ToList().Count != 0;
        }

        public bool ExistsByFieldAndNotId(Guid id, string fieldName, object fieldValue)
        {
            Log.Debug("ExistsByFieldAndNotId ControlPoint: Id - '{id}', field name - '{fieldName}', value = '{fieldValue}' ", id, fieldName, fieldValue);
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
                .Include(s => s.CurrentTransformer)
                .Include(s => s.VoltageTransformer)
                .Include(s => s.ElectricityMeter)
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
                .Include(s => s.CurrentTransformer)
                .Include(s => s.VoltageTransformer)
                .Include(s => s.ElectricityMeter)
                .Select(s => new ControlPointDto(s))
                .ToListAsync();
            result.TrimExcess();
            return result;
        }

        public ControlPoint GetById(Guid id)
        {
            Log.Debug("Get ControlPoint by Id: '{Id}'", id);
            var result = _context.ControlPoints.AsNoTracking()
                .Include(s => s.Provider)
                .Include(s => s.CurrentTransformer)
                .Include(s => s.VoltageTransformer)
                .Include(s => s.ElectricityMeter)
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
                .Include(s => s.CurrentTransformer)
                .Include(s => s.VoltageTransformer)
                .Include(s => s.ElectricityMeter)
                .SingleOrDefaultAsync(b => b.Id == id);
            return (result is null)
                ? throw new EntityNotFoundException($"ControlPoint with Id='{id}' not found!")
                : result;
        }

        public async Task<ControlPointDto> GetDtoByIdAsync(Guid Id)
        {
            Log.Debug("Get ControlPointDto by Id: '{Id}'", Id);
            var result = await _context.ControlPoints.AsNoTracking()
                .Include(s => s.Provider)
                .Include(s => s.CurrentTransformer)
                .Include(s => s.VoltageTransformer)
                .Include(s => s.ElectricityMeter)
                .Where(s => s.Id == Id)
                .Select(s => new ControlPointDto(s))
                .SingleOrDefaultAsync();
            if (result is null) throw new EntityNotFoundException($"ControlPoint with ID = '{Id}' not found!");
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

        public async Task<ControlPoint> UpdateAsync(ControlPoint entity)
        {
            Log.Debug("Updating ControlPoint: '{entity}'", entity);
            _context.ControlPoints.Update(entity);
            await _context.SaveChangesAsync();
            _context.Entry(entity)
               .Reference(c => c.Provider)
               .Load();
            _context.Entry(entity)
                .Reference(c => c.CurrentTransformer)
                .Load();
            _context.Entry(entity)
                .Reference(c => c.VoltageTransformer)
                .Load();
            _context.Entry(entity)
                .Reference(c => c.ElectricityMeter)
                .Load();
            return entity;
        }

        

        public async Task<List<ControlPointDto>> GetAllDtoByProviderIdAsync(Guid id)
        {
            Log.Debug("Get GetAllDtoByProviderIdAsync by Id: '{id}'", id);
            var result = await _context.ControlPoints.AsNoTracking()
                .Include(s => s.Provider)
                .Include(s => s.CurrentTransformer)
                .Include(s => s.VoltageTransformer)
                .Include(s => s.ElectricityMeter)
                .Where(s => s.ProviderId == id)
                .Select(s => new ControlPointDto(s))
                .ToListAsync();
            result.TrimExcess();
            return result;
        }

        public async Task<List<ControlPointDto>> GetAllDtoByFilterAsync(DeviceCalibrationControlDto filter)
        {
            Log.Debug("GetAllDtoByFilterAsync ControlPointDto by Filter: {searchFilter}", filter);

            var predicate = PredicateBuilder.New<ControlPoint>();

            Guid? providerId = filter.ProviderId;
            if (IsNotEmptyOrNull(providerId))
                predicate = predicate.And(s => s.Provider.Id == providerId);

            //DateTime? electricityMeterCheckDate = filter.ElectricityMeterCheckDate;
            //if (electricityMeterCheckDate.HasValue)
            //    predicate = predicate.And(s => DateTime.Compare(s.ElectricityMeter.LastVerificationDate.AddDays(s.ElectricityMeter.InterTestingPeriodInDays), (DateTime)electricityMeterCheckDate) <= 0);

            //DateTime? currentTransformerCheckDate = filter.CurrentTransformerCheckDate;
            //if (currentTransformerCheckDate.HasValue)
            //    predicate = predicate.And(s => DateTime.Compare(s.CurrentTransformer.LastVerificationDate.AddDays(s.CurrentTransformer.InterTestingPeriodInDays), (DateTime)currentTransformerCheckDate) <= 0);


            //DateTime? voltageTransformerCheckDate = filter.VoltageTransformerCheckDate;
            //if (voltageTransformerCheckDate.HasValue)
            //    predicate = predicate.And(s => DateTime.Compare(s.VoltageTransformer.LastVerificationDate.AddDays(s.VoltageTransformer.InterTestingPeriodInDays), (DateTime)voltageTransformerCheckDate) <= 0);

            var result = await _context.ControlPoints
                .AsNoTracking()
                .Include(s => s.Provider)
                .Include(s => s.CurrentTransformer)
                .Include(s => s.VoltageTransformer)
                .Include(s => s.ElectricityMeter)
                .Where(predicate)
                .Select(s => new ControlPointDto(s))
                .ToListAsync();
            return result;
        }

        private static bool IsNotEmptyOrNull(Guid? id) => id != null && id != Guid.Empty;
    }
}
