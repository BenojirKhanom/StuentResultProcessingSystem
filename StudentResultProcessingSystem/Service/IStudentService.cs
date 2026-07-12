using StudentResultProcessingSystem.Data;

namespace StudentResultProcessingSystem.Service
{
    public interface IStudentService
    {
        #region Student
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student?> GetStudentById(int id);
        Task<int> SaveStudent(Student Student);
        Task<int> DeleteStudent(int id);

        #endregion

        #region Result
        Task<IEnumerable<Result>> GetAllResults();
        Task<Result?> GetResultById(int id);
        Task<int> SaveResult(Result Result);
        Task<int> DeleteResult(int id);


        // Subject
        Task<IEnumerable<Subject>> GetSubjects();
        // Result Detail
        Task<int> SaveResultDetail(ResultDetail model);


        #endregion
        #region Department
        Task<IEnumerable<Department>> GetDepartments();
        #endregion
    }
}
