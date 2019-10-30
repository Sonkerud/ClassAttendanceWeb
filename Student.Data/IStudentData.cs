using System;
using System.Collections.Generic;
using System.Text;

namespace StudentData
{
    interface IStudentData
    {

        IEnumerable<Student> GetStudentListByName();
    }
}
