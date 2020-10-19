using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TNEClient.Services
{
    public interface IDbUtilsService
    {
        Task<HttpResponse> DropAndRefillDb();
    }
}