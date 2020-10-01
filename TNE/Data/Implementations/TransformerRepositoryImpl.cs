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
    public class TransformerRepositoryImpl : ITransformerRepository
    {
        private readonly DatabaseContext _context;

        public TransformerRepositoryImpl(DatabaseContext context) { _context = context; }

        public void CheckExistsById(Guid id)
        {
            Log.Debug("Check exists Transformer by Id: '{Id}'", id);
            bool result = _context.SubDivisions.Any(b => b.Id == id);
            if (!result) { throw new EntityNotFoundException($"SubDivision with Id='{id}' not exist!"); }
        }

        public async Task<Transformer> CreateAsync(Transformer entity)
        {
            Log.Debug("Creating Transformer: {entity}", entity);
            _context.Transformers.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public bool ExistsByField(string fieldName, object fieldValue)
        {
            Log.Debug("ExistsByField Transformer: field name - '{fieldName}', value = '{fieldValue}' ", fieldName, fieldValue);
            return _context.Transformers.FromSqlRaw($"SELECT * FROM dbo.Transformers WHERE {fieldName}='{fieldValue}'").Count() == 0;
        }

        public bool ExistsByFieldAndNotId(Guid id, string fieldName, object fieldValue)
        {
            Log.Debug("ExistsByFieldAndNotId Transformer: Id - 'id', field name - '{fieldName}', value = '{fieldValue}' ", id, fieldName, fieldValue);
            return _context.Transformers.FromSqlRaw($"SELECT * FROM dbo.Transformers WHERE {fieldName}='{fieldValue}' AND Id <> '{id}'").Count() == 0;


        }

        public async Task<List<TransformerDto>> GetAllDtoAsync()
        {
            Log.Debug("GetAll TransformerDto");
            var result = await _context.Transformers
                .AsNoTracking()
                .Include(s => s.ControlPoint)
                .Select(s => new TransformerDto
                {
                    Id = s.Id,
                    Number = s.Number,
                    Type = s.Type,
                    VerificationDate = s.VerificationDate,
                    TransformationRate = s.TransformationRate,
                    Status = s.Status,
                    ControlPointId = s.ControlPoint.Id,
                    ControlPointName = s.ControlPoint.Name
                }).ToListAsync();
            result.TrimExcess();
            return result;
        }

        public async Task<List<TransformerDto>> GetAllDtoByStatusAsync(Status status)
        {
            Log.Debug("GetAll TransformerDto");
            var result = await _context.Transformers
                .AsNoTracking()
                .Include(s => s.ControlPoint)
                .Where(s => s.Status == status)
                .Select(s => new TransformerDto
                {
                    Id = s.Id,
                    Number = s.Number,
                    Type = s.Type,
                    VerificationDate = s.VerificationDate,
                    TransformationRate = s.TransformationRate,
                    Status = s.Status,
                    ControlPointId = s.ControlPoint.Id,
                    ControlPointName = s.ControlPoint.Name
                }).ToListAsync();
            result.TrimExcess();
            return result;
        }

        public Transformer GetById(Guid id)
        {
            Log.Debug("Get Transformer by Id: '{Id}'", id);
            var result = _context.Transformers
                .AsNoTracking()
                .Include(b => b.ControlPoint)
                .SingleOrDefault(b => b.Id == id);
            return (result is null)
                ? throw new EntityNotFoundException($"Transformer with Id='{id}' not found!")
                : result;
        }

        public async Task<Transformer> GetByIdAsync(Guid id)
        {
            Log.Debug("Get Transformer by Id: '{Id}'", id);
            var result = await _context.Transformers
                .AsNoTracking()
                .Include(b => b.ControlPoint)
                .SingleOrDefaultAsync(b => b.Id == id);
            return (result is null)
                ? throw new EntityNotFoundException($"Transformer with Id='{id}' not found!")
                : result;
        }

        public async Task<TransformerDto> GetDtoByIdAsync(Guid Id)
        {
            Log.Debug("Get TransformerDto by Id: '{Id}'", Id);
            var result = await _context.Transformers
                .AsNoTracking()
                .Include(b => b.ControlPoint)
                .Where(s => s.Id == Id)
                .Select(s => new TransformerDto
                {
                    Id = s.Id,
                    Number = s.Number,
                    Type = s.Type,
                    VerificationDate = s.VerificationDate,
                    TransformationRate = s.TransformationRate,
                    Status = s.Status,
                    ControlPointId = s.ControlPoint.Id,
                    ControlPointName = s.ControlPoint.Name
                }).SingleOrDefaultAsync();
            if (result is null) throw new EntityNotFoundException($"TransformerDto with ID = '{Id}' not found!");
            return result;
        }

        public async Task<bool> SetStatus(Guid id, Status newStatus)
        {
            Log.Debug("Setting new Status= '{newStatus}' for Transformer ID= '{id}'", newStatus, id);
            var obj = new Transformer { Id = id, Status = newStatus };
            _context.Transformers.Attach(obj);
            _context.Entry(obj).Property(x => x.Status).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Transformer> UpdateAsync(Transformer entity)
        {
            Log.Debug("Updating Transformer: '{entity}'", entity);
            _context.Transformers.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
