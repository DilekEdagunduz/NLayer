using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Product> ProductFeatures { get; set; }

        //Entity için ayarlama yapmak için migration esnasında override yapmamız lazım
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());// 

            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
            {
                Id = 1,
                Color = "Kırmızı",
                Width = 40,
                Height = 50,
                ProductId = 1

            },
            new ProductFeature()
            {
                Id = 2,
                Color = "Mavi",
                Width = 40,
                Height = 50,
                ProductId = 2

            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
