using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentData
{
    public class InMemoryStudentData : IStudentData
    {
        public static List<Student> students { get; set; }
        static Dictionary<int, List<string>> attendeesSortedIntoGroups = new Dictionary<int, List<string>>();
        static Random random = new Random();

        public InMemoryStudentData()
        {
            students = new List<Student>
         {
             new Student {Id=1, Name = "Alexander Sonerud", Attending = true},
             new Student {Id=2, Name = "Viktor Hörwing", Attending = true},
             new Student {Id=3, Name = "Samuel Lindberg", Attending = true},
             new Student {Id=4, Name = "Pontus Nelander", Attending = true},
             new Student {Id=5, Name = "Malin Gröön", Attending = true}
         };   
        }

        public IEnumerable<Student> GetStudentListByName()
        {
            return students.OrderBy(x => x.Name).Select(x => x);
        }

     

        static Dictionary<int, List<string>> GroupClass(List<string> list, int chunk)
        {
            var newRandomList = RandomizeAttendees(list);
            for (int i = 0; i <= list.Count / chunk; i++)
            {
                if (newRandomList.Count >= chunk)
                {
                    attendeesSortedIntoGroups.Add(i, newRandomList.Take(chunk).ToList());

                    for (int x = 0; x < chunk; x++)
                    {
                        newRandomList.RemoveAt(0);
                    }
                }
                else if (newRandomList.Count != 0)
                {
                    attendeesSortedIntoGroups.Add(i, newRandomList.Take(newRandomList.Count).ToList());
                }
            }
            return attendeesSortedIntoGroups;
        }
        static List<string> RandomizeAttendees(List<string> list)
        {
            var models = list.OrderBy(c => random.Next()).Select(c => c).ToList();
            return models;
        }

    }
}
