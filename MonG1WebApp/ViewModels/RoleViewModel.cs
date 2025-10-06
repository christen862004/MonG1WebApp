using System.ComponentModel.DataAnnotations;

namespace MonG1WebApp.ViewModels
{
    public class RoleViewModel
    {
        [Display(Name ="Role Name")]
        public string RoleName { get; set; }
    }
}
