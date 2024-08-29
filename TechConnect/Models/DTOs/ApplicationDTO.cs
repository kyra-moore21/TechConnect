namespace TechConnect.Models.DTOs
{
    public class ApplicationDetailDTO
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public string Status { get; set; }
        public DateTime AppDate { get; set; }
        public UserDetailDTO? User { get; set; } //Include User Details
    }
    public class ApplicationCreateDTO
    {
      
        public string? Message { get; set; }
        public string Status { get; set; } 
    }
}
