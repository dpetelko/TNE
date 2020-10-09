using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Threading.Tasks;
using TNEClient.Data;

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
