using Serilog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TNEClient.Data;
using TNEClient.Dtos;

namespace TNEClient.Services.Implementations
{
    public class VoltageTransformerServiceImpl : IVoltageTransformerService
    {
        private readonly IVoltageTransformerRepository _repo;

        public VoltageTransformerServiceImpl(IVoltageTransformerRepository repo) { _repo = repo; }

        public async Task<VoltageTransformerDto> CreateAsync(VoltageTransformerDto dto)
        {
            Log.Error("Welcome to CreateAsync");
            try
            {
                var qq = await _repo.CreateAsync(dto);
            }
            catch (Exception q)
            {

                Log.Error("Welcome to CreateAsync - {q}", q.InnerException);
            }
            

            return null;
        }

        public async Task<List<VoltageTransformerDto>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<List<VoltageTransformerDto>> GetAllByStatusAsync(Status status)
        {
            return await _repo.GetAllByStatusAsync(status);
        }

        public async Task<VoltageTransformerDto> GetAsync(Guid id)
        {
            return await _repo.GetAsync(id);
        }

        public async Task<VoltageTransformerDto> UpdateAsync(VoltageTransformerDto dto)
        {
            return await _repo.UpdateAsync(dto);
        }

        public async Task<bool> SetStatus(Guid id, Status status)
        {
            return await _repo.SetStatus(id, status);
        }

        public async Task<VoltageTransformerDto> GetDtoByControlPointId(Guid id)
        {
            return await _repo.GetByControlPointIdAsync(id);
        }
    }
}
