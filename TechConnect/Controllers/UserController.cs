using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechConnect.Interfaces;
using TechConnect.Models.Context;
using TechConnect.Models.DTOs;
using TechConnect.Services;


namespace TechConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IFirebaseAuthService firebaseAuthService;
        private readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }

        [HttpGet("all")]

        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _user.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _user.GetUserByEmailAsync(email);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            return Ok(user);
        }

        [HttpPost()]

        public async Task<IActionResult> CreateUser([FromBody] UserDTO userDto)
        {
            if (userDto == null || string.IsNullOrEmpty(userDto.Email) || string.IsNullOrEmpty(userDto.FullName))
            {
                return BadRequest("Invalid user data.");
            }
            var createdUser = await _user.CreateUserAsync(userDto);
            if (createdUser == null)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }
            return CreatedAtAction(nameof(GetUserByEmail), new {email = createdUser.Email}, createdUser);
        }

        [HttpPut()]

        public async Task<IActionResult> UpdateUser(UserDTO userDto, string email)
        {
            if(userDto == null || string.IsNullOrEmpty(email))
            {
                return BadRequest("Invalid user data");
            }
            var updatedUser = await _user.UpdateUserAsync(userDto, email);
            if(updatedUser == null)
            {
                return NotFound("User not found");
            }

            return NoContent();
        }

        [HttpDelete("{email}")]
        //eventually will have to set up that when you delete user it deletes everything associated with it
        public async Task<IActionResult> DeleteUser(string email)
        {
            var result = await _user.DeleteUserAsync(email);
            if(!result)
            {
                return NotFound("User not found");
            }
            return NoContent();
        }
    }
}
