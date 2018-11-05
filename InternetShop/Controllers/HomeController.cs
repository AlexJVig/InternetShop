using System;
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
<<<<<<< HEAD
        ShopContext sp = new ShopContext();
=======
        ShopService shopService = new ShopService();

>>>>>>> d1fbafb2ee1b903d6d49f0a0dd38f37d1198b45e
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Branches()
        {
            ViewData["Message"] = "Your application description page.";

            return View(sp.Branches.AsEnumerable());
        }

        public IActionResult Contact(string searchTerm)
        {
            return View(shopService.SearchProducts(searchTerm ?? string.Empty));
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
