using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace TNEClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Log.Error("Hello from HomeController!!!!");
            return View();
        }
    }
}
