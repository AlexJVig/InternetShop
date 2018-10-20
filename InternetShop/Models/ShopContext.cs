using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace InternetShop.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext()
        { }

        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Filename=./shopDB.db");
            }
        }
    }
}
