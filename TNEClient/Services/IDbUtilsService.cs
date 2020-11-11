using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TNEClient.Services
{
    public interface IDbUtilsService
    {
        Task<HttpResponse> DropAndRefillDb();
    }
}