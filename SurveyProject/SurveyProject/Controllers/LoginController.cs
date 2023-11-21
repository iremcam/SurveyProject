
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using SurveyProject.Business;
using SurveyProject.Models;
using SurveyProject.Services;
using System.Configuration;
using System.Security.Claims;

namespace SurveyProject.Controllers
{
    public class LoginController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly UserBl _userBl;
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
            _userBl = new UserBl();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(bool hatali = false)
        {
            if (hatali)
            {
                ViewBag.GirisHata = "Kullanıcı Adı veya Şifre";


            }
            return View();
        }

        public async Task<IActionResult> Giris(User user)
        {
            user = _userBl.UserControl(user);

            if (user != null)
            {
                var service = new Service(_configuration);
                var token=service.GenerateToken(user);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim("KullaniciId", user.Id.ToString()),
                    new Claim("AuthMenu", user.UserType.Name)
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("UserIndex", "Home");

            }
            else
            {
                return RedirectToAction("Login", new { hatali = true });
            }
                    
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login", null);
        }
    }
}
