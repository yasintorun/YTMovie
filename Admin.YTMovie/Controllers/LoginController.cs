using Business.Abstract;
using Business.DependencyResolvers.Ninject;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Admin.YTMovie.Controllers
{
    public class LoginController : Controller
    {
        private ILoginService _loginService = InstanceFactory.GetInstance<ILoginService>();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Entities.Concrete.Admin admin)
        {
            var loginResult = _loginService.AdminLogin(admin);
            if(loginResult.Success)
            {
                HttpContext.Session.SetInt32("YTMovie", loginResult.Data.Id);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginResult.Data.Email),
                };
                var id = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal pr = new ClaimsPrincipal(id);
                await HttpContext.SignInAsync(pr);
                return RedirectToAction("Index", "Film");
            }
            ViewBag.LoginError = loginResult.Message;
            return View();
        }

    }
}
