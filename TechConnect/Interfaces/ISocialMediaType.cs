using TechConnect.Models.DTOs;

namespace TechConnect.Interfaces
{
    public interface ISocialMediaType
    {
        Task<List<SocialMediaTypeDetailDTO>> GetSocialTypesAsync();
        Task<SocialMediaTypeDetailDTO> GetSocialTypeByIdAsync(int id);
        Task<SocialMediaTypeCreateDTO> CreateSocialTypeAsync(SocialMediaTypeCreateDTO createSocialTypeDTO);
        Task<SocialMediaTypeDetailDTO> UpdateSocialTypeAsync(int id, SocialMediaTypeDetailDTO socialTypeDTO);
        Task<bool> DeleteSocialTypeAsync(int id);
    }
}
