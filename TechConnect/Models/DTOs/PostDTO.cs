namespace TechConnect.Models.DTOs
{
    public class PostDetailDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public UserDetailDTO? User { get; set; }
        public List<SkillDetailDTO> Skills { get; set; } = new List<SkillDetailDTO>();
       
    }

    public class PostCreateDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
        public List<int> SkillIds { get; set; } = new List<int>();
    }

}
