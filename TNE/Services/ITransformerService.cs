using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNE.Dtos;
using TNE.Models;

namespace TNE.Services
{
    interface ITransformerService : IService<Transformer>
    {
        Task<bool> SetStatus(Guid id, Status newStatus);
        Task<TransformerDto> GetDtoByIdAsync(Guid id);
        Task<List<TransformerDto>> GetAllDtoAsync();
        Task<TransformerDto> CreateAsync(TransformerDto dto);
        Task<TransformerDto> UpdateAsync(TransformerDto dto);
        Task<List<TransformerDto>> GetAllDtoByStatusAsync(Status status);
    }
}
