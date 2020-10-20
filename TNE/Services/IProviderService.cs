using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Data.Exceptions;
using TNE.Dto;
using TNE.Models;

namespace TNE.Services
{
    /// <summary>
    /// Performs operations on the Providers 
    /// </summary>
    public interface IProviderService : IService<Provider>
    {
        /// <summary>
        /// Returns a specific Provider by ID
        /// </summary>
        /// <exception cref="EntityNotFoundException">If no Providers are found</exception>
        Task<ProviderDto> GetDtoByIdAsync(Guid id);
        
        /// <summary>
        /// Get all ProvidersDto. 
        /// Returns list of Providers or EMPTY List, if no Providers are found
        /// </summary>
        Task<List<ProviderDto>> GetAllDtoAsync();
        
        /// <summary>
        /// Creates a Provider. 
        /// Returns a newly created Provider
        /// </summary>
        /// <exception cref="InvalidEntityException">If Provider are invalid, e.g. ID is not Guid.Empty</exception>
        Task<ProviderDto> CreateAsync(ProviderDto dto);
        
        /// <summary>
        /// Updates a Provider. Returns a updated Provider
        /// </summary>
        /// <exception cref="InvalidEntityException">If Provider are invalid, e.g. ID is Guid.Empty</exception>
        /// <exception cref="EntityNotFoundException">If Provider are not found with this ID</exception>
        Task<ProviderDto> UpdateAsync(ProviderDto dto);
        
        /// <summary>
        /// Get all Providers with attribute Deleted = false
        /// Returns list of Providers or EMPTY List, if no Providers are found
        /// </summary>
        Task<List<ProviderDto>> GetAllActiveDtoAsync();
        
        /// <summary>
        /// Deletes a specific Provider by ID
        /// </summary>
        /// <exception cref="EntityNotFoundException">If no Providers are found</exception>
        Task<bool> DeleteAsync(Guid id);
        
        /// <summary>
        /// Restores a specific Provider by ID
        /// </summary>
        /// <exception cref="EntityNotFoundException">If no Providers are found</exception>
        Task<bool> UndeleteAsync(Guid id);
        
        /// <summary>
        /// Returns list of Provider by SubDivision ID or EMPTY List, if no Providers are found
        /// </summary>
        Task<List<ProviderDto>> GetAllDtoBySubDivisionIdAsync(Guid id);
    }
}
