using StudentResultProcessingSystem.Data;

namespace StudentResultProcessingSystem.Models
{
    public class StudentViewModel
    {
        public int? Id { get; set; }
        public string? StudentName { get; set; }
        public string? Roll { get; set; }
        public string? Email { get; set; }
        public int? departmentId { get; set; }
        // Initialize with empty collection
        public IEnumerable<Student> students { get; set; } 

        public IEnumerable<Department> departments { get; set; }
    }

    public class ResultViewModel
    {
        public int? ResultId { get; set; }

        public int StudentId { get; set; }

        public IEnumerable<Student>? Students { get; set; }

        public List<ResultDetailViewModel> Subjects { get; set; } = new();
        public IEnumerable<Result> ResultList { get; set; } = new List<Result>();
        // Calculated Result

        public decimal TotalMarks { get; set; }

        public decimal AverageMarks { get; set; }

        public string? Grade { get; set; }

        public string? Status { get; set; }
    }

    public class ResultDetailViewModel
    {
        public int SubjectId { get; set; }

        public string? SubjectName { get; set; }

        public decimal Marks { get; set; }
    }
}
