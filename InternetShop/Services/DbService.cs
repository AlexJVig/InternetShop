using System;
using System.Collections.Generic;
using System.Linq;
using InternetShop.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Services
{
    public class DbService
    {
        public List<Product> getAllProductsFromInventory()
        {
            using (var context = new ShopContext())
            {
                //var blogs = context.Products.Where;
                var products = context.Products.Where(p => p.ProductID == 1);

                return products.ToList();
            }
        }
    }
}
