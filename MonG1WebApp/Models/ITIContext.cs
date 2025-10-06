using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MonG1WebApp.Models
{
    public class ITIContext:IdentityDbContext<ApplicationUser>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        //public ITIContext() : base()
        //{ }

        public ITIContext(DbContextOptions<ITIContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MonR1_25;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        //}

        //DBMS (SQl Server) -  server name - login - database name ..... (DbContext Option)

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(new Department() { Id=1, Name="Sd" ,ManagerName="Ahmed"});
            modelBuilder.Entity<Department>().HasData(new Department() { Id=2, Name="OS" ,ManagerName="Mohamed"});
            modelBuilder.Entity<Employee>().HasData(new Employee() { Id=1, Name="Mohamed" ,Email="Mohamed@gamil",ImageURL="m.png",Salary=30000,DepartmentID=1});
            modelBuilder.Entity<Employee>().HasData(new Employee() { Id=2, Name="Mohamed" ,Email="Mohamed@gamil",ImageURL="m.png",Salary=30000,DepartmentID=1});
            modelBuilder.Entity<Employee>().HasData(new Employee() { Id=3, Name="Mariam" ,Email="Mohamed@gamil",ImageURL="2.jpg",Salary=30000,DepartmentID=2});
            modelBuilder.Entity<Employee>().HasData(new Employee() { Id=4, Name="Sara" ,Email="Mohamed@gamil",ImageURL="2.jpg",Salary=30000,DepartmentID=2});

            base.OnModelCreating(modelBuilder);
        }
    }
}
