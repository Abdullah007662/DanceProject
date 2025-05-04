using Microsoft.AspNetCore.Mvc;

namespace DanceWebUI.ViewComponets.DefaultLayout
{
    public class _DefaultHeadPartials : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
