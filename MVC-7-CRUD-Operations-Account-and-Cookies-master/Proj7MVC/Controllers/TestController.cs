using Microsoft.AspNetCore.Mvc;
using Proj7MVC.Data;
using Proj7MVC.Models;

namespace Proj7MVC.Controllers
{
    public class TestController : Controller
    {
        private readonly ECommerceContext db;
        private IWebHostEnvironment env;
        public TestController(ECommerceContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(User log)
        {
            var data = db.Users.Where(x => x.Username.Equals(log.Username)).SingleOrDefault();
            if (data != null)
            {
                bool us = data.Username.Equals(log.Username) && data.Pass.Equals(log.Pass);
                if (us)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();

        }
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(User u)
        {
            u.Pass = u.Pass;
            //u.Urole = "User";
            db.Users.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
