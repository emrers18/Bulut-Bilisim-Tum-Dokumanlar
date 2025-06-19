using Microsoft.EntityFrameworkCore;
using MyShopApi.Models;

namespace MyShopApi.Data
{
    public class MyShopContext : DbContext
    {
        public MyShopContext(DbContextOptions<MyShopContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Ayakkabı",
                    Description = "Beyaz spor ayakkabı",
                    Price = 89.99M,
                    ImgUrl = "/images/shoe-white.jpg",
                    Stock = 0
                },
                new Product
                {
                    Id = 2,
                    Name = "Sırt Çantası",
                    Description = "Siyah şık çanta",
                    Price = 59.99M,
                    ImgUrl = "/images/backpack-black.jpg",
                    Stock = 10
                },
                new Product
                {
                    Id = 3,
                    Name = "Kol Saati",
                    Description = "Şık dijital kol saati",
                    Price = 129.99M,
                    ImgUrl = "/images/watch.jpg",
                    Stock = 5
                }
            );
        }

    }
}
