using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proj7MVC.Data;

namespace Proj7MVC.Controllers
{
    [Authorize]
    //clear previous cache
    [ResponseCache(Location =ResponseCacheLocation.None, NoStore = true)]
    public class DashboardController : Controller
    {
        private readonly ECommerceContext db;
        private IWebHostEnvironment env;
        public DashboardController(ECommerceContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }

        public IActionResult Home()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Contact()
        {
            return View();
        }

    }
}
