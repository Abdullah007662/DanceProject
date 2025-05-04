using Microsoft.AspNetCore.Mvc;

namespace DanceWebUI.ViewComponets.AdminLayout
{
    public class _AdminMessagePartials : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
