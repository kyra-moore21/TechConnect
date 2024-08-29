using TechConnect.Models.DTOs;

namespace TechConnect.Interfaces
{
    public interface ISkill
    {
        Task<List<SkillDetailDTO>> GetSkillsAsync();
        Task<SkillDetailDTO> GetSkillByIdAsync(int id);
        Task<SkillCreateDTO> CreateSkillAsync(SkillCreateDTO createSkillDTO);
        Task<SkillDetailDTO> UpdateSkillAsync(int id, SkillDetailDTO skillDTO);
        Task<bool> DeleteSkillAsync(int id);
    }
}
