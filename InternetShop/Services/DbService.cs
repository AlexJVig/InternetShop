using System;
using System.Linq;
using InternetShop.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Services
{
    public class DbService
    {
        public void getAllProductsFromInventory()
        {
            //var optionsBuilder = new DbContextOptionsBuilder<ShopContext>();
            //optionsBuilder.UseSqlServer(@"Server = 127.0.0.1, 1433; Database = ShopDB; User Id = SA; Password = Aa123456");

            using (var context = new ShopContext())
            {
                //var blogs = context.Products.Where;
                var products = context.Products.Where(p => p.ProductID == 1);
            }
        }
    }
}
