using System;
using System.Diagnostics;
using System.Linq;
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
        ProductsPageModel model = new ProductsPageModel();
    
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

        public IActionResult Products(string searchTerm, int categoryId)
        {
            LoadUserData();

            if (categoryId > 0)
            {
                model.Products = shopService.GetProductsByCategory(categoryId);
            }
            else
            {
                model.Products = shopService.SearchProducts(searchTerm ?? string.Empty);
            }

            if (model.Categories == null)
            {
                model.Categories = shopService.GetAllCategories();
            }

            return View(model);
        }

        public IActionResult About(string searchTerm)
        {
            LoadUserData();
            return View();
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

        [HttpPut]
        public IActionResult UpdateProduct(int id, [FromBody]Product product)
        {
            if (shopService.UpdateProduct(id, product))
                return Ok();
            else
                return StatusCode(500);
        }
    }
}
