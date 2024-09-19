using Microsoft.AspNetCore.Mvc;
using Proj4MVC.Interfaces;

namespace Proj4MVC.Controllers
{
    public class DepartmentsController : Controller
    {
        private IUnitOfWork unitOfWork;

        public DepartmentsController(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;

        public IActionResult Index()
        {
            var listofDepartments = unitOfWork.DepartmentRepository.GetAllDepartments();
            return View(listofDepartments);
        }
    }
}
