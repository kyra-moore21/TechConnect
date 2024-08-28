using TechConnect.Models.DTOs;
using TechConnect.Models.Entities;

namespace TechConnect.Interfaces
{
    public interface IUserProfile
    {
        Task<List<UserProfileDetailDTO>> GetAllProfilesAsync();
        Task<UserProfileDetailDTO> GetUserProfileAsync(int id);

        Task<UserProfileCreateDTO> CreateUserProfileAsync(UserProfileCreateDTO upDTO);

        Task<UserProfileDetailDTO> UpdateUserProfileAsync(int id, UserProfileDetailDTO userProfileDTO);
        Task<bool> DeleteUserProfileAsync(int id);
    }
}
