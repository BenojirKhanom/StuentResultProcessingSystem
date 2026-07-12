using System.ComponentModel.DataAnnotations;

namespace StudentResultProcessingSystem.Data
{
    public class Student
    {
        // Primary Key
        [Key]
        public int StudentId { get; set; }
      
        [Display(Name = "Department")]
        [Required(ErrorMessage = "Please select a department.")]
        public string StudentName { get; set; }
        public string? Roll { get; set; }
        public string? Email { get; set; }

        // Foreign Key
        [Display(Name = "Department")]
        [Required(ErrorMessage = "Please select a department.")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
