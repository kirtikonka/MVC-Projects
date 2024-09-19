using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Proj7MVC.Data;
using Proj7MVC.Models;
using System.Security.Claims;

namespace Proj7MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ECommerceContext db;
        private IWebHostEnvironment env;
        public AccountController(ECommerceContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }

        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(Auth u)
        {
            u.Pass = u.Pass;
            u.Urole = "User";
            db.Auths.Add(u);
            db.SaveChanges();
            return RedirectToAction("SignIn");
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(Auth log)
        {
            var data = db.Auths.Where(x => x.Username.Equals(log.Username)).SingleOrDefault();
            if (data != null)
            {
                bool us = data.Username.Equals(log.Username) && data.Pass.Equals(log.Pass);
                if (us)
                {
                    //step 3 passing cookies
                    var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, log.Username) }, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    HttpContext.Session.SetString("Username", log.Username);
                    
                    return RedirectToAction("Home", "Dashboard");
                }
                else
                {
                    TempData["Pass"] = "Invalid Password";
                }
            }
            else
            {
                TempData["us"] = "Username invalid";
            }
            return View();

        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var storedcookies = Request.Cookies.Keys;
            foreach (var cookie in storedcookies)
            {
                Response.Cookies.Delete(cookie);
            }
            return RedirectToAction("SignIn");
        }
    }
}
