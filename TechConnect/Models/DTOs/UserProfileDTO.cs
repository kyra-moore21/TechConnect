namespace TechConnect.Models.DTOs
{
    public class UserProfileDTO
    { 
        public string? AboutMe { get; set; }

        public string? ProfilePicture { get; set; }

        public List<string> SocialLinks { get; set; }
    }
}
