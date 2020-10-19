using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TNEClient.Dtos;
using TNEClient.Dtos.SearchFilters;

namespace TNEClient.Data
{
    [Headers("Accept: application/json")]
    public interface IDbUtilsRepository
    {
        [Get("/api/v1/Utils")]
        Task<HttpResponse> DropAndRefillDb();
    }
}
