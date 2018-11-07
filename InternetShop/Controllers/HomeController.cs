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
        ShopContext sp = new ShopContext();
        ShopService shopService = new ShopService();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Branches()
        {
            ViewData["Message"] = "Your application description page.";

            return View(sp.Branches.AsEnumerable());
        }

        public IActionResult Products(string searchTerm)
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

        [HttpGet]
        public IActionResult GetProduct(int id)
        {
            var product = shopService.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet]
        public IActionResult GetBranches()
        {
            return Ok(sp.Branches.AsEnumerable());
        }
    }
}
