using Proj5MVC16Aug.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proj5MVC16Aug.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        ProductDAL pd = new ProductDAL();
        public ActionResult Index()
        {
            var data = pd.GetAllProducts();
            return View(data);
        }
        public ActionResult Details()
        {
            return View();
        }
    }
}