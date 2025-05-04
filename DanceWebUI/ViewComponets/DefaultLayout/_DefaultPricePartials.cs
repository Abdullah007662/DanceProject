using DanceDTOLayer.WebUIDTO.PriceDTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DanceWebUI.ViewComponets.DefaultLayout
{
    public class _DefaultPricePartials : ViewComponent
    {
        private readonly HttpClient _httpClient;
        public _DefaultPricePartials(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyApiClient");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await _httpClient.GetAsync("api/Prices");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPriceDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
