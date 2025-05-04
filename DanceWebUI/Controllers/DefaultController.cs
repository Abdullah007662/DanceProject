using Microsoft.AspNetCore.Mvc;

namespace DanceWebUI.Controllers
{
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
