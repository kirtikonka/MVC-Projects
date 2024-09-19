using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proj7MVC.Data;
using Proj7MVC.Models;

namespace Proj7MVC.Controllers
{
    public class TestTwoController : Controller
    {
        private readonly ECommerceContext db;
        public TestTwoController(ECommerceContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var d = db.TestTwos.FromSqlRaw($"exec FindTestTwos");
            return View();
        }
        public IActionResult AddTest()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTest(TestTwo t)
        {
            db.Database.ExecuteSqlRaw($"exec InsertTestTwoProc '{t.Name}','{t.Department}',{t.Salary}");
            TempData["msg"] = "Emp Added Successfully";
            return RedirectToAction("Index");
        }
        public IActionResult Delete()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            var d=db.TestTwos.FromSqlRaw($"exec FindById {id}").ToList().SingleOrDefault();
            return View(d);
        }
        [HttpPost]
        public IActionResult Edit(int id)
        {
            db.Database.ExecuteSqlRaw($"exec EditTestTwos {id.Id},'{id.Name}','{id.Department}',{id.Salary}");
            TempData["msg"] = "Emp Edited Successfully";
            return RedirectToAction("Index");
        }
    }
}
