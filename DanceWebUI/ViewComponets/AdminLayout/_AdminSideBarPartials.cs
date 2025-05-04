using Microsoft.AspNetCore.Mvc;

namespace DanceWebUI.ViewComponets.AdminLayout
{
    public class _AdminSideBarPartials : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
