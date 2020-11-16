using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TNEClient.Services;

namespace TNEClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDbUtilsService _service;

        public HomeController(IDbUtilsService service) => _service = service;

        [Route("/")]
        public IActionResult Index() => View();

        public async Task<IActionResult> DropAndRefillDb()
        {
            await _service.DropAndRefillDb();
            return RedirectToAction(nameof(Index));
        }
    }
}
