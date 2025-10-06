using System.ComponentModel.DataAnnotations;

namespace MonG1WebApp.ViewModels
{
    public class LoginUserViewModel
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }

}
