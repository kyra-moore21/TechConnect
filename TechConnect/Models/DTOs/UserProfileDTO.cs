namespace TechConnect.Models.DTOs
{
    public class UserProfileDetailDTO
    { 
        public int Id { get; set; }
        public string? AboutMe { get; set; }

        public string? ProfilePicture { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
       
    }

    public class UserProfileCreateDTO
    {
        public string? AboutMe { get; set; }

        public string? ProfilePicture { get; set; }


        
    }
}
