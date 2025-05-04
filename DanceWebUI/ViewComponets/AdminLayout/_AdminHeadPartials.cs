using Microsoft.AspNetCore.Mvc;

namespace DanceWebUI.ViewComponets.AdminLayout
{
    public class _AdminHeadPartials : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
