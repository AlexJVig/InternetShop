using System;
using InternetShop.Models;
using InternetShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Controllers
{
    public class UsersController : Controller
    {
        UserService userService = new UserService();

        // TODO: Add registration too.
        public IActionResult AttemptLogin(LoginDetails details)
        {
            return new JsonResult(userService.AttemptLogin(details));
        }
    }
}
