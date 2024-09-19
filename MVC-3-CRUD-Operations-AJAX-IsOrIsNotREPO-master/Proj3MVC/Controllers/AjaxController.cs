using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Proj3MVC.Data;
using Proj3MVC.Models;

namespace Proj3MVC.Controllers
{
    public class AjaxController : Controller
    {
        private readonly ApplicationDbContext db;
        public AjaxController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmp(Emp e)
        {
            db.Emps.Add(e);
            db.SaveChanges();
            return Json("");
        }

        public IActionResult GetEmp()
        {
            var data = db.Emps.ToList();
            return Json(data);
        }

        public IActionResult DeleteEmp(int eid)
        {
            var data = db.Emps.Find(eid);
            db.Emps.Remove(data);
            db.SaveChanges();
            return Json("");
        }
        public IActionResult EditEmp(int eid)
        {
            var data = db.Emps.Find(eid);
            return Json(data);
        }

        public IActionResult UpdateEmp(Emp e)
        {
            db.Emps.Update(e);
            db.SaveChanges();
            return Json("");
        }

        public IActionResult SearchEmp(string sdata)
        {
            if (sdata.IsNullOrEmpty())
            {
                var data = db.Emps.ToList();
                return Json(data);
            }
            else
            {
                var data = db.Emps.Where(x => x.Name.Contains(sdata)).ToList();
                return Json(data);
            }
        }
    }
}
