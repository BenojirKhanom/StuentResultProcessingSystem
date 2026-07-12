using System.ComponentModel.DataAnnotations;

namespace StudentResultProcessingSystem.Data
{
    public class Student
    {
        // Primary Key
        [Key]
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? Roll { get; set; }
        public string? Email { get; set; }

        // Foreign Key
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
