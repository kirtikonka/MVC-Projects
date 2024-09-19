namespace Proj4MVC.Interfaces
{
    public interface IUnitOfWork
    {
        IDepartmentRepository DepartmentRepository { get; }
    }
}
