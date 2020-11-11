using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Data.Exceptions;
using TNE.Dto;
using TNE.Models;

namespace TNE.Data
{
    /// <summary>
    /// Performs operations on the Providers 
    /// </summary>
    public interface IProviderRepository : IRepository<Provider>
    {
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
        /// Get all Providers with attribute Deleted = false
        /// Returns list of Providers or EMPTY List, if no Providers are found
        /// </summary>
        Task<List<ProviderDto>> GetAllActiveDtoAsync();

        /// <summary>
        /// Returns list of Provider by SubDivision ID or EMPTY List, if no Providers are found
        /// </summary>
        Task<List<ProviderDto>> GetAllDtoBySubDivisionIdAsync(Guid id);
    }
}
