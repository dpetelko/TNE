using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TNEClient.Data;

namespace TNEClient.Services.Implementations
{
    public class DbUtilsServiceImpl : IDbUtilsService
    {
        private readonly IDbUtilsRepository _repo;

        public DbUtilsServiceImpl(IDbUtilsRepository repo) => _repo = repo;

        public async Task<HttpResponse> DropAndRefillDb()
        {
            return await _repo.DropAndRefillDb();
        }
    }
}