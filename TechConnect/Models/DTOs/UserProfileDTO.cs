namespace TechConnect.Models.DTOs
{
    public class UserProfileDetailDTO
    { 
        public int Id { get; set; }
        public string? AboutMe { get; set; }

        public string? ProfilePicture { get; set; }

        public List<string> SocialLinks { get; set; }
    }

    public class UserProfileCreateDTO
    {
        public string? AboutMe { get; set; }

        public string? ProfilePicture { get; set; }

        public List<string> SocialLinks { get; set; }
    }
}
