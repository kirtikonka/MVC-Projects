using Microsoft.AspNetCore.Mvc;
using Proj1MVC.Models;

namespace Proj1MVC.Controllers
{
    public class EmpController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Emp e)
        {
            return View(e);
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login log)
        {
            if (ModelState.IsValid)
            {
                if(log.UserName.Equals("Admin") && log.Password.Equals("Admin"))
                {
                    TempData["msg"] = "Login Successful!";
                    //ViewBag and ViewData only works when there is no redirection
                    //ViewData["successMsg"] = "Login Successful";
                    //ViewBag.msg = "Login Successful";

                    //return RedirectToAction("ActionName", "ControllerName"); //redirect one controller to another container
                    //return RedirectToAction("Index"); //within same controller
                    return RedirectToAction("About", "Test");
                }
                else
                {
                    TempData["msg"] = "Invalid Login Credentails.";
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return View();
            }
        }
    }
}
