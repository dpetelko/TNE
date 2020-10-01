using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Dtos;
using TNE.Models;

namespace TNE.Data
{
    public interface ITransformerRepository : IRepository<Transformer>
    {
        Task<bool> SetStatus(Guid id, Status newStatus);
        Task<TransformerDto> GetDtoByIdAsync(Guid Id);
        Task<List<TransformerDto>> GetAllDtoAsync();

    }
}
