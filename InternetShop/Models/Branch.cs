﻿using System;
namespace InternetShop.Models
{
    public class Branch
    {
        public int BranchID { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string PhoneNumber { get; set; }

        public string SundayThursday { get; set; }

        public string Friday { get; set; }

        public string Saturday { get; set; }
    }
}
