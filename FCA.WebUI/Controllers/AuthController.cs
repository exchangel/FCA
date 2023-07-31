using FCA.Business.Dtos;
using FCA.Business.Dtos.UserDtos;
using FCA.Business.Services;
using FCA.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FCA.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        //DI

        //TODO new user
        
        public async Task<IActionResult> Login(LoginViewModel formData)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");

            }

            var loginDto = new LoginDto()
            {
                Email = formData.Email,
                Password = formData.Password
            };

            var userInfo = _userService.LoginUser(loginDto);

            if (userInfo is null)
            {
                TempData["ErrorMessage"] = "Eposta veya şifre hatalı.";

                return RedirectToAction("Index", "Home");
            }

            //Claims

            var claims = new List<Claim>();

            claims.Add(new Claim("id", userInfo.Id.ToString()));
            claims.Add(new Claim("email", userInfo.Email));
            claims.Add(new Claim("firstName", userInfo.FirstName));
            claims.Add(new Claim("lastName", userInfo.LastName));
            claims.Add(new Claim("userType", userInfo.UserType.ToString()));

            //Auth
            claims.Add(new Claim(ClaimTypes.Role, userInfo.UserType.ToString()));

            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);


            var autProperties = new AuthenticationProperties
            {
                AllowRefresh = true, // yenilenebilir oturum.
                ExpiresUtc = new DateTimeOffset(DateTime.Now.AddHours(72)) //72 saat oturum
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), autProperties);
            //eşzaman

            TempData["LoginMessage"] = "Giriş başarıyla yapıldı.";

            //TODO
            //return RedirectToAction("Index","Dashboard", new { area = "Admin" });
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> LogoutAdmin()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
