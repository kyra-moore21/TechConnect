namespace TechConnect.Models.DTOs
{
    public class SocialMediaTypeDetailDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string ImageUrL { get; set; }

    }
    public class SocialMediaTypeCreateDTO
    {
        public string Type { get; set; }
        public string ImageUrL { get; set; }
    }
}
