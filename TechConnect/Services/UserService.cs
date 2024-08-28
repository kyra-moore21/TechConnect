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
        public async Task<List<UserDetailDTO>> GetUsersAsync()
        {
            var users = await _context.Users
                .Select (u => new UserDetailDTO
                {
                    Id = u.Id,
                    Email = u.Email,
                    FullName = u.FullName,

                })
                .ToListAsync();
            return users;
        }

        public async Task<UserDetailDTO> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users
                .Where(u => u.Email == email)
                .Select(u => new UserDetailDTO
                {
                    Id = u.Id,
                    Email = u.Email,
             
                    FullName = u.FullName,
           

                })
                .FirstOrDefaultAsync();
            return user;
                 
        }

        public async Task<UserCreateDTO> CreateUserAsync(UserCreateDTO userDto)
        {
            var userRecordArgs = new UserRecordArgs
            {
                Email = userDto.Email,
                DisplayName = userDto.FullName,
                Password = userDto.Password
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
            return new UserCreateDTO
            {
                Email = user.Email,
                FullName = user.FullName,
            };
        }
        public async Task<UserDetailDTO> UpdateUserAsync(int id, UserDetailDTO userDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
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

            return new UserDetailDTO
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
