﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InternetShop.Models;

namespace InternetShop.Controllers
{
    public class HomeController : Controller
    {
        ShopContext sp = new ShopContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Branches()
        {
            ViewData["Message"] = "Your application description page.";

            return View(sp.Branches.AsEnumerable());
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
