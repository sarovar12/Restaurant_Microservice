using Microsoft.EntityFrameworkCore;
using Restaurant.Services.ShoppingCartAPI.Model;


namespace Restaurant.Services.ShoppingCartAPI.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<CartHeader> CartHeaders { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }
    }
}
