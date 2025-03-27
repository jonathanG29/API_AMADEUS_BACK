namespace API_AMADEUS.DTOs
{
    public class UserAdminDTO
    {
        public int Id { get; set; }
        public required string username { get; set; } 
        public required string user_password { get; set; } 
    }
}