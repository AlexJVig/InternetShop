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

        public IActionResult Register(RegisterDetails details)
        {
           if (userService.Register(details))
                return Ok();

            return StatusCode(500);
        }

        public IActionResult CheckName(string username)
        {
            return Ok(userService.DoesUserExists(username));
        }
    }
}
