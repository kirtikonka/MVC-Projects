using Proj3MVC.Data;
using Proj3MVC.Models;

namespace Proj3MVC.Repo
{
    public class EmpService : EmpRepo
    {
        private readonly ApplicationDbContext db;
        public EmpService(ApplicationDbContext db)
        { 
            this.db = db;
        }

        public List<Emp> GetAllEmps()
        {
            //throw new NotImplementedException();
            var data =db.Emps.ToList();
            return data;
        }

        public void NewEmp(Emp e)
        {
            db.Emps.Add(e);
            db.SaveChanges();
        }

        public void NewEmp(EmpRepo emp)
        {
          //throw new NotImplementedException();
        }

        public void RemoveEmp(Emp e)
        {
            
            //throw new NotImplementedException();
        }
        public void RemoveEmp(int id)
        {
            //var d=db.Emps.Where(x=>x.Id==id).SingleOrDefault();
            //or
            var data = db.Emps.Find(id);
            if (data != null)
            {
                db.Emps.Remove(data);
                db.SaveChanges();
            } 
        }
        public void EditTextEmp(int id)
        {
            var data = db.Emps.Find(id);
            if (data != null)
            {
                db.Emps.Update(data);
                db.SaveChanges();
            }
        }
        public void EditTextEmp(Emp e)
        {
            //throw new NotImplementedException();
        }
    }
}
