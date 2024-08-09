using TechConnect.Interfaces;
using TechConnect.Models.Context;
using FirebaseAdmin.Auth;
using TechConnect.Models.Entities;
using TechConnect.Models.DTOs;
using Microsoft.EntityFrameworkCore;
namespace TechConnect.Services

{
    public class UserService : IUser
    {
        private readonly TechconnectdbContext _context;
        private readonly FirebaseAuth _firebaseAuth;

        public UserService(TechconnectdbContext context)
        {
            _context = context;
            _firebaseAuth = FirebaseAuth.DefaultInstance;
        }
        public async Task<List<UserDTO>> GetUsersAsync()
        {
            var users = await _context.Users
                .Select (u => new UserDTO
                {
                    Email = u.Email,
                    FullName = u.FullName,
                })
                .ToListAsync();
            return users;
        }

        public async Task<UserDTO> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users
                .Where(u => u.Email == email)
                .Select(u => new UserDTO
                {
                    Email = u.Email,
                    FullName = u.FullName,

                })
                .FirstOrDefaultAsync();
            return user;
                 
        }

        public async Task<UserDTO> CreateUserAsync(UserDTO userDto)
        {
            var userRecordArgs = new UserRecordArgs
            {
                Email = userDto.Email,
                DisplayName = userDto.FullName
            };
            var userRecord = await _firebaseAuth.CreateUserAsync(userRecordArgs);

            var user = new User
            {
                FirebaseId = userRecord.Uid,
                Email = userDto.Email,
                FullName = userDto.FullName,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Status = "Active"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return new UserDTO
            {
                Email = user.Email,
                FullName = user.FullName,
            };
        }
        public async Task<UserDTO> UpdateUserAsync(UserDTO userDto, string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return null; 
            }
            var userRecordArgs = new UserRecordArgs
            {
                Uid = user.FirebaseId,
                Email = userDto.Email,
                DisplayName = userDto.FullName,
            };
            var updatedUserRecord = await _firebaseAuth.UpdateUserAsync(userRecordArgs);

            user.FullName = userDto.FullName;
            user.Email = userDto.Email;

            await _context.SaveChangesAsync();

            return new UserDTO
            {
                Email = user.Email,
                FullName = user.FullName,
            };

        }

        public async Task<bool> DeleteUserAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return false;
            }

            //remove firebase user 
            try
            {
                await _firebaseAuth.DeleteUserAsync(user.FirebaseId);

            _context.Remove(user);
            await _context.SaveChangesAsync();
            return true;
            }
            catch (FirebaseAuthException ex)
            {
                return false;
            }
        }
    }
}
