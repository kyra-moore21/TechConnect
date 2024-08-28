using TechConnect.Models.Entities;
using TechConnect.Models.DTOs;
namespace TechConnect.Interfaces
{
    public interface IUser
    {
        Task<List<UserDetailDTO>> GetUsersAsync();
        Task<UserDetailDTO> GetUserByEmailAsync(string email);

        Task<UserDetailDTO> UpdateUserAsync(int id, UserDetailDTO userDto);

        Task<UserCreateDTO> CreateUserAsync(UserCreateDTO userDto);
        Task<bool> DeleteUserAsync(string email);
    }
}
