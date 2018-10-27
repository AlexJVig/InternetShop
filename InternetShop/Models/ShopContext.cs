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
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Filename=./shopDB.db");
            }
        }
    }
}
