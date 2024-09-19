using Proj3MVC.Models;

namespace Proj3MVC.Repo
{
    public interface EmpRepo
    {
        void NewEmp(EmpRepo emp);
        void NewEmp(Emp emp);

        List<Emp> GetAllEmps();
        void RemoveEmp(Emp e);
        void RemoveEmp(int id);

        void EditTextEmp(Emp e);
        void EditTextEmp(int id);
    }
}
