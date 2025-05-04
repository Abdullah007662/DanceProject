using Microsoft.AspNetCore.Mvc;

namespace DanceWebUI.Controllers
{
    public class DenemeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
