using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjMVC2.Data;
using ProjMVC2.Models;

namespace ProjMVC2.Controllers
{
    public class EmpController : Controller
    {
        public readonly ApplicationDbContext db;
        public EmpController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var obj = db.emps.ToList();
            return View(obj);
        }

        [HttpPost]
        public IActionResult Index(string ename)
        {
            if(ename.IsNullOrEmpty())
            {
                var data=db.emps.ToList();
                return View(data);
            }
            else
            {
                var data =db.emps.Where(x=>x.Name.Contains(ename) || x.Email.Contains(ename)).ToList();
            }
        }
        public IActionResult Details()
            { return View(); }

        [HttpPost]
        public IActionResult Details(Emp e)
        {
            db.emps.ToList();
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult AddEmp(Emp e)
        {
            db.emps.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult DeleteEmp(int id)
        {
            //var data=db.emps.Where(a=>a.Id.Equals(id)).SingleorDefault();
            var data = db.emps.Find(id);
            db.SaveChanges();
            //TempData["Delmsg"] = "Emp Deleted Successfully";
            return RedirectToAction("Index");
        }


        public IActionResult EditEmp(int id)
        {
            var data = db.emps.Find(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult EditEmp(Emp e)
        {
            db.emps.Update(e);
            db.SaveChanges();
            //TempData["Updmsg"] = "Emp Updated Successfully!";
            return RedirectToAction("Index");
        }


    }
}
