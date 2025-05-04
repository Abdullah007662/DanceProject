using Microsoft.AspNetCore.Mvc;

namespace DanceWebUI.ViewComponets.DefaultLayout
{
    public class _DefaultScriptPartials : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
