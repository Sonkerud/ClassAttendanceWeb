using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassAttendanceWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentData;

namespace ClassAttendanceWeb.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public JsonFileStudentService StudentService { get;}

        public StudentsController(JsonFileStudentService studentService)
        {
            this.StudentService = studentService;
        }
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return StudentService.GetStudents();
        }
        [Route("Attend")]
        [HttpGet]
        public ActionResult Get([FromQuery]int id,[FromQuery] bool status)
        {
            StudentService.ChangeAttendingStatus(id, status);
            return Ok();
        }
    }
}