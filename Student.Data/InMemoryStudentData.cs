using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentData
{
    public class InMemoryStudentData : IStudentData
    {
        public static List<Student> students { get; set; }
        
        public InMemoryStudentData()
        {
            students = new List<Student>
         {
             new Student {Id=1, Name = "Alexander Sonerud", Attending = true},
             new Student {Id=2, Name = "Viktor Hörwing", Attending = true},
             new Student {Id=3, Name = "Samuel Lindberg", Attending = true}

         };   
        }

        public IEnumerable<Student> GetStudentListByName()
        {
            return students.OrderBy(x => x.Name).Select(x => x);
        }
    }
}
