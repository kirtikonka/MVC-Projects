using Microsoft.AspNetCore.Mvc;
using Proj3MVC.Models;
using Proj3MVC.Repo;

namespace Proj3MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmpRepo repo;

        public EmployeeController (EmpRepo repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var dt= repo.GetAllEmps();
            return View(dt);
        }

        public IActionResult AddEmp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmp(Emp e)
        {
            if(ModelState.IsValid)
            {
                repo.NewEmp(e);
                TempData["msg"] = "Emp Added Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult EditEmp(int id)
        {
            repo.EditTextEmp(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditEmp(Emp e)
        {
            return RedirectToAction("Index");
        }

        public IActionResult DeleteEmp(int id)
        {
            repo.RemoveEmp(id);
            return RedirectToAction("Index");
        }
    }
}
