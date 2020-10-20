﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNE.Dtos;
using TNE.Dtos.SearchFilters;
using TNE.Models;

namespace TNE.Data
{
    public interface IBillingPointRepository : IRepository<BillingPoint>
    {
        
        Task<BillingPointDto> GetDtoByIdAsync(Guid id);
        /// <summary>
        /// Get all BillingPointsDto. 
        /// Returns list of BillingPoints or EMPTY List, if no BillingPoints are found
        /// </summary>
        Task<List<BillingPointDto>> GetAllDtoAsync();
        Task<List<BillingPointDto>> GetAllDtoByControlPointIdAsync(Guid id);
        Task<List<BillingPointDto>> GetAllDtoByDeliveryPointIdAsync(Guid id);
        Task<List<BillingPointDto>> GetAllDtoByFilterAsync(BillingPointFilter filter);
    }
}
