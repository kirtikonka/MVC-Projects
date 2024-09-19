using Microsoft.EntityFrameworkCore;
using Proj4MVC.Data;
using Proj4MVC.Interfaces;
using Proj4MVC.Models;
using Proj4MVC.ViewModels.Departments;

namespace Proj4MVC.Implementations
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<DepartmentViewModel> ConvertList(List<Department> departments)
        {
            return departments.Select(x=>new  DepartmentViewModel(x)).ToList();
        }
        public async Task<IEnumerable<DepartmentViewModel>> GetAllDepartments()
        {
            var model = await _context.Departments.ToListAsync();
            var vm = ConvertList(model);
            return vm;
        }
    }
}
