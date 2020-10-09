using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNEClient.Dtos;

namespace TNEClient.Data
{
    public interface ISubDivisionRepository
    {
        [Get("/api/v1/SubDivisions")]
        Task<List<SubDivisionDto>> GetAllAsync();

        [Get("/api/v1/SubDivisions/active")]
        Task<List<SubDivisionDto>> GetAllActiveAsync();

        [Get("/api/v1/SubDivisions/{id}")]
        Task<SubDivisionDto> GetAsync(Guid id);

        [Get("/api/v1/SubDivisions/byLeadDivision/{id}")]
        Task<List<SubDivisionDto>> GetByLeadDivisionAsync(Guid id);

        [Post("/api/v1/SubDivisions")]
        Task<SubDivisionDto> CreateAsync([Body] SubDivisionDto dto);

        [Put("/api/v1/SubDivisions")]
        Task<SubDivisionDto> UpdateAsync([Body] SubDivisionDto dto);

        [Delete("/api/v1/SubDivisions/{id}")]
        Task<bool> DeleteAsync(Guid id);

        [Delete("/api/v1/SubDivisions/undelete/{id}")]
        Task<bool> UndeleteAsync(Guid id);
    }
}
