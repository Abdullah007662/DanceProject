using Microsoft.AspNetCore.Mvc;

namespace DanceWebUI.ViewComponets.DefaultLayout
{
    public class _DefaultBannerPartials : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
