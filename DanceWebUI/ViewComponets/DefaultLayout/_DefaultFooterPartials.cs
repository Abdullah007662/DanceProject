using Microsoft.AspNetCore.Mvc;

namespace DanceWebUI.ViewComponets.DefaultLayout
{
    public class _DefaultFooterPartials : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
