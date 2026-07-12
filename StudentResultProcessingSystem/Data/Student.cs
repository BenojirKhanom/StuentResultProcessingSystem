using System.ComponentModel.DataAnnotations;

namespace StudentResultProcessingSystem.Data
{
    public class Student
    {
        // Primary Key
        [Key]
        public int StudentId { get; set; }

        [Display(Name = "Student Name")]
        [Required(ErrorMessage = "Student Name is required.")]
        [StringLength(100)]
        public string StudentName { get; set; }
        public string? Roll { get; set; }
        public string? Email { get; set; }

        // Foreign Key
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
