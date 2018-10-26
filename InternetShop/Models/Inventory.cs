using System;
namespace InternetShop.Models
{
    public class Inventory
    {
        public int InventoryID
        {
            get;
            set;
        }
        public int ProductID { get; set; }

        public int BranchId { get; set; }

        public int Quantity { get; set; }
    }
}
