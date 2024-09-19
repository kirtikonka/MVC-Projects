using Proj4MVC.Models;
using Proj4MVC.ViewModels.Departments;

namespace Proj4MVC.Interfaces
{
    public interface IDepartmentRepository
    {
        List<DepartmentViewModel> ConvertList(List<Department> departments);
        Task<IEnumerable<DepartmentViewModel>> GetAllDepartments();
    }
}
