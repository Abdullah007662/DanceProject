using Microsoft.AspNetCore.Mvc;

namespace DanceWebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
