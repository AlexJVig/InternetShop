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

        public IList<Product> SearchProducts(string term)
        {
            using (var context = new ShopContext())
            {
                return context.Products.Where(p => p.ProductName.Contains(term) || p.Description.Contains(term)).ToList();
            }
        }

        public bool CreateProduct(Product product)
        {
            using (var context = new ShopContext())
            {
                try
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }
        }

        public ProductResult GetProduct(int id)
        {
            using (var context = new ShopContext())
            {
                return context.Products.Join(context.Categories, p => p.CategoryID, c => c.CategoryID, (product, category) => new ProductResult(product, category)).FirstOrDefault(p => p.ProductID == id);
              
            }
        }
    }
}
