﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InternetShop.Models;
using InternetShop.Services;

namespace InternetShop.Controllers
{
    public class HomeController : Controller
    {
        ShopService shopService = new ShopService();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            //ViewData["Message"] = "Your contact page.";

            //return View();
            using (var context = new ShopContext())
            {
                return View(context.Products.ToList());
            }
        }

        public IActionResult SearchProducts(string term)
        {
            return View(shopService.SearchProducts(term));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
