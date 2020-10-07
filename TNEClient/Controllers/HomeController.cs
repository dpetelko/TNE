using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Threading.Tasks;
using TNEClient.Data;

namespace TNEClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILeadDivisionRepository _repo;

        public HomeController(ILeadDivisionRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            Log.Error("Hello from HomeController!!!!");
            return View(await _repo.GetAllAsync());
        }
    }
}
