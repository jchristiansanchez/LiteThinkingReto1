using CleanArchitecture.Application;
using CleanArchitecture.Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserApplication _userAplication;

        public UserController(IUserApplication userAplication)
        {
            _userAplication = userAplication;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDto User)
        {
            try
            {
                var user = await _userAplication.Save(User);
                return CreatedAtAction(nameof(GetUsers), new {  }, user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userAplication.GetAll();
            return Ok(users);
        }
    }
}
