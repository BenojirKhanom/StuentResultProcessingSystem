using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentResultProcessingSystem.Data
{
    public class Result
    {
        // Primary Key
        [Key]
        public int ResultId { get; set; }

        // Foreign Key
        public int? StudentId { get; set; }
        public Student? Student { get; set; }

       
        // Calculated Fields
        public decimal? TotalMarks { get; set; }

        public decimal? AverageMarks { get; set; }

        public string? Grade { get; set; }

        public string? Status { get; set; }

      
    }
}
