namespace TechConnect.Models.DTOs
{
    public class UserDetailDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public string FullName { get; set; }
    }
    public class UserCreateDTO
    {
        public string Email { get; set; }

        public string FullName { get; set; }
        
        //password for testing backend removed later
        public string Password { get; set; }
    }

}
