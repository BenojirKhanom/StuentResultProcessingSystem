using Microsoft.EntityFrameworkCore;
using StudentResultProcessingSystem.Data;

namespace StudentResultProcessingSystem.Service
{
    public class StudentService : IStudentService
    {


        private readonly ApplicationDbContext _context;
        public StudentService(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        #region Student
        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _context.Students.Include(x=>x.Department).ToListAsync();
        }

        public async Task<Student?> GetStudentById(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<int> SaveStudent(Student Student)
        {
            try
            {
                if (Student == null)
                {
                    throw new ArgumentNullException(nameof(Student));
                }
                if (Student.StudentId > 0)
                {
                    _context.Update(Student);
                }
                else
                {
                    _context.Students.Add(Student);
                }
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }

        }

        public async Task<int> DeleteStudent(int id)
        {
            var Student = await _context.Students.FindAsync(id);
            if (Student == null)
            {
                throw new ArgumentException($"Student id {id} not found.");
            }
            _context.Students.Remove(Student);
            await _context.SaveChangesAsync();
            return 1;
        }
        #endregion

        #region Result

        

        public async Task<Result?> GetResultById(int id)
        {
            return await _context.Results.FindAsync(id);
        }

        public async Task<int> SaveResult(Result Result)
        {
            if (Result == null)
            {
                throw new ArgumentNullException(nameof(Result));
            }

            if (Result.ResultId > 0)
            {
                _context.Update(Result);
            }
            else
            {
                _context.Results.Add(Result);
            }
            await _context.SaveChangesAsync();
            return Result.ResultId;
        }

        public async Task<int> DeleteResult(int id)
        {
            var Result = await _context.Results.FindAsync(id);
            if (Result == null)
            {
                throw new ArgumentException($"Result id {id} not found.");
            }
            _context.Results.Remove(Result);
            await _context.SaveChangesAsync();
            return id;
        }
        //sql query
        public async Task<IEnumerable<Subject>> GetSubjects()
        {
           // return await _context.Subjects.ToListAsync();
            return await _context.Subjects
               .FromSqlRaw("SELECT * FROM Subjects")
               .ToListAsync();
        }

        public async Task<int> SaveResultDetail(ResultDetail model)
        {
            _context.ResultDetails.Add(model);

            await _context.SaveChangesAsync();

            return model.ResultDetailId;
        }
        public async Task<IEnumerable<Result>> GetAllResults()
        {
            return await _context.Results
                 .Include(x => x.Student)
                 .Include(x => x.Student.Department)
                .OrderByDescending(x => x.ResultId)
                .ToListAsync();
        }

        public async Task<List<ResultDetail>> GetResultDetails(int resultId)
        {
            return await _context.ResultDetails
                .Include(x => x.Subject)
                .Where(x => x.ResultId == resultId)
                .ToListAsync();
        }

       
        #endregion

        #region Department
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            var data = await _context.Departments.ToListAsync();
            return data;
        }
        
        #endregion
    }
}
