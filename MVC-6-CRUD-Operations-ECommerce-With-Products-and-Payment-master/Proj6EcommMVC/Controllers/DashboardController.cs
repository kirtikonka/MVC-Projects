using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Proj6EcommMVC.Data;
using Proj6EcommMVC.Models;

namespace Proj6EcommMVC.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext db;
        private IWebHostEnvironment env;
        public DashboardController(ApplicationDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }

        public IActionResult Index(string choice)
        {
            string s= HttpContext.Session.GetString("myuser");  //get session 

            if (choice == "All")
            {
                var data = db.Products.ToList();
                return View(data);
            }
            else if (choice == "LTH")
            {
                var data = db.Products.OrderBy(x => x.Price).ToList();
                return View(data);
            }
            else
            {
                var data = db.Products.Take(5).ToList();
                return View(data);
            }
        }
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(ProductViewModel pm)
        {
            var path = env.WebRootPath;
            var filePath = "Content/Images/" + pm.Picture.FileName;
            var fullpath = Path.Combine(path, filePath);
            UploadFile(pm.Picture, fullpath);
            var obj = new Product()
            {
                Pname = pm.Pname,
                Pcat = pm.Pcat,
                Price = pm.Price,
                Picture = filePath
            };
            db.Add(obj);
            db.SaveChanges();
            TempData["msg"] = "Product Added Successfully!";
            return RedirectToAction("Index");
        }
        public void UploadFile(IFormFile file, string path)
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);
        }

        public IActionResult EditProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditProduct(ProductViewModel pm)
        {
            TempData["msg"] = "Product Edited Successfully!";
            return RedirectToAction("Index");
        }

        public IActionResult LTH()
        {
            var data = db.Products.OrderBy(x => x.Price).ToList();
            return View(data);
        }
        public IActionResult AddToCart(int id)
        {
            string sess = HttpContext.Session.GetString("myuser");
            var prod = db.Products.Find(id);
            var obj = new Cart()
            {
                Pname = prod.Pname,
                Price = prod.Price,
                Picture = prod.Picture,
                Pcat = prod.Pcat,
                Suser = sess
            };
            db.Cart.Add(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Cart(int id)
        {
            if(HttpContext.Session.GetString("myuser").IsNullOrEmpty())
            {
                return RedirectToAction("SignIn","Auth");
            }
            else
            {
                string sess = HttpContext.Session.GetString("myuser");
                var prod = db.Cart.Where(x=>x.Suser==sess).ToList();
                return View(prod);
            }
        }
        public IActionResult Payment(int id)
        {
            if (HttpContext.Session.GetString("myuser").IsNullOrEmpty())
            {
                return RedirectToAction("SignIn", "Auth");
            }
            else
            {
                return View();
            }
        }
        public IActionResult PayNow(int id)
        {
            string sess = HttpContext.Session.GetString("myuser");
            var prod = db.Products.Find(id);
            var obj = new Payment()
            {
                Pname = prod.Pname,
                Price = prod.Price,
                Picture = prod.Picture,
                Pcat = prod.Pcat,
                Suser = sess
            };
            db.Payments.Add(obj);
            db.SaveChanges();
            return RedirectToAction("Invoice");

        }
    }
}
