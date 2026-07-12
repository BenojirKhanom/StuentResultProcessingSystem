using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentResultProcessingSystem.Data
{
    public class ResultDetail
    {
        // Primary Key
        [Key]
      
        public int ResultDetailId { get; set; }
        public decimal Marks { get; set; }
        public int ResultId { get; set; }
        public Result? Result { get; set; }
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }


    }
}
