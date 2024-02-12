using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Services.Authentication.Models;

namespace Restaurant.Services.Authentication.DatabaseContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

            
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        
    }
}
 