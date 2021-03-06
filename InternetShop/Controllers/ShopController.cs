﻿using InternetShop.Models;
using InternetShop.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InternetShop.Controllers
{
    public class ShopController : Controller
    {
        ShopService shopService = new ShopService();

        public IActionResult GetAllProducts()
        {
            return new JsonResult(shopService.GetAllProductsFromInventory());
        }

        public IActionResult GetAllCategories()
        {
            return new JsonResult(shopService.GetAllCategories());
        }

        public IActionResult SearchProducts(string term)
        {
            return View(shopService.SearchProducts(term));
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            if (shopService.CreateProduct(product))
                return Ok();
            else
                return StatusCode(500);
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            if (shopService.DeleteProduct(id))
                return Ok(id);
            else
                return StatusCode(500);
        }

        [HttpGet]
        public IActionResult ProductsStock()
        {
            return Ok(shopService.GetProductsStock());
        }
    }
}
