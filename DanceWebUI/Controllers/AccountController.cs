using DanceDTOLayer.WebApiDTO.İdentity;
using DanceWebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DanceWebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var client = _httpClientFactory.CreateClient("MyApiClient");

            var response = await client.PostAsJsonAsync("api/auth/login", model);
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Kullanıcı adı veya şifre yanlış";
                return View();
            }

            var json = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(json);
            if (tokenResponse == null || string.IsNullOrEmpty(tokenResponse.Token))
            {
                ViewBag.Message = "Token alınamadı";
                return View();
            }

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(tokenResponse.Token);

            var claims = jwtToken.Claims;
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var client = _httpClientFactory.CreateClient("MyApiClient");

            var dto = new RegisterDto
            {
                Username = model.Username,
                Email = model.Email,
                Password = model.Password,
                FullName = model.FullName
            };

            var response = await client.PostAsJsonAsync("api/Auth/register", dto);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Login");
            }

            var errorContent = await response.Content.ReadAsStringAsync();
            ViewBag.Message = $"Kayıt başarısız. Hata: {errorContent}";
            return View(model);
        }
    }
}
