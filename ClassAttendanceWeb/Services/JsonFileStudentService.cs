using Microsoft.AspNetCore.Hosting;
using StudentData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClassAttendanceWeb.Services
{
    public class JsonFileStudentService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }

        public JsonFileStudentService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public string JsonFileName {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "students.json"); } 
        }

        public IEnumerable<Student> GetStudents()
        {
            StreamReader reader = new StreamReader(JsonFileName, System.Text.Encoding.Default, true);

            using (reader)
            {
                return JsonSerializer.Deserialize<Student[]>(reader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        public void ChangeAttendingStatus(int id, bool status)
        {
            var students = GetStudents();
            var query = students.First(x => x.Id == id);
            query.Attending = status;

            //bool attending;
            //if (status == 1)
            //{
            //    attending = true;
            //    query.Attending = attending;
            //} else if (status == 2)
            //{
            //    attending = false;
            //    query.Attending = attending;
            //}
           

            using(var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<Student>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true

                    }), students 
                 );
            }
        }
    }
}
