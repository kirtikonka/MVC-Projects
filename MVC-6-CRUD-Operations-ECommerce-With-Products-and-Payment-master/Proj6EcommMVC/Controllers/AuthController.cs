using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Proj6EcommMVC.Data;
using Proj6EcommMVC.Models;
using System.Text;

namespace Proj6EcommMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext db;
        public AuthController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public static string EncryptedPassword(string password)
        {
            if(string.IsNullOrEmpty(password))
            {
                return null;
            }
            else
            {
                byte[] pass= ASCIIEncoding.ASCII.GetBytes(password);
                string encrpass= Convert.ToBase64String(pass);
                return encrpass;
            }
        }

        public static string DecryptedPassword(string password)
        {
            if(string.IsNullOrEmpty(password))
            {
                return null;
            }
            else
            {
                byte[] pass=Convert.FromBase64String(password);
                string decrpass= Encoding.ASCII.GetString(pass);
                return decrpass;
            }
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(User u)
        {
            
            u.Password = EncryptedPassword(u.Password);
            u.Role = "User";
            db.Users.Add(u);
            db.SaveChanges();
            return RedirectToAction("SignIn");
        }

        [AcceptVerbs("Post","Get")]
        public IActionResult CheckExisitingEmailId(string email)
        {
            var data=db.Users.Where(x=>x.Email==email).SingleOrDefault();
            if(data!=null)
            {
                return Json($"Email {email} already exists, try another mail id");
            }
            else
            {
                return Json(true);
            }
        }

        //just to check if the user was added
        public IActionResult AllUser()
        {
            var data = db.Users.ToList();
            return View(data);
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost] 
        public IActionResult SignIn(Login log)
        {
            var data = db.Users.Where(x=>x.Email.Equals(log.Email)).SingleOrDefault();
            if (data != null) 
            {
                bool us=data.Email.Equals(log.Email) && DecryptedPassword(data.Password).Equals(log.Password);
                if (us)
                {
                    HttpContext.Session.SetString("myuser",data.Email); //set session Email
                    HttpContext.Session.SetString("urole", data.Role); //set session Role
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    TempData["ErrorPassword"] = "Invalid Password";
                }
            }
            else
            {
                TempData["ErrorEmail"] = "Invalid Email";
            }
            return View();

        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("SignIn");
        }

        public IActionResult UserDashboard()
        {
            return View();
        }
    }
} 