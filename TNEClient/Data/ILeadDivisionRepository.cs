using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNEClient.Dtos;

namespace TNEClient.Data
{
    //[Headers("Accept: application/json")]
    public interface ILeadDivisionRepository
    {
        [Get("/api/v1/LeadDivisions")]
        Task<List<LeadDivisionDto>> GetAllAsync();

        [Get("/api/v1/LeadDivisions/active")]
        Task<List<LeadDivisionDto>> GetAllActiveAsync();

        [Get("/api/v1/LeadDivisions/{id}")]
        Task<LeadDivisionDto> GetAsync(Guid id);

        [Post("/api/v1/LeadDivisions")]
        Task<LeadDivisionDto> CreateAsync([Body] LeadDivisionDto dto);

        [Put("/api/v1/LeadDivisions")]
        Task<LeadDivisionDto> UpdateAsync([Body] LeadDivisionDto dto);

        [Delete("/api/v1/LeadDivisions/{id}")]
        Task<bool> DeleteAsync(Guid id);

        [Delete("/api/v1/LeadDivisions/undelete/{id}")]
        Task<bool> UndeleteAsync(Guid id);
    }
}
