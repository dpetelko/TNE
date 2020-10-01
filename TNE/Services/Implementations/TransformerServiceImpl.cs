using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNE.Data;
using TNE.Dtos;
using TNE.Models;

namespace TNE.Services.Implementations
{
    public class TransformerServiceImpl : ITransformerService
    {
        private readonly ITransformerRepository _repo;

        public TransformerServiceImpl(ITransformerRepository repo) { _repo = repo; }

        public void CheckExistsById(Guid id)
        {
            _repo.CheckExistsById(id);
        }

        public async Task<TransformerDto> CreateAsync(TransformerDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TransformerDto>> GetAllDtoAsync()
        {
            return await _repo.GetAllDtoAsync();
        }

        public async Task<List<TransformerDto>> GetAllDtoByStatusAsync(Status status)
        {
            return await _repo.GetAllDtoByStatusAsync(status);
        }

        public Transformer GetById(Guid id)
        {
            return _repo.GetById(id);
        }

        public async Task<Transformer> GetByIdAsync(Guid id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<TransformerDto> GetDtoByIdAsync(Guid id)
        {
            return await _repo.GetDtoByIdAsync(id);
        }

        public bool IsFieldUnique(Guid id, string fieldName, object fieldValue)
        {
            return (id.Equals(Guid.Empty))
                ? _repo.ExistsByField(fieldName, fieldValue)
                : _repo.ExistsByFieldAndNotId(id, fieldName, fieldValue);
        }

        public async Task<bool> SetStatus(Guid id, Status newStatus)
        {
            return await _repo.SetStatus(id, newStatus);
        }

        public async Task<TransformerDto> UpdateAsync(TransformerDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
