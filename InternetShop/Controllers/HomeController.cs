using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InternetShop.Models;
using InternetShop.Services;
using System.Text;

namespace InternetShop.Controllers
{
    public class HomeController : Controller
    {
        ShopContext sp = new ShopContext();
        ShopService shopService = new ShopService();

        private void LoadUserData()
        {
            byte[] userBytes;
            string user = null;
            if (HttpContext.Session.TryGetValue("User", out userBytes))
                user = Encoding.ASCII.GetString(userBytes);
            ViewData["User"] = user;

            byte[] isAdminBytes;
            bool isAdmin = false;
            if (HttpContext.Session.TryGetValue("IsAdmin", out isAdminBytes))
                isAdmin = BitConverter.ToBoolean(isAdminBytes, 0);
            ViewData["IsAdmin"] = isAdmin;
        }

        public IActionResult Index()
        {
            LoadUserData();
            return View();
        }

        public IActionResult Branches()
        {
            LoadUserData();
            ViewData["Message"] = "Your application description page.";

            return View(sp.Branches.AsEnumerable());
        }

        public IActionResult Products(string searchTerm)
        {
            LoadUserData();
            return View(shopService.SearchProducts(searchTerm ?? string.Empty));
        }

        public IActionResult Analytics()
        {
            LoadUserData();
            return View();
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
