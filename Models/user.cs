using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_AMADEUS.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string full_name { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string email { get; set; } = string.Empty;

        public User()
        {
        }
    }
}