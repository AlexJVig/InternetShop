using System;
using System.Text;
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
            LoginResult result = userService.AttemptLogin(details);
            if (result.LoginSucceeded)
            {
                User user = userService.GetUser(details.Username);
                HttpContext.Session.Set("User", Encoding.ASCII.GetBytes(user.FirstName));
                HttpContext.Session.Set("IsAdmin", BitConverter.GetBytes(user.IsAdmin == 1));
            }
            return new JsonResult(result);
        }

        public IActionResult Register(RegisterDetails details)
        {
           if (userService.Register(details))
                return Ok();

            return StatusCode(500);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            HttpContext.Session.Remove("IsAdmin");

            return Ok();
        }

        public IActionResult CheckName(string username)
        {
            return Ok(userService.DoesUserExists(username));
        }

        public IActionResult UsersPerBranch()
        {
            return Ok(userService.GetBranchUsers());
        }
    }
}
