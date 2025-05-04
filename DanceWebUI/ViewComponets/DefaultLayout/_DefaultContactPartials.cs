using DanceDTOLayer.WebUIDTO.ContactDTO;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace DanceWebUI.ViewComponets.DefaultLayout
{
    public class _DefaultContactPartials : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public _DefaultContactPartials(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyApiClient");
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }

}
