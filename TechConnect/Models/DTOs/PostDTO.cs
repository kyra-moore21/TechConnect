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
       
    }

    public class PostCreateDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
       
    }

}
