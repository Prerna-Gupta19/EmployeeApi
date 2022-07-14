using System.ComponentModel.DataAnnotations;

namespace EmployeeApi.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public byte[] HashKey { get; set; }
        public string Role { get; set; }
    }
}
