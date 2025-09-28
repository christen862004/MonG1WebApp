

using MonG1WebApp.Models;

namespace MonG1WebApp.ViewModels
{
    public class EmployeeWithDeptListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string? ImageURL { get; set; }
        public string? Email { get; set; }

        public int DepartmentID { get; set; }
        //-------------------------------------------
        public List<Department> DeptList { get; set; }
    }
}
