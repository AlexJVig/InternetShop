using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetShop.Models
{
    public class RegisterDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int ClosestBranchID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
