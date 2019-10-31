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
    public class StudentlistModel : PageModel
    {
        public JsonFileStudentService StudentService { get; set; }
        public IEnumerable<Student> Students { get; set; }
        //private readonly InMemoryStudentData studentData = new InMemoryStudentData();

        public StudentlistModel(JsonFileStudentService studentService)
        {
            StudentService = studentService;

        }

        public void OnGet()
        {
            ///Students = studentData.GetStudentListByName();

            //Med API
            Students = StudentService.GetStudents();
        }
        //public void OnPost()
        //{
        //    var varor = Students;

          
        //}
    }
}