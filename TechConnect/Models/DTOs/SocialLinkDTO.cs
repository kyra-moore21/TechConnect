namespace TechConnect.Models.DTOs
{
    public class SocialLinkDetailDTO
    {
        public int Id { get; set; }
        public string? Link { get; set; }
        public int SocialMediaTypeId { get; set; }

    }
    public class SocialLinkCreateDTO
    {
       
        public string? Link { get; set; }
        public int SocialMediaTypeId { get; set; }
    }
}
