using Microsoft.EntityFrameworkCore;
using Restaurant.Services.EmailAPI.Models;

namespace Restaurant.Services.EmailAPI.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

            
        }
        public DbSet<EmailLogger> EmailLoggers { get; set; }
        
    }
}
