using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace mvc.Models
{
    public class Course
    {
        public int CourseId { get; set; } // Auto-incremented in SQL

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public virtual ICollection<Module> Modules { get; set; } = new List<Module>();

    }
}
