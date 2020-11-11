using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Data.Exceptions;
using TNE.Dtos;
using TNE.Models;

namespace TNE.Data
{
    /// <summary>
    /// Performs operations on the DeliveryPoints 
    /// </summary>
    public interface IDeliveryPointRepository : IRepository<DeliveryPoint>
    {

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
        /// Get all DeliveryPoints with attribute Deleted = false
        /// Returns list of DeliveryPoints or EMPTY List, if no DeliveryPoints are found
        /// </summary>
        Task<List<DeliveryPointDto>> GetAllActiveDtoAsync();

        /// <summary>
        /// Returns list of DeliveryPoints by Provider ID or EMPTY List, if no DeliveryPoints are found
        /// </summary>
        Task<List<DeliveryPointDto>> GetAllDtoByProviderIdAsync(Guid id);
    }
}
