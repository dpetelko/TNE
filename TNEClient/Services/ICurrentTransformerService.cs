using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TNEClient.Dtos;

namespace TNEClient.Services
{
    public interface ICurrentTransformerService
    {
        Task<List<CurrentTransformerDto>> GetAllAsync();
        Task<List<CurrentTransformerDto>> GetAllByStatusAsync(Status status);
        Task<CurrentTransformerDto> GetAsync(Guid id);
        Task<CurrentTransformerDto> CreateAsync(CurrentTransformerDto dto);
        Task<CurrentTransformerDto> UpdateAsync(CurrentTransformerDto dto);
        Task<bool> SetStatus(Guid id, Status status);
    }
}
