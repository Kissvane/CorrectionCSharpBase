using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectionBaseCSharp
{
    class Class
    {
        public string Name { get; private set; }
        public int Level { get; private set; } = 0;
        public int StudentCapacity = 20;
        public HashSet<Student> students = new HashSet<Student>();

        public Class(int Level)
        {
            Name = $"Class{Level}";

        }

        public void RegisterInClass(Student student)
        {
            students.Add(student);
        }

        public void RemoveFromClass(Student student)
        {
            students.Remove(student);
        }

        //PROMOTION
        public HashSet<Student> Promotion()
        {
            HashSet<Student> result = new HashSet<Student>();
            foreach(Student student in students)
            {
                if(student.CalculateGlobalAverage() >= 10)
                {
                    result.Add(student);
                }
            }

            return result;
        }
    }
}
