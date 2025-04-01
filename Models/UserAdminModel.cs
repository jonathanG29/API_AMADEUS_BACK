using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_AMADEUS.Models
{
    public class UserAdminModel
    {
        public int Id { get; set; }
        public string username { get; set; } = string.Empty;
        public string user_password { get; set; } = string.Empty;
    }
}