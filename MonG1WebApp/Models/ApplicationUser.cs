using Microsoft.AspNetCore.Identity;

namespace MonG1WebApp.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? Address { get; set; }
    }
}
