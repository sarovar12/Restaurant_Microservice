using Microsoft.AspNetCore.Identity;

namespace Restaurant.Services.Authentication.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
