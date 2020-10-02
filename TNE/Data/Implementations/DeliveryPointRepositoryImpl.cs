﻿using Microsoft.EntityFrameworkCore;
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
    public class DeliveryPointRepositoryImpl : IDeliveryPointRepository
    {
        private readonly DatabaseContext _context;

        public DeliveryPointRepositoryImpl(DatabaseContext context) { _context = context; }

        public void CheckExistsById(Guid id)
        {
            Log.Debug("Check exists DeliveryPoint by Id: '{Id}'", id);
            bool result = _context.DeliveryPoints.Any(b => b.Id == id);
            if (!result) { throw new EntityNotFoundException($"DeliveryPoint with Id='{id}' not exist!"); }
        }

        public async Task<DeliveryPoint> CreateAsync(DeliveryPoint entity)
        {
            Log.Debug("Creating DeliveryPoint: {entity}", entity);
            _context.DeliveryPoints.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Log.Debug("Deleting DeliveryPoint ID = {id}", id);
            var obj = new DeliveryPoint { Id = id, Deleted = true };
            _context.DeliveryPoints.Attach(obj);
            _context.Entry(obj).Property(x => x.Deleted).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public bool ExistsByField(string fieldName, object fieldValue)
        {
            Log.Debug("ExistsByField DeliveryPoint: field name - '{fieldName}', value = '{fieldValue}' ", fieldName, fieldValue);
            return _context.DeliveryPoints.FromSqlRaw($"SELECT * FROM dbo.DeliveryPoints WHERE {fieldName}='{fieldValue}'").Count() == 0;
        }

        public bool ExistsByFieldAndNotId(Guid id, string fieldName, object fieldValue)
        {
            Log.Debug("ExistsByFieldAndNotId DeliveryPoint: Id - 'id', field name - '{fieldName}', value = '{fieldValue}' ", id, fieldName, fieldValue);
            return _context.Providers.FromSqlRaw($"SELECT * FROM dbo.DeliveryPoints WHERE {fieldName}='{fieldValue}' AND Id <> '{id}'").Count() == 0;
        }

        public async Task<List<DeliveryPointDto>> GetAllActiveDtoAsync()
        {
            Log.Debug("GetAllActive DeliveryPointDto");
            var result = await _context.DeliveryPoints
                .AsNoTracking()
                .Include(s => s.Provider)
                .Where(s => s.Deleted == false)
                .Select(s => new DeliveryPointDto(s))
                .ToListAsync();
            result.TrimExcess();
            return result;
        }

        public async Task<List<DeliveryPointDto>> GetAllDtoAsync()
        {
            Log.Debug("GetAll DeliveryPointDto");
            var result = await _context.DeliveryPoints
                .AsNoTracking()
                .Include(s => s.Provider)
                .Select(s => new DeliveryPointDto(s))
                .ToListAsync();
            result.TrimExcess();
            return result;
        }

        public DeliveryPoint GetById(Guid id)
        {
            Log.Debug("Get DeliveryPoint by Id: '{Id}'", id);
            var result = _context.DeliveryPoints
                .AsNoTracking()
                .Include(b => b.Provider)
                .SingleOrDefault(b => b.Id == id);
            return (result is null)
                ? throw new EntityNotFoundException($"DeliveryPoint with Id='{id}' not found!")
                : result;
        }

        public async Task<DeliveryPoint> GetByIdAsync(Guid id)
        {
            Log.Debug("Get DeliveryPoint by Id: '{Id}'", id);
            var result = await _context.DeliveryPoints
                .AsNoTracking()
                .Include(b => b.Provider)
                .SingleOrDefaultAsync(b => b.Id == id);
            return (result is null)
                ? throw new EntityNotFoundException($"DeliveryPoint with Id='{id}' not found!")
                : result;
        }

        public async Task<DeliveryPointDto> GetDtoByIdAsync(Guid Id)
        {
            Log.Debug("Get DeliveryPointDto by Id: '{Id}'", Id);
            var result = await _context.DeliveryPoints
                .AsNoTracking()
                .Include(s => s.Provider)
                .Where(s => s.Id == Id)
                .Select(s => new DeliveryPointDto(s))
                .SingleOrDefaultAsync();
            if (result is null) throw new EntityNotFoundException($"DeliveryPoint with ID = '{Id}' not found!");
            return result;
        }

        public async Task<bool> UndeleteAsync(Guid id)
        {
            Log.Debug("Undeleting DeliveryPoint ID = {id}", id);
            var obj = new DeliveryPoint { Id = id, Deleted = false };
            _context.DeliveryPoints.Attach(obj);
            _context.Entry(obj).Property(x => x.Deleted).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<DeliveryPoint> UpdateAsync(DeliveryPoint entity)
        {
            Log.Debug("Updating DeliveryPoint: '{entity}'", entity);
            _context.DeliveryPoints.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
