using Microsoft.AspNetCore.Mvc;
using Sound.Data.Repositories.Interfaces;

namespace Sound.Api.Controllers
{
    [Controller, Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet("get-users")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _userRepository.GetAllAsync());
        }
    }
}