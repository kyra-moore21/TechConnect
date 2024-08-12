using TechConnect.Models.DTOs;
using TechConnect.Models.Entities;

namespace TechConnect.Interfaces
{
    public interface IUserProfile
    {
        Task<List<UserProfileDTO>> GetAllProfilesAsync();
        Task<Userprofile> GetUserProfileAsync(int id);

        Task<UserProfileDTO> CreateUserProfileAsync(UserProfileDTO upDTO);

        Task<UserProfileDTO> UpdateUserProfileAsync(int id, UserProfileDTO userProfileDTO);
        Task<bool> DeleteUserProfileAsync(int id);
    }
}
