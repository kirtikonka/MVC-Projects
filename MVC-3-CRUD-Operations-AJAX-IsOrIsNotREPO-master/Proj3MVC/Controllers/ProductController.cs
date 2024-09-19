using Microsoft.AspNetCore.Mvc;
using Proj3MVC.Data;
using Proj3MVC.Models;
using System.Net;

namespace Proj3MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext db;
        private IWebHostEnvironment env;
        public ProductController(ApplicationDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }
        public IActionResult Index()
        {
            var data = db.Products.ToList();
            return View(data);
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
                Pname=pm.Pname,
                Pcat=pm.Pcat,
                Price=pm.Price,
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


    }
}
