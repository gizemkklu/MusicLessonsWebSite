using DataAccessLayer.Concrete;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using MusicLessonProject.Models;
using System.Security.Claims;


namespace MusicLessonProject.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(AdminLoginViewModel p)
        {
            var c = new Context();
            var adminInfo = c.AdminLogins.FirstOrDefault(x=>x.Name == p.Name && x.Password == p.Password);

            if (adminInfo != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,adminInfo.Name)
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity),authProperties);
                return RedirectToAction("Index","AdminPages");
            }
            else
            {
                return RedirectToAction("SignIn", "Admin");
            }
            return View();
        }

    }
}
