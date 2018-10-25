using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetShop.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InternetShop.Controllers
{
    public class ShopController : Controller
    {
        DbService dbService = new DbService();

        public IActionResult GetAllProducts()
        {
            var result = dbService.getAllProductsFromInventory();
            var jsonResult = new JsonResult(result);

            return jsonResult;
            //return View();
        }
    }
}
