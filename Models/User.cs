using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class User
    {
        public int UserId { get; set; } // Auto-incremented in SQL

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; } // Admin, Professor, Student

        public bool IsActive { get; set; } = false; // true = 1, false = 0
    }
}
