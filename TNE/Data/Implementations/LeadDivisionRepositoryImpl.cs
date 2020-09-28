using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TNE.Data.Exceptions;
using TNE.Dto.LeadDivisions;
using TNE.Models;

namespace TNE.Data.Implementations
{
    public class LeadDivisionRepositoryImpl : ILeadDivisionRepository
    {
        private readonly DatabaseContext _context;

        public LeadDivisionRepositoryImpl(DatabaseContext context)
        {
            _context = context;
        }
        //public LeadDivisionRepositoryImpl()
        //{
        //    IConfigurationRoot configuration = new ConfigurationBuilder()
        //    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        //    .AddJsonFile("appsettings.json")
        //    .Build();
        //    var connectionString = configuration.GetConnectionString("DefaultConnection");
        //    var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
        //    optionsBuilder.UseSqlServer(connectionString);
        //    _context = new DatabaseContext(optionsBuilder.Options);
        //}
        public async Task<LeadDivision> CreateAsync(LeadDivision entity)
        {
            Log.Debug("Creating LeadDivision: {entity}", entity);
            _context.LeadDivisions.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async void CheckExistsByIdAsync(Guid Id)
        {
            Log.Debug("Check exists LeadDivision by Id: '{Id}'", Id);
            bool result = await _context.LeadDivisions.AnyAsync(b => b.Id == Id);
            if (!result)
            {
                throw new EntityNotFoundException($"LeadDivision with Id='{Id}' not exist!");
            }
        }

        public async Task<List<LeadDivisionDto>> GetAllDtoAsync()
        {
            Log.Debug("GetAll LeadDivisionDto");
            var result = await _context.LeadDivisions.AsNoTracking().Include(s => s.Address)
                .Select(s => new LeadDivisionDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    AddressId = s.Address.Id,
                    PostCode = s.Address.PostCode,
                    Country = s.Address.Country,
                    Region = s.Address.Region,
                    City = s.Address.City,
                    Street = s.Address.Street,
                    Building = s.Address.Building
                }).ToListAsync();
            result.TrimExcess();
            return result;
        }

        public async Task<LeadDivision> GetByIdAsync(Guid id)
        {
            Log.Debug("Get LeadDivision by Id: '{Id}'", id);
            var result = await _context.LeadDivisions.AsNoTracking().Include(b => b.Address).SingleAsync(b => b.Id == id);
            return (result is null)
                ? throw new EntityNotFoundException($"LeadDivision with Id='{id}' not found!")
                : result;
        }

        public LeadDivision GetById(Guid id)
        {
            Log.Debug("Get LeadDivision by Id: '{Id}'", id);
            var result = _context.LeadDivisions.AsNoTracking().Include(b => b.Address).Single(b => b.Id == id);
            return (result is null)
                ? throw new EntityNotFoundException($"LeadDivision with Id='{id}' not found!")
                : result;
        }

        public async Task<LeadDivisionDto> GetDtoByIdAsync(Guid Id)
        {
            Log.Debug("Get LeadDivisionDto by Id: '{Id}'", Id);
            var result = await _context.LeadDivisions.AsNoTracking().Include(s => s.Address)
                       .Where(s => s.Id == Id)
                       .Select(s => new LeadDivisionDto
                       {
                           Id = s.Id,
                           Name = s.Name,
                           AddressId = s.Address.Id,
                           PostCode = s.Address.PostCode,
                           Country = s.Address.Country,
                           Region = s.Address.Region,
                           City = s.Address.City,
                           Street = s.Address.Street,
                           Building = s.Address.Building
                       }).SingleOrDefaultAsync();
            if (result is null) throw new EntityNotFoundException($"LeadDivision with ID = '{Id}' not found!");
            return result;
        }

        public async Task<LeadDivision> UpdateAsync(LeadDivision entity)
        {
            Log.Debug("Updating LeadDivision: '{entity}'", entity);
            _context.LeadDivisions.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public bool ExistsByField(string fieldName, object fieldValue)
        {
            Log.Debug("ExistsByField LeadDivision: field name - '{fieldName}', value = '{fieldValue}' ", fieldName, fieldValue);

            return fieldName.Equals("Name")
                ? _context.LeadDivisions.FromSqlRaw($"SELECT * FROM dbo.Divisions WHERE {fieldName}='{fieldValue}'").Count() == 0
                : _context.Addresses.FromSqlRaw($"SELECT * FROM dbo.Addresses WHERE {fieldName}='{fieldValue}'").Count() == 0;

        }

        public bool ExistsByFieldAndNotId(Guid id, string fieldName, object fieldValue)
        {
            Log.Debug("ExistsByFieldAndNotId LeadDivision: Id - 'id', field name - '{fieldName}', value = '{fieldValue}' ", id, fieldName, fieldValue);
            var result = _context.LeadDivisions.FromSqlRaw($"SELECT * FROM dbo.Divisions WHERE {fieldName}='{fieldValue}' AND Id != {id}");
            return result.Count() == 0;
        }
    }
}



//public bool Delete(Guid Id)
//{
//    if (ExistsById(Id))
//    {
//        LeadDivision obj = new LeadDivision { Id = Id };
//        _context.LeadDivisions.Remove(obj);
//        _context.SaveChanges();
//    }
//    return true;
//}





//public List<LeadDivision> GetAll()
//{
//    _logger.LogDebug("GetAll LeadDivisions");
//    var result = _context.LeadDivisions.AsNoTracking().Include(b => b.SubDivisions).ToList();
//    result.TrimExcess();
//    return (result.Count == 0)
//        ? throw new EntityNotFoundException("No LeadDivisions found!")
//        : result;
//}
