using Microsoft.EntityFrameworkCore;
using MonG1WebApp.Models;

namespace MonG1WebApp.Repository
{
    //Sara
    public class EmployeeRepository :IEmployeeRepository
    {
        ITIContext context;
        public EmployeeRepository(ITIContext context)
        {
            this.context = context;//dont create
        }
        //CRUD
        public void Add(Employee obj)
        {
            context.Employees.Add(obj);
        }

        public void Delete(int id)
        {
            Employee emp = GetByID(id);
            context.Employees.Remove(emp);
        }

        public List<Employee> GetAll()//pagain ?????
        {
            return context.Employees.ToList();
        }

        public Employee GetByID(int id)//,string includes="")
        {
            //if(includes=="")
            return context.Employees.FirstOrDefault(e => e.Id == id);
            //else
            //{
            //    return context.Employees.Include(includes).FirstOrDefault(e => e.Id == id);

            //}
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Employee obj)
        {
            //oldd 
            Employee empFromDb=GetByID(obj.Id);
            //change AutoMApper
            empFromDb.Name = obj.Name;
            empFromDb.Salary= obj.Salary;
            empFromDb.DepartmentID= obj.DepartmentID;
            empFromDb.ImageURL= obj.ImageURL;
            empFromDb.Email = obj.Email;
        }
    }
}
