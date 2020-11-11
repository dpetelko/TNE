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
    public class BillingPointRepositoryImpl : IBillingPointRepository
    {
        private readonly DatabaseContext _context;

        public BillingPointRepositoryImpl(DatabaseContext context)
        {
            _context = context;
        }

        public void CheckExistsById(Guid id)
        {
            Log.Debug("Check exists BillingPoint by Id: '{Id}'", id);
            bool result = _context.BillingPoints.Any(b => b.Id == id);
            if (!result)
            {
                throw new EntityNotFoundException($"BillingPoint with Id='{id}' not exist!");
            }
        }

        public async Task<BillingPoint> CreateAsync(BillingPoint entity)
        {
            Log.Debug("Creating BillingPoint: {entity}", entity);
            _context.BillingPoints.Add(entity);
            await _context.SaveChangesAsync();
            await _context.Entry(entity)
                .Reference(c => c.ControlPoint)
                .LoadAsync();
            await _context.Entry(entity)
                .Reference(c => c.DeliveryPoint)
                .LoadAsync();
            return entity;
        }

        public bool ExistsByField(string fieldName, object fieldValue)
        {
            Log.Debug("ExistsByField BillingPoint: field name - '{fieldName}', value = '{fieldValue}' ", fieldName,
                fieldValue);
            return _context.BillingPoints
                .AsNoTracking()
                .Select(x => x.GetType().GetProperty(fieldName).GetValue(x).Equals(fieldValue))
                .ToList().Count != 0;
        }

        public bool ExistsByFieldAndNotId(Guid id, string fieldName, object fieldValue)
        {
            Log.Debug(
                "ExistsByFieldAndNotId BillingPoint: Id - '{id}', field name - '{fieldName}', value = '{fieldValue}' ",
                id, fieldName, fieldValue);
            return _context.BillingPoints
                .AsNoTracking()
                .Where(s => s.Id != id)
                .Select(x => x.GetType().GetProperty(fieldName).GetValue(x).Equals(fieldValue))
                .ToList().Count != 0;
        }

        public async Task<List<BillingPointDto>> GetAllDtoAsync()
        {
            Log.Debug("GetAll BillingPointDto");
            var result = await _context.BillingPoints
                .AsNoTracking()
                .Include(b => b.ControlPoint)
                .Include(b => b.DeliveryPoint)
                .Select(s => new BillingPointDto(s))
                .ToListAsync();
            result.TrimExcess();
            return result;
        }

        public async Task<List<BillingPointDto>> GetAllDtoByControlPointIdAsync(Guid id)
        {
            Log.Debug("Get GetAllDtoByControlPointIdAsync by ID: '{id}'", id);
            var result = await _context.BillingPoints
                .AsNoTracking()
                .Include(b => b.ControlPoint)
                .Include(b => b.DeliveryPoint)
                .Where(s => s.ControlPointId == id)
                .Select(s => new BillingPointDto(s))
                .ToListAsync();
            result.TrimExcess();
            return result;
        }

        public async Task<List<BillingPointDto>> GetAllDtoByDeliveryPointIdAsync(Guid id)
        {
            Log.Debug("Get GetAllDtoByDeliveryPointIdAsync by ID: '{id}'", id);
            var result = await _context.BillingPoints
                .AsNoTracking()
                .Include(b => b.ControlPoint)
                .Include(b => b.DeliveryPoint)
                .Where(s => s.DeliveryPointId == id)
                .Select(s => new BillingPointDto(s))
                .ToListAsync();
            result.TrimExcess();
            return result;
        }

        public BillingPoint GetById(Guid id)
        {
            Log.Debug("Get BillingPoint by Id: '{Id}'", id);
            var result = _context.BillingPoints
                .AsNoTracking()
                .Include(b => b.ControlPoint)
                .Include(b => b.DeliveryPoint)
                .SingleOrDefault(b => b.Id == id);
            return (result is null)
                ? throw new EntityNotFoundException($"BillingPoint with Id='{id}' not found!")
                : result;
        }

        public async Task<BillingPoint> GetByIdAsync(Guid id)
        {
            Log.Debug("Get BillingPoint by Id: '{Id}'", id);
            var result = await _context.BillingPoints
                .AsNoTracking()
                .Include(b => b.ControlPoint)
                .Include(b => b.DeliveryPoint)
                .SingleOrDefaultAsync(b => b.Id == id);
            return (result is null)
                ? throw new EntityNotFoundException($"BillingPoint with Id='{id}' not found!")
                : result;
        }

        public async Task<BillingPointDto> GetDtoByIdAsync(Guid id)
        {
            Log.Debug("Get BillingPointDto by Id: '{Id}'", id);
            var result = await _context.BillingPoints
                .AsNoTracking()
                .Include(b => b.ControlPoint)
                .Include(b => b.DeliveryPoint)
                .Where(s => s.Id == id)
                .Select(s => new BillingPointDto(s))
                .SingleOrDefaultAsync();
            if (result is null) throw new EntityNotFoundException($"BillingPoint with ID = '{id}' not found!");
            return result;
        }

        public async Task<BillingPoint> UpdateAsync(BillingPoint entity)
        {
            Log.Debug("Updating BillingPoint: '{entity}'", entity);
            _context.BillingPoints.Update(entity);
            await _context.SaveChangesAsync();
            await _context.Entry(entity)
                .Reference(c => c.ControlPoint)
                .LoadAsync();
            await _context.Entry(entity)
                .Reference(c => c.DeliveryPoint)
                .LoadAsync();
            return entity;
        }

        public async Task<List<BillingPointDto>> GetAllDtoByFilterAsync(BillingPointFilter searchFilter)
        {
            Log.Debug("GetAllDtoByFilterAsync BillingPointDto by Filter: {searchFilter}", searchFilter);

            var predicate = PredicateBuilder.New<BillingPoint>(true);

            var controlPointId = searchFilter.ControlPointId;
            if (IsNotEmptyOrNull(controlPointId))
                predicate = predicate.And(s => s.ControlPointId == controlPointId);

            var deliveryPointId = searchFilter.DeliveryPointId;
            if (IsNotEmptyOrNull(deliveryPointId))
                predicate = predicate.And(s => s.DeliveryPointId == deliveryPointId);

            var startTime = searchFilter.StartTime;
            if (startTime.HasValue)
                predicate = predicate.And(s => DateTime.Compare(s.StartTime, (DateTime)startTime) >= 0);

            var endTime = searchFilter.EndTime;
            if (endTime.HasValue)
                predicate = predicate.And(s => DateTime.Compare(s.EndTime, (DateTime)endTime) <= 0);

            var result = await _context.BillingPoints
                .AsNoTracking()
                .Include(s => s.ControlPoint)
                .Include(s => s.DeliveryPoint)
                .Where(predicate)
                .Select(s => new BillingPointDto(s))
                .ToListAsync();
            result.TrimExcess();
            return result;
        }

        private static bool IsNotEmptyOrNull(Guid? id) => id != null && id != Guid.Empty;
    }
}