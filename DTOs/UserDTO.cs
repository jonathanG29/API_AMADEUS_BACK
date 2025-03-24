namespace API_AMADEUS.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public required string full_name { get; set; } 
        public required string email { get; set; } 
    }
}