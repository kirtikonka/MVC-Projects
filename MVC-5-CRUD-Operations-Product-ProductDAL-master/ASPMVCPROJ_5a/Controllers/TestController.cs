using ASPMVCPROJ_5a.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPMVCPROJ_5a.Controllers
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
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product p)
        {
            pd.AddProduct(p); //ProductDAL
            TempData["success"] = "<script>alert('Product Added Successfully!');</script>";
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int id)
        {
            pd.DeleteProduct(id); //ProductDAL
            TempData["success"] = "<script>alert('Product Deleted Successfully!');</script>";
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var data = pd.GetAllProducts().Find(x => x.Id == id); //or (x=>x.Id.Equals(id)) LAMBDA EXPRESSION
            return View(data);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product p)
        {
            pd.UpdateProduct(p);
            TempData["success"] = "<script>alert('Product Updated Successfully!');</script>";
            return RedirectToAction("Index");
        }
    }
}