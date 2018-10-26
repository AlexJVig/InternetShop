using System;
using System.Collections.Generic;
using System.Linq;
using InternetShop.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Services
{
    public class ShopService
    {
        public List<Product> getAllProductsFromInventory()
        {
            using (var context = new ShopContext())
            {
                return context.Products.ToList();
            }
        }
    }
}
