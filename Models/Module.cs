using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class Module
    {
        public int ModuleId { get; set; } // Auto-incremented in SQL

        [Required]
        public string Name { get; set; }

        public string Content { get; set; }

        public int CourseId { get; set; } // Foreign key

        public virtual Course Course { get; set; } // Navigation property
    }
}
