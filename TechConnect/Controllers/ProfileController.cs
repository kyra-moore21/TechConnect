using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TechConnect.Interfaces;
using TechConnect.Models.Context;
using TechConnect.Models.DTOs;
using TechConnect.Models.Entities;

namespace TechConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IUserProfile _profile;
        public ProfileController(IUserProfile profile)
        {
            _profile = profile;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllProfiles()
        {
            var profiles = await _profile.GetAllProfilesAsync();
            return Ok(profiles);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetUserprofileAsync(int id)
        {
            Userprofile profile = await _profile.GetUserProfileAsync(id);
            if (profile == null)
            {
                return NotFound("User not found.");
            }
            return Ok(profile);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateUserProfile(UserProfileDTO upDTO)
        {
            if (upDTO == null)
            {
                return BadRequest("Invalid user data.");

            }
            var createdProfile = await _profile.CreateUserProfileAsync(upDTO);
            return Created("", createdProfile);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateProfile(int id, UserProfileDTO upDTO)
        {

            if (upDTO == null)
            {
                return BadRequest("Invalid user data.");
            }
            var updatedUser = await _profile.UpdateUserProfileAsync(id, upDTO);
            if (updatedUser == null)
            {
                return NotFound("Profile not found");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteProfile(int id)
        {
            var result = await _profile.DeleteUserProfileAsync(id);
            if (!result)
            {
                return NotFound("User not found");
            }
            return NoContent();
        }
    }
    
}
