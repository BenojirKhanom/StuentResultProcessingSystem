using System.ComponentModel.DataAnnotations;

namespace StudentResultProcessingSystem.Data
{
    public class Department
    {
        // Primary Key
        [Key]
        public int DepartmentId { get; set; }
        //DataAnnotations
        [Required(ErrorMessage = "Department Name is required")]
        [StringLength(100)]
        public string? DepartmentName { get; set; }
    }
}
