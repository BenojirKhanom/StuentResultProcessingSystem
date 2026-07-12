using System.ComponentModel.DataAnnotations;

namespace StudentResultProcessingSystem.Data
{
    public class Department
    {
        // Primary Key
        [Key]
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
    }
}
