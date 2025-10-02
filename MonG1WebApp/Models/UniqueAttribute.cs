using System.ComponentModel.DataAnnotations;

namespace MonG1WebApp.Models
{

    //Server Side Only
    //MVC + Web API
    public class UniqueAttribute:ValidationAttribute
    {
        //public string Msg { get; set; }

        //public UniqueAttribute(int xyz)
        //{
            
        //}

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string email = value.ToString();

            Employee empFromRe = validationContext.ObjectInstance as Employee;
            
            ITIContext context =(ITIContext) validationContext.GetRequiredService(typeof(ITIContext));

            Employee empFromDb=context.Employees
                .FirstOrDefault(e => e.Email == email && e.DepartmentID==empFromRe.DepartmentID);
            
            if(empFromDb == null) {
                return ValidationResult.Success;
            }
            return new ValidationResult("Email Already Exist :(");
        }
    }
}
