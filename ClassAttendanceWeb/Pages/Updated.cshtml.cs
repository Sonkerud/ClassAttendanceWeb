using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassAttendanceWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentData;

namespace ClassAttendanceWeb.Pages
{
    public class UpdatedModel : PageModel
    {
        public JsonFileStudentService StudentService { get; set; }
        public IEnumerable<Student> Students { get; set; }

        public UpdatedModel(JsonFileStudentService studentService)
        {
            StudentService = studentService;
        }

        public void OnGet()
        {
            //Students = InMemoryStudentData.students;
            
            //Med api
            Students = StudentService.GetStudents().Where(x => x.Attending == true);
            
        }
    }
}