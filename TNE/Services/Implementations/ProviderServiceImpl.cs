using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNE.Data;
using TNE.Data.Exceptions;
using TNE.Dto;
using TNE.Models;

namespace TNE.Services.Implementations
{
    public class ProviderServiceImpl : IProviderService
    {
        private readonly IProviderRepository _repo;

        public ProviderServiceImpl(IProviderRepository repo) => _repo = repo;

        public void CheckExistsById(Guid id) => _repo.CheckExistsById(id);

        public async Task<ProviderDto> CreateAsync(ProviderDto dto)
        {
            if (!dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must be empty for CREATE!");
            var result = await _repo.CreateAsync(new Provider(dto));
            return new ProviderDto(result);
        }

        public async Task<bool> DeleteAsync(Guid id) 
        {
            CheckExistsById(id);
            return await _repo.DeleteAsync(id);
        }

        public async Task<List<ProviderDto>> GetAllActiveDtoAsync() => await _repo.GetAllActiveDtoAsync();

        public async Task<List<ProviderDto>> GetAllDtoAsync() => await _repo.GetAllDtoAsync();

        public async Task<List<ProviderDto>> GetAllDtoBySubDivisionIdAsync(Guid id) => await _repo.GetAllDtoBySubDivisionIdAsync(id);

        public Provider GetById(Guid id) 
        {
            CheckExistsById(id);
            return _repo.GetById(id); 
        }

        public async Task<Provider> GetByIdAsync(Guid id) 
        {
            CheckExistsById(id);
            return await _repo.GetByIdAsync(id); 
        }

        public async Task<ProviderDto> GetDtoByIdAsync(Guid id)
        {
            CheckExistsById(id);
            return await _repo.GetDtoByIdAsync(id);
        }

        public bool IsFieldUnique(Guid id, string fieldName, object fieldValue)
        {
            return (id.Equals(Guid.Empty))
                ? !_repo.ExistsByField(fieldName, fieldValue)
                : !_repo.ExistsByFieldAndNotId(id, fieldName, fieldValue);
        }

        public async Task<bool> UndeleteAsync(Guid id) 
        {
            CheckExistsById(id);
            return await _repo.UndeleteAsync(id); 
        }

        public async Task<ProviderDto> UpdateAsync(ProviderDto dto)
        {
            if (dto.Id.Equals(Guid.Empty)) throw new InvalidEntityException("ID must can't be empty for UPDATE!");
            CheckExistsById(dto.Id);
            return new ProviderDto(await _repo.UpdateAsync(new Provider(dto)));
        }
    }
}
