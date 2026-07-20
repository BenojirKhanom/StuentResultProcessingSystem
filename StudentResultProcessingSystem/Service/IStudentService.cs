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
        
        Task<Result?> GetResultById(int id);
        Task<int> SaveResult(Result Result);
        Task<int> DeleteResult(int id);


        // Subject
        Task<IEnumerable<Subject>> GetSubjects();
        // Result Detail
        Task<int> SaveResultDetail(ResultDetail model);
        Task<IEnumerable<Result>> GetAllResults();
        Task<List<ResultDetail>> GetResultDetails(int resultId);

        #endregion
        #region Department
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartmentById(int id);
        Task<int> SaveDepartment(Department department);
        Task<int> DeleteDepartment(int id);
        #endregion
    }
}
