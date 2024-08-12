using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using TechConnect.Interfaces;
using TechConnect.Models.Context;
using TechConnect.Models.DTOs;
using TechConnect.Models.Entities;

namespace TechConnect.Services
{
    public class UserProfileService : IUserProfile
    {
        private readonly TechconnectdbContext _context;

        public UserProfileService(TechconnectdbContext context)
        {
            _context = context;
        }

        public async Task<List<UserProfileDTO>> GetAllProfilesAsync()
        {
            var profiles = await _context.Userprofiles
                .Select(u => new UserProfileDTO{
                    AboutMe = u.AboutMe,
                   ProfilePicture = u.ProfilePicture,
                   SocialLinks = u.SocialLinks,
            })
                .ToListAsync();
            return profiles;
        }

        public async Task<Userprofile> GetUserProfileAsync(int id)
        {
            var profile = await _context.Userprofiles
                .Where(u => u.Userid == id).FirstOrDefaultAsync();
            return profile;
        }

        public async Task<UserProfileDTO> CreateUserProfileAsync(UserProfileDTO upDTO)
        {
            var profile = new Userprofile
            {
                AboutMe = upDTO.AboutMe,
                ProfilePicture = upDTO.ProfilePicture,
                SocialLinks = upDTO.SocialLinks,
            };
            _context.Userprofiles.Add(profile);
            await _context.SaveChangesAsync();
            return new UserProfileDTO
            {
                AboutMe = profile.AboutMe,
                ProfilePicture = profile.ProfilePicture,
                SocialLinks = profile.SocialLinks,
            };

        }

        public async Task<UserProfileDTO> UpdateUserProfileAsync(int id, UserProfileDTO userProfileDTO)
        {
            Userprofile u = await _context.Userprofiles.FindAsync(id);
            if(u == null)
            {
                return null;
            }
            u.AboutMe = userProfileDTO.AboutMe;
            u.ProfilePicture = userProfileDTO.ProfilePicture;
            u.SocialLinks = userProfileDTO.SocialLinks;

            await _context.SaveChangesAsync();

            return new UserProfileDTO
            {
                AboutMe = userProfileDTO.AboutMe,
                ProfilePicture = userProfileDTO.ProfilePicture,
                SocialLinks = userProfileDTO.SocialLinks
            };
 
        }

        public async Task<bool> DeleteUserProfileAsync(int id)
        {
            Userprofile u = await _context.Userprofiles.FindAsync(id);
            if(u != null)
            {
                _context.Userprofiles.Remove(u);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
