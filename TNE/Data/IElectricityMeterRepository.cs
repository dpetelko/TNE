﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNE.Data.Exceptions;
using TNE.Dtos;
using TNE.Dtos.SearchFilters;
using TNE.Models;

namespace TNE.Data
{
    /// <summary>
    /// Performs operations on the ElectricityMeters 
    /// </summary>
    public interface IElectricityMeterRepository : IRepository<ElectricityMeter>
    {
        /// <summary>
        /// Set new status for ElectricityMeter by ID 
        /// Returns true if done
        /// </summary>
        /// <exception cref="EntityNotFoundException">If no ElectricityMeters are found</exception>
        Task<bool> SetStatus(Guid id, Status newStatus);
        
        /// <summary>
        /// Returns a specific ElectricityMeter by ID
        /// </summary>
        /// <exception cref="EntityNotFoundException">If no ElectricityMeters are found</exception>
        Task<ElectricityMeterDto> GetDtoByIdAsync(Guid id);
        
        /// <summary>
        /// Get all ElectricityMetersDto. 
        /// Returns list of ElectricityMeters or EMPTY List, if no ElectricityMeters are found
        /// </summary>
        Task<List<ElectricityMeterDto>> GetAllDtoAsync();
        
        /// <summary>
        /// Returns list of ElectricityMeters by Status or EMPTY List, if no ElectricityMeters are found
        /// </summary>
        Task<List<ElectricityMeterDto>> GetAllDtoByStatusAsync(Status status);
        
        /// <summary>
        /// Returns list of ElectricityMeters by ControlPoint ID or EMPTY List, if no ElectricityMeters are found
        /// </summary>
        Task<ElectricityMeterDto> GetDtoByControlPointId(Guid id);
        
        /// <summary>
        /// Returns list of ElectricityMeters by DeviceCalibrationControlDto or EMPTY List, if no ElectricityMeters are found
        /// </summary>
        Task<List<ElectricityMeterDto>> GetAllDtoByFilterAsync(DeviceCalibrationControlDto filter);
    }
}
