using Microsoft.AspNetCore.Mvc;

namespace TNEClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
