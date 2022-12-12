using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectionBaseCSharp
{
    public class Student
    {
        public string firstName;
        public string lastName;
        public DateTime birthdate;
        public float globalScore;
        public int[] scores = new int[5];
        Random random = null;
        int currentSeed = 0;
        bool initialized = false;

        public Student(string firstName, string lastName, DateTime birthdate)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthdate = birthdate;
            GetRandomScores();
            CalculateGlobalScore();
        }

        public void GetRandomScores()
        {
            if (!initialized)
            {
                currentSeed = Program.NameToInt(firstName + lastName);
                random = new Random(currentSeed);
            }
            else
            {
                currentSeed++;
                random = new Random(currentSeed);
            }
            for (int i = 0; i < scores.Length; i++)
            {
                scores[i] = random.Next(0,21);
            }
        }

        public void CalculateGlobalScore()
        {
            int result = 0;
            foreach (int score in scores)
            {
                result += score;
            }
            globalScore = result / 5f;
        }
    }
}
