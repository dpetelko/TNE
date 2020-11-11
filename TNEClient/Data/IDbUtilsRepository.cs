using Microsoft.AspNetCore.Http;
using Refit;
using System.Threading.Tasks;

namespace TNEClient.Data
{
    [Headers("Accept: application/json")]
    public interface IDbUtilsRepository
    {
        /// <summary>
        /// Drop and fills the database with test data
        /// </summary>
        /// <exception cref="ApiException">If Response HttpStatus not equal 200</exception>
        [Get("/api/v1/Utils")]
        Task<HttpResponse> DropAndRefillDb();
    }
}
