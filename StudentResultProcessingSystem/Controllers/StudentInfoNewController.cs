using Microsoft.AspNetCore.Mvc;
using StudentResultProcessingSystem.Models;
using StudentResultProcessingSystem.Service;

namespace StudentResultProcessingSystem.Controllers
{
    public class StudentInfoNewController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentInfoNewController(IStudentService studentService)
        {
            _studentService = studentService;
        }



        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            var vm = new StudentViewModel
            {
                students = await _studentService.GetAllStudents(),
                departments = await _studentService.GetDepartments()
            };

            if (id > 0)
            {
                var data = await _studentService.GetStudentById(id.Value);

                if (data != null)
                {
                    vm.Id = data.StudentId;
                    vm.StudentName = data.StudentName;
                    vm.departmentId = data.DepartmentId;
                }
            }

            return View(vm);
        }
    }
}
