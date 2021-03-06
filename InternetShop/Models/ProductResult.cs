﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetShop.Models
{
    public class ProductResult
    {

        public ProductResult(Product product, Category category)
        {
            this.Category = category;
            this.ProductID = product.ProductID;
            this.SupplierID = product.SupplierID;
            this.Price = product.Price;
            this.Description = product.Description;
            this.ProductName = product.ProductName;
            this.Image = product.Image;
        }

        public ProductResult(ProductResult product, IEnumerable<Inventory> inventory) 
        {
            this.Category = product.Category;
            this.ProductID = product.ProductID;
            this.SupplierID = product.SupplierID;
            this.Price = product.Price;
            this.Description = product.Description;
            this.ProductName = product.ProductName;
            this.Image = product.Image;
            this.IsInStock = inventory.Sum(i => i.Quantity) > 0;
        }

        public int ProductID { get; set; }

        public int SupplierID { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }

        public string ProductName { get; set; }

        public bool IsInStock { get; set; }

        public string Image
        {
            get;
            set;
        }
    }
}
