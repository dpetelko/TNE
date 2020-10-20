using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNE.Dtos;
using TNE.Models;

namespace TNE.Services
{
    /// <summary>
    /// Performs operations on the DeliveryPoints 
    /// </summary>
    public interface IDeliveryPointService : IService<DeliveryPoint>
    {
        /// <summary>
        /// Returns a specific DeliveryPoint by ID
        /// </summary>
        /// <exception cref="EntityNotFoundException">If no DeliveryPoint are found</exception>
        Task<DeliveryPointDto> GetDtoByIdAsync(Guid id);
        
        /// <summary>
        /// Get all DeliveryPointsDto. 
        /// Returns list of DeliveryPoints or EMPTY List, if no DeliveryPoints are found
        /// </summary>
        Task<List<DeliveryPointDto>> GetAllDtoAsync();
        
        /// <summary>
        /// Creates a DeliveryPoint. 
        /// Returns a newly created DeliveryPoint
        /// </summary>
        /// <exception cref="InvalidEntityException">If DeliveryPoint are invalid, e.g. ID is not Guid.Empty</exception>
        Task<DeliveryPointDto> CreateAsync(DeliveryPointDto dto);
        
        /// <summary>
        /// Updates a DeliveryPoint. Returns a updated DeliveryPoint
        /// </summary>
        /// <exception cref="InvalidEntityException">If DeliveryPoint are invalid, e.g. ID is Guid.Empty</exception>
        /// <exception cref="EntityNotFoundException">If DeliveryPoint are not found with this ID</exception>
        Task<DeliveryPointDto> UpdateAsync(DeliveryPointDto dto);
        
        /// <summary>
        /// Get all DeliveryPoints with attribute Deleted = false
        /// Returns list of DeliveryPoints or EMPTY List, if no DeliveryPoints are found
        /// </summary>
        Task<List<DeliveryPointDto>> GetAllActiveDtoAsync();
        
        /// <summary>
        /// Deletes a specific DeliveryPoint by ID
        /// </summary>
        /// <exception cref="EntityNotFoundException">If no DeliveryPoints are found</exception>
        Task<bool> DeleteAsync(Guid id);
        
        /// <summary>
        /// Restores a specific DeliveryPoint by ID
        /// </summary>
        /// <exception cref="EntityNotFoundException">If no DeliveryPoints are found</exception>
        Task<bool> UndeleteAsync(Guid id);
        
        /// <summary>
        /// Returns list of DeliveryPoints by Provider ID or EMPTY List, if no DeliveryPoints are found
        /// </summary>
        Task<List<DeliveryPointDto>> GetAllDtoByProviderIdAsync(Guid id);
    }
}
