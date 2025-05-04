using Microsoft.AspNetCore.Mvc;

namespace DanceWebUI.ViewComponets.AdminLayout
{
    public class _AdminHeaderPartials : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
