using Microsoft.EntityFrameworkCore;
using Restaurant.Services.ProductAPI.Models;

namespace Restaurant.Services.ProductAPI.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

            
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                ProductName = "Samosa",
                ProductPrice = 15,
                ProductDescription = "Samosa Ho yarr",
                ImageUrl = "https://sarovarblob.blob.core.windows.net/restaurant/1.jpg",
                CategoryName = "Appetizer"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                ProductName = "Chicken Momo",
                ProductPrice = 53.99,
                ProductDescription = "Mittho Chicken Momo",
                ImageUrl = "https://sarovarblob.blob.core.windows.net/restaurant/2.jpg",
                CategoryName = "Appetizer"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                ProductName = "Cheese Cake",
                ProductPrice = 10.99,
                ProductDescription = "Yesko craving bhaira cha",
                ImageUrl = "https://sarovarblob.blob.core.windows.net/restaurant/3.jpg",
                CategoryName = "Dessert" 
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                ProductName = "Chowmein",
                ProductPrice = 15,
                ProductDescription = "4 Products are enough",
                ImageUrl = "https://sarovarblob.blob.core.windows.net/restaurant/4.jpg",
                CategoryName = "Entree"
            });
        }
    }
}
