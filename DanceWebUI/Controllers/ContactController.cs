using DanceDTOLayer.WebUIDTO.ContactDTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
namespace DanceWebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ContactController> _logger;

        public ContactController(IHttpClientFactory httpClientFactory, ILogger<ContactController> logger)
        {
            _httpClient = httpClientFactory.CreateClient("MyApiClient");
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] CreateContactDTO dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Log the DTO values for debugging
                    _logger.LogInformation($"Processing contact: {dto.NameSurname}, {dto.Email}, {dto.PhoneNumber},{dto.Message}");

                    var jsonData = JsonConvert.SerializeObject(dto);
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    // Add logging for the API request
                    _logger.LogInformation($"Sending API request to: api/Contacts");

                    var response = await _httpClient.PostAsync("api/Contacts", content);

                    // Log the response status
                    _logger.LogInformation($"API response status: {response.StatusCode}");

                    if (response.IsSuccessStatusCode)
                    {
                        // Log success
                        _logger.LogInformation("Contact created successfully");
                        return Json(new { success = true, message = "Mesajınız başarıyla gönderildi." });
                    }
                    else
                    {
                        // Log failure with response content
                        var errorContent = await response.Content.ReadAsStringAsync();
                        _logger.LogError($"API error: {errorContent}");
                        return Json(new { success = false, message = "İletişim bilgileri kaydedilemedi." });
                    }
                }

                // Log validation errors
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        _logger.LogError($"Model validation error: {error.ErrorMessage}");
                    }
                }

                return Json(new { success = false, message = "Lütfen tüm alanları doğru şekilde doldurun." });
            }
            catch (Exception ex)
            {
                // Log any exceptions
                _logger.LogError($"Exception in CreateContact: {ex.Message}");
                _logger.LogError($"Stack trace: {ex.StackTrace}");

                return Json(new { success = false, message = "İşlem sırasında bir hata oluştu." });
            }
        }
    }
}