using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentResultProcessingSystem.Data;
using StudentResultProcessingSystem.Service;

namespace StudentResultProcessingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public DepartmentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/Department
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var departments = await _studentService.GetDepartments();

            return Ok(departments);
        }

        // GET: api/Department/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var department = await _studentService.GetDepartmentById(id);

            if (department == null)
                return NotFound("Department Not Found");

            return Ok(department);
        }

        // POST: api/Department
        [HttpPost]
        public async Task<IActionResult> Post(Department department)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _studentService.SaveDepartment(department);

            return Ok("Department Created Successfully");
        }

        // PUT: api/Department/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Department department)
        {
            if (id != department.DepartmentId)
                return BadRequest();

            await _studentService.SaveDepartment(department);

            return Ok("Department Updated Successfully");
        }

        // DELETE: api/Department/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _studentService.GetDepartmentById(id);

            if (department == null)
                return NotFound("Department Not Found");

            await _studentService.DeleteDepartment(id);

            return Ok("Department Deleted Successfully");
        }
    }
}

