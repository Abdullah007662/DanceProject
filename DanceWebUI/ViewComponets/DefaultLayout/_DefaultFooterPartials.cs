using DanceDTOLayer.WebUIDTO.LocationDTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DanceWebUI.ViewComponets.DefaultLayout
{
    public class _DefaultFooterPartials : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public _DefaultFooterPartials(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyApiClient");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await _httpClient.GetAsync("api/Locations");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
