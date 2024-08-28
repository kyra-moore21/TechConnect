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

        public async Task<List<UserProfileDetailDTO>> GetAllProfilesAsync()
        {
            var profiles = await _context.Userprofiles
                .Select(u => new UserProfileDetailDTO{
                    AboutMe = u.AboutMe,
                   ProfilePicture = u.ProfilePicture,
                   SocialLinks = u.SocialLinks,
            })
                .ToListAsync();
            return profiles;
        }

        public async Task<UserProfileDetailDTO> GetUserProfileAsync(int id)
        {
            var profile = await _context.Userprofiles
                .Where(u => u.Userid == id).FirstOrDefaultAsync();
            UserProfileDetailDTO profileDTO = new UserProfileDetailDTO
            {
                Id = profile.Userid,
                AboutMe = profile.AboutMe,
                ProfilePicture = profile.ProfilePicture,
                SocialLinks = profile.SocialLinks,

            };
            return profileDTO;
        }

        public async Task<UserProfileCreateDTO> CreateUserProfileAsync(UserProfileCreateDTO upDTO)
        {
            var profile = new Userprofile
            {
                AboutMe = upDTO.AboutMe,
                ProfilePicture = upDTO.ProfilePicture,
                SocialLinks = upDTO.SocialLinks,
            };
            _context.Userprofiles.Add(profile);
            await _context.SaveChangesAsync();
            return new UserProfileCreateDTO
            {
                AboutMe = profile.AboutMe,
                ProfilePicture = profile.ProfilePicture,
                SocialLinks = profile.SocialLinks,
            };

        }

        public async Task<UserProfileDetailDTO> UpdateUserProfileAsync(int id, UserProfileDetailDTO userProfileDTO)
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

            return new UserProfileDetailDTO
            {
                AboutMe = u.AboutMe,
                ProfilePicture = u.ProfilePicture,
                SocialLinks = u.SocialLinks
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
