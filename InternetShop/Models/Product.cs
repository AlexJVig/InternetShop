using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetShop.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        public int SupplierID { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int CategoryID { get; set; }

        public string ProductName { get; set; }
    }
}
