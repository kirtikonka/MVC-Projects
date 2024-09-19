using Proj4MVC.Data;
using Proj4MVC.Interfaces;

namespace Proj4MVC.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IDepartmentRepository DepartmentRepository => new DepartmentRepository(_context);
    }
}
