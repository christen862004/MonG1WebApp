using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonG1WebApp.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name Required")]
        [MinLength(3,ErrorMessage ="Name Must Be More Than 3 Letter")]
        [MaxLength(25)]
      //[StringLength(25,MinimumLength =3)]
        public string Name { get; set; }

        //[Range(7000,50000)]
        //[GreaterThan(7000)]
        [Remote("CheckSalary","Employee",AdditionalFields = "DepartmentID",ErrorMessage ="Invalid Salary")]
        public int Salary { get; set; }

        [RegularExpression(@"\w+\.(jpg|png)",ErrorMessage ="Image Must be jpg or png")]
        public string? ImageURL { get; set; }

        [Unique]//(10,Msg ="sjhsdjfh")]
        public string? Email { get; set; }

        [ForeignKey("Department")]
        [Display(Name="Department")]
        public int DepartmentID { get; set; }

        //[Required]
        public Department? Department { get; set; }
    }
}
