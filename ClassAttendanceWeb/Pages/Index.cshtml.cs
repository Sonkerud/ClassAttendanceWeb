using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassAttendanceWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using StudentData;

namespace ClassAttendanceWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileStudentService StudentService;
        
        //Vill vi ha private set?
        public IEnumerable<Student> Students { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, JsonFileStudentService studentService)
        {
            _logger = logger;
            StudentService = studentService;
        }

        public void OnGet()
        {
            Students = StudentService.GetStudents();
        }
    }
}
