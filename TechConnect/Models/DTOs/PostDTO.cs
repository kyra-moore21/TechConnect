namespace TechConnect.Models.DTOs
{
    public class PostDetailDTO
    {
        public string Title { get; set; }

        public string? Description { get; set; }

        public List<int> SkillIds { get; set; } = new List<int>();
    }
    public class PostCreateDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public List<int> SkillIds { get; set; } = new List<int>();
    }
}
