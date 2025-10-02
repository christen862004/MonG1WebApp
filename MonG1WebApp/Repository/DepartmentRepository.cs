using Microsoft.EntityFrameworkCore;
using MonG1WebApp.Models;

namespace MonG1WebApp.Repository
{
    //Ahmed
    public class DepartmentRepository :IDepartmentRepository
    {
        //Sl Server
        ITIContext context;
        public DepartmentRepository( ITIContext ctx)
        {
            context =ctx;// new ITIContext();
        }
        //CRUD
        public void Add(Department obj)
        {
            context.Departments.Add(obj);
        }

        public void Delete(int id)
        {
            Department obj=GetByID(id);
            context.Departments.Remove(obj);
        }

        public List<Department> GetAll()
        {
            //return context.Departments.AsNoTracking().ToList();
            return context.Departments.ToList();
        }

        public Department GetByID(int id)
        {
            return context.Departments.FirstOrDefault(d => d.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Department obj)
        {
            Department depFromDb=GetByID(obj.Id);
            depFromDb.Name= obj.Name;
            depFromDb.ManagerName= obj.ManagerName;
        }
    }
}
