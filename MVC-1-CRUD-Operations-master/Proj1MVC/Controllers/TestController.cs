using Microsoft.AspNetCore.Mvc;
using Proj1MVC.Models;
using System.Dynamic;
using System.Xml.Linq;

namespace Proj1MVC.Controllers
{
    public class TestController : Controller
    {
        //public IActionResult Index(Emp e) //Binding Model and Controller-Model Binding
        //{
        //    return View();
        //}

        //public string show(string name) //url - /Test/show?name=Masstech
        //{
        //    return "Hello " + name;
        //}

        //public int Add(int a, int b) //url - /Test/Add?a=10&b=20
        //{
        //    return a + b;
        //}

        public IActionResult Index() 
        {
            //Method 1
            //var e = new Emp();
            //e.Id = 1;
            //e.Name = "test";    
            //e.Salary = 10000;

            //Method 2
            //var em = new Emp()
            //{
            //    Id = 1,
            //    Name = "test",
            //    Salary = 10000
            //};
            //return View(em);

            //Method 3
            var e = new List<Emp>()
            {
                new Emp{Id = 1,Name="John",Salary=1000},
                new Emp{Id = 2,Name="Raj",Salary=1001},
                new Emp{Id = 3,Name="Sara",Salary=1002},
                new Emp{Id = 4,Name="Kira",Salary=1003}
            };
            var m = new List<Manager>()
            {
                new Manager{MId = 1,ManagerName="John",ManagerSalary=100000},              
                new Manager{MId = 2,ManagerName="Raj",ManagerSalary=100001},
                new Manager{MId = 3,ManagerName="Sara",ManagerSalary=100002},
                new Manager{MId = 4,ManagerName="Kira",ManagerSalary=100003}

            };
            var viewmodel =new Combined
            {
                Employees=e,
                Manager = m
            };

            //method 1
            //ViewData["mydata"]=viewmodel;
            //return View();

            //method 2
            return View(viewmodel);
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
