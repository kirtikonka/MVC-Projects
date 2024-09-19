using Proj4MVC.Models;

namespace Proj4MVC.ViewModels.Departments
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DepartmentViewModel() 
        {
        }
        public DepartmentViewModel(Department model)
        {
            Id = model.Id;
            Name = model.Name;
        }
        public Department ConvertInViewModel(DepartmentViewModel model)
        {
            return new Department
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}
