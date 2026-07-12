using Microsoft.AspNetCore.Mvc;
using StudentResultProcessingSystem.Data;
using StudentResultProcessingSystem.Models;
using StudentResultProcessingSystem.Service;

namespace StudentResultProcessingSystem.Controllers
{
    public class StudentInfoController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentInfoController(IStudentService studentService)
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
                    vm.Roll = data.Roll;
                    vm.Email = data.Email;
                    vm.departmentId = data.DepartmentId;
                }
            }

            return View(vm);
        }




        [HttpPost]

        public async Task<IActionResult> Index(StudentViewModel vm)
        {


            var student = new Student
            {
                StudentId = vm.Id ?? 0,
                StudentName = vm.StudentName,
                DepartmentId = (int)vm.departmentId,
                Roll = vm.Roll,
                Email = vm.Email
            };

            await _studentService.SaveStudent(student);

            return RedirectToAction("Index");
        }


        [HttpPost]

        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentService.GetStudentById(id);

            if (student == null)
            {
                return NotFound();
            }

            await _studentService.DeleteStudent(id);

            return RedirectToAction("Index");
        }


        #region part 4
        public async Task<IActionResult> ResultEntry()
        {
            ResultViewModel vm = new ResultViewModel();

            vm.Students = await _studentService.GetAllStudents();
            vm.ResultList = await _studentService.GetAllResults();
            var subjects = await _studentService.GetSubjects();

            foreach (var item in subjects)
            {
                vm.Subjects.Add(new ResultDetailViewModel
                {
                    SubjectId = item.SubjectId,
                    SubjectName = item.SubjectName
                });
            }

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult>ResultEntry(ResultViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Students = await _studentService.GetAllStudents();
                vm.ResultList = await _studentService.GetAllResults();
                return View(vm);
            }

            // Save Result

            Result result = new Result();

            result.StudentId = vm.StudentId;

            result.TotalMarks = vm.TotalMarks;

            result.AverageMarks = vm.AverageMarks;

            result.Grade = vm.Grade;

            result.Status = vm.Status;

            int resultId = await _studentService.SaveResult(result);

            // Save Subject Wise Marks

            foreach (var item in vm.Subjects)
            {
                ResultDetail detail = new ResultDetail();

                detail.ResultId = resultId;

                detail.SubjectId = item.SubjectId;

                detail.Marks = item.Marks;

                await _studentService.SaveResultDetail(detail);
            }

            return RedirectToAction("ResultEntry");
        }
        //API
        [HttpGet]
        public async Task<IActionResult> GetResultDetails(int id)
        {
            var data = await _studentService.GetResultDetails(id);

            return Json(data);
        }
        #endregion

        #region part 7+8
        [HttpGet]
        public async Task<IActionResult> StudentReport(string? filterType,string? filterValue,int? departmentId)
        {
            StudentReportViewModel vm = new StudentReportViewModel();

            // Department Dropdown
            vm.Departments = await _studentService.GetDepartments();

            // Result List
            var data = await _studentService.GetAllResults();

            // Save Selected Value
            vm.FilterType = filterType;
            vm.FilterValue = filterValue;
            vm.DepartmentId = departmentId;

            if (!string.IsNullOrEmpty(filterType))
            {
                switch (filterType)
                {
                    // ==========================
                    // Search Student ID
                    // ==========================

                    case "StudentId":

                        if (!string.IsNullOrEmpty(filterValue))
                        {
                            data = data.Where(x =>
                                x.StudentId.ToString().Contains(filterValue));
                        }

                        break;

                    // ==========================
                    // Search Student Name
                    // ==========================

                    case "StudentName":

                        if (!string.IsNullOrEmpty(filterValue))
                        {
                            data = data.Where(x =>
                                x.Student!.StudentName!
                                .Contains(filterValue));
                        }

                        break;

                    // ==========================
                    // Department Filter
                    // ==========================

                    case "Department":

                        if (departmentId > 0)
                        {
                            data = data.Where(x =>
                                x.Student!.DepartmentId == departmentId);
                        }

                        break;

                    // ==========================
                    // Grade Filter
                    // Method Syntax
                    // ==========================

                    case "Grade":

                        if (!string.IsNullOrEmpty(filterValue))
                        {
                            data = data.Where(x =>
                                x.Grade == filterValue);
                        }

                        break;

                    // ==========================
                    // Status Filter
                    // Query Syntax
                    // ==========================

                    case "Status":

                        if (!string.IsNullOrEmpty(filterValue))
                        {
                            data =
                                from r in data
                                where r.Status == filterValue
                                select r;
                        }

                        break;

                    // ==========================
                    // Order By Total Marks
                    // ==========================

                    case "OrderByMarks":

                        data = data.OrderByDescending(x => x.TotalMarks);

                        break;

                    // ==========================
                    // Top Performing Student
                    // ==========================

                    case "TopStudent":

                        data = data
                            .OrderByDescending(x => x.TotalMarks)
                            .Take(1);

                        break;
                }
            }

            vm.Results = data;

            return View(vm);
        }
        #endregion

    }
}
