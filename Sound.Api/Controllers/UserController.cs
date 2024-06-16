using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sound.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace Sound.Api.Controllers
{
    [Controller, Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public UserManager<User> UserManager { get; }

        public UserController(UserManager<User> userManager)
        {
            UserManager = userManager;
        }
        [HttpGet("get-users")]
        public IActionResult GetUsers()
        {
            return Ok(UserManager.Users);
        }

    }
    public class UserViewModel
    {
        public DateOnly BirthDate { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}