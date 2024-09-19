
using Microsoft.AspNetCore.Mvc;
using Proj1MVC.Models;

namespace Proj1MVC.Controllers
{
    public class CRUDController : Controller
    {
        static List<Person> people = new List<Person>()
        {
               new Person { First = "DAD", Last = "Nguyen", Name = "Study", About = "Study for test", Done = false, Id = 1 },
               new Person { First = "David", Last = "Smith", Name = "Grocery", About = "Buy apple and bananana", Done = true , Id = 2},
               new Person { First = "Tom", Last = "Davidson", Name = "Fix car", About = "Headlight and mirror is broken", Done = false, Id = 3 },
               new Person { First = "Maddie", Last = "Madison", Name = "Job application", About = "Follow up on job interview ", Done = false , Id = 4}
        };

        public IActionResult Index()
        {
            return View(people);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person per)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", per);
                }
                people.Add(per);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            Person per = people.Find(emp => emp.Id == id);
            return View(per);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Person per = people.Find(emp => emp.Id == id);
            return View(per);
        }

        public ActionResult Delete()
        {
            return View();
        }
    }
}
