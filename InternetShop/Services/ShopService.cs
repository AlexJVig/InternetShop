using System;
using System.Collections.Generic;
using System.Linq;
using InternetShop.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Services
{
    public class ShopService
    {
        public IList<Product> GetAllProductsFromInventory()
        {
            using (var context = new ShopContext())
            {
                return context.Products.ToList();
            }
        }

        public IList<CategoryResult> GetAllCategories()
        {
            using (var context = new ShopContext())
            {
                var categories = context.Categories.ToList();

                var productsCount = context.Products.GroupBy(p => p.CategoryID)
                .Select(group => new
                {
                    categoryId = group.FirstOrDefault().CategoryID,
                    count = group.Count()
                }).ToList();

                return categories.Join(productsCount,
                                       c => c.CategoryID,
                                       pc => pc.categoryId,
                                       (c, pc) => new CategoryResult()
                                       {
                                           CategoryID = c.CategoryID,
                                           Name = c.Name,
                                           Count = pc.count
                                       })
                                 .ToList();
            }
        }
    }
}
