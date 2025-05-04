using DanceDTOLayer.WebUIDTO.AboutDTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DanceWebUI.ViewComponets.DefaultLayout
{
    public class _DefaultAboutPartials : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public _DefaultAboutPartials(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyApiClient");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await _httpClient.GetAsync("api/Abouts");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}
