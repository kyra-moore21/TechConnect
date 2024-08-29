using Microsoft.EntityFrameworkCore;
using TechConnect.Interfaces;
using TechConnect.Models.Context;
using TechConnect.Models.DTOs;
using TechConnect.Models.Entities;

namespace TechConnect.Services
{
    public class SkillService : ISkill
    {
        private readonly TechconnectdbContext _context;

        public SkillService(TechconnectdbContext context)
        {
            _context = context;
        }

        //TBD get skills by user or by post 
        public async Task<List<SkillDetailDTO>> GetSkillsAsync()
        {
            var skills = await _context.Skills
                .Select(s => new SkillDetailDTO
                {
                    Id = s.Id,
                    SkillName = s.SkillName
                })
                .ToListAsync();
            return skills;

        }
        public async Task<SkillDetailDTO> GetSkillByIdAsync(int id)
        {
            var skill = await _context.Skills
                .Where(s => s.Id == id).FirstOrDefaultAsync();
            SkillDetailDTO skillDTO = new SkillDetailDTO
            {
                Id = skill.Id,
                SkillName = skill.SkillName
            };
            return skillDTO;
        }
        public async Task<SkillCreateDTO> CreateSkillAsync(SkillCreateDTO createSkillDTO)
        {
            var skill = new Skill
            {
                SkillName = createSkillDTO.SkillName,

            };
            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();
            return new SkillCreateDTO
            {
                SkillName = skill.SkillName
            };
        }
        public async Task<SkillDetailDTO> UpdateSkillAsync(int id, SkillDetailDTO skillDTO)
        {
            Skill s = await _context.Skills.FindAsync(id);
            if (s == null)
            {
                return null;
            }
            s.SkillName = skillDTO.SkillName;
            await _context.SaveChangesAsync();
            return new SkillDetailDTO
            {
                Id = s.Id,
                SkillName = s.SkillName
            };
        }
        public async Task<bool> DeleteSkillAsync(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill != null)
            {
                _context.Skills.Remove(skill);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
