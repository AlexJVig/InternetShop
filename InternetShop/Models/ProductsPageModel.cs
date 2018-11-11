using System;
using System.Collections.Generic;

namespace InternetShop.Models
{
    public class ProductsPageModel
    {
        public IEnumerable<Product> Products
        {
            get;
            set;
        }

        public IEnumerable<CategoryResult> Categories
        {
            get;
            set;
        }

        public ProductsPageModel()
        {
        }
    }
}
