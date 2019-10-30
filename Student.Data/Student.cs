using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudentData
{
    public class Student
    {
        public int Id { get; set; }
        public string Name  { get; set; }
        public bool Attending { get; set; } 

        public override string ToString() => JsonSerializer.Serialize(this);

    }

    
}
