using Microsoft.AspNetCore.Mvc;

namespace DanceWebUI.ViewComponets.DefaultLayout
{
    public class _DefaultNavBarPartials : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
