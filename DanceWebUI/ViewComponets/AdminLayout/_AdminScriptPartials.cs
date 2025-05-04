using Microsoft.AspNetCore.Mvc;

namespace DanceWebUI.ViewComponets.AdminLayout
{
    public class _AdminScriptPartials : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
