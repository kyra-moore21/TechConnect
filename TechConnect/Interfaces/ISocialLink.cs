using TechConnect.Models.DTOs;

namespace TechConnect.Interfaces
{
    public interface ISocialLink
    {
        Task<List<SocialLinkDetailDTO>> GetAllLinksAsync();
        Task<SocialLinkDetailDTO> GetLinkByIdAsync(int id);
        Task<SocialLinkDetailDTO> CreateLinkAsync(SocialLinkCreateDTO createLinkDTO);
        Task<SocialLinkDetailDTO> UpdateLinkAsync(int id, SocialLinkDetailDTO linkDTO);
        Task<bool> DeleteLinkAsync(int id);
    }
}
