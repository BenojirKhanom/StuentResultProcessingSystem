using System.ComponentModel.DataAnnotations;

namespace StudentResultProcessingSystem.Data
{
    public class Subject
    {
        // Primary Key
        [Key]
        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }
    }
}
