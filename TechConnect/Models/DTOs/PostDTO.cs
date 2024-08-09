namespace TechConnect.Models.DTOs
{
    public class PostDTO
    {
        public string Title { get; set; }

        public string? Description { get; set; }

        public List<int> SkillIds { get; set; } = new List<int>();
    }
}
