using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectionBaseCSharp
{
    public class Promotion
    {
        public HashSet<Student> students = new HashSet<Student>();
        public string promotionName;
        public int studentsMaxNumber = 3;
        
        public Promotion(int studentsMaxNumber, string promotionName)
        {
            this.promotionName = promotionName;
            this.studentsMaxNumber = studentsMaxNumber;
        }

        public HashSet<Student> PromoteStudents()
        {
            HashSet<Student> promotedStudents = new HashSet<Student>();
            foreach (Student student in students)
            {
                if (student.globalScore >= 10)
                {
                    promotedStudents.Add(student);
                    Console.WriteLine("{0} {1} réussi en classe {2} avec {3} de moyenne.", student.firstName, student.lastName, promotionName, student.globalScore);
                }
                else
                {
                    Console.WriteLine("{0} {1} redouble en classe {2} avec {3} de moyenne.", student.firstName, student.lastName, promotionName, student.globalScore);
                }
            }
            foreach (Student student in promotedStudents)
            {
                students.Remove(student);
            }

            return promotedStudents;
        }

        public void RegisterStudent(Student student)
        {
            students.Add(student);
            student.GetRandomScores();
            student.CalculateGlobalScore();
        }
    }
}
