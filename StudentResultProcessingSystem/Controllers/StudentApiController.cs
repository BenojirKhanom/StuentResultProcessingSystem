using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentResultProcessingSystem.Data;
using StudentResultProcessingSystem.Service;

namespace StudentResultProcessingSystem.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentApiController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/StudentApi
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _studentService.GetAllStudents();

            return Ok(students);
        }

       

        // POST: api/StudentApi
        [HttpPost]
        public async Task<IActionResult> Post(Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _studentService.SaveStudent(student);

            return Ok("Student Created Successfully");
        }

        // PUT: api/StudentApi/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Student student)
        {
            if (id != student.StudentId)
                return BadRequest();

            var data = await _studentService.GetStudentById(id);

            if (data == null)
                return NotFound("Student Not Found");

            await _studentService.SaveStudent(student);

            return Ok("Student Updated Successfully");
        }

        // DELETE: api/StudentApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentService.GetStudentById(id);

            if (student == null)
                return NotFound("Student Not Found");

            await _studentService.DeleteStudent(id);

            return Ok("Student Deleted Successfully");
        }
    }
}