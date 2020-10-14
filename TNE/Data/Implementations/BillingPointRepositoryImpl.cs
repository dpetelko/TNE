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
    public class BillingPointRepositoryImpl : IBillingPointRepository
    {
        private readonly DatabaseContext _context;

        public BillingPointRepositoryImpl(DatabaseContext context) {  _context = context; }

        public void CheckExistsById(Guid id)
        {
            Log.Debug("Check exists BillingPoint by Id: '{Id}'", id);
            bool result = _context.BillingPoints.Any(b => b.Id == id);
            if (!result) { throw new EntityNotFoundException($"BillingPoint with Id='{id}' not exist!"); }
        }

        public async Task<BillingPoint> CreateAsync(BillingPoint entity)
        {
            Log.Debug("Creating BillingPoint: {entity}", entity);
            _context.BillingPoints.Add(entity);
            await _context.SaveChangesAsync();
            _context.Entry(entity)
               .Reference(c => c.ControlPoint)
               .Load();
            _context.Entry(entity)
                .Reference(c => c.DeliveryPoint)
                .Load();
            return entity;
        }

        public bool ExistsByField(string fieldName, object fieldValue)
        {
            Log.Debug("ExistsByField BillingPoint: field name - '{fieldName}', value = '{fieldValue}' ", fieldName, fieldValue);
            return _context.BillingPoints.FromSqlRaw($"SELECT * FROM dbo.BillingPoints WHERE {fieldName}='{fieldValue}'").Count() == 0;

        }

        public bool ExistsByFieldAndNotId(Guid id, string fieldName, object fieldValue)
        {
            Log.Debug("ExistsByFieldAndNotId BillingPoint: Id - 'id', field name - '{fieldName}', value = '{fieldValue}' ", id, fieldName, fieldValue);
            return _context.BillingPoints.FromSqlRaw($"SELECT * FROM dbo.BillingPoints WHERE {fieldName}='{fieldValue}' AND Id <> '{id}'").Count() == 0;

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

        public async Task<BillingPointDto> GetDtoByIdAsync(Guid Id)
        {
            Log.Debug("Get BillingPointDto by Id: '{Id}'", Id);
            var result = await _context.BillingPoints
                .AsNoTracking()
                .Include(b => b.ControlPoint)
                .Include(b => b.DeliveryPoint)
                .Where(s => s.Id == Id)
                .Select(s => new BillingPointDto(s))
                .SingleOrDefaultAsync();
            if (result is null) throw new EntityNotFoundException($"BillingPoint with ID = '{Id}' not found!");
            return result;
        }

        public async Task<BillingPoint> UpdateAsync(BillingPoint entity)
        {
            Log.Debug("Updating BillingPoint: '{entity}'", entity);
            _context.BillingPoints.Update(entity);
            await _context.SaveChangesAsync();
            _context.Entry(entity)
               .Reference(c => c.ControlPoint)
               .Load();
            _context.Entry(entity)
                .Reference(c => c.DeliveryPoint)
                .Load();
            return entity;
        }
    }
}
