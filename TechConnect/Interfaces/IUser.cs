using TechConnect.Models.Entities;
using TechConnect.Models.DTOs;
namespace TechConnect.Interfaces
{
    public interface IUser
    {
        Task<List<UserDTO>> GetUsersAsync();
        Task<UserDTO> GetUserByEmailAsync(string email);

        Task<UserDTO> UpdateUserAsync(UserDTO userDto, string email);

        Task<UserDTO> CreateUserAsync(UserDTO userDto);
        Task<bool> DeleteUserAsync(string email);
    }
}
