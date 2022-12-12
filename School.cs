using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectionBaseCSharp
{
    public class School
    {
        public Dictionary<int, Promotion[]> promotions = new Dictionary<int, Promotion[]>
        {
            { 0, new Promotion[]{ new Promotion(3, "Promotion_0_0"), new Promotion(3, "Promotion_0_1"), new Promotion(3, "Promotion_0_2") } },
            { 1, new Promotion[]{ new Promotion(3, "Promotion_1_0"), new Promotion(3, "Promotion_1_1"), new Promotion(3, "Promotion_1_2") } },
            { 2, new Promotion[]{ new Promotion(3, "Promotion_2_0"), new Promotion(3, "Promotion_2_1"), new Promotion(3, "Promotion_2_2") } },
            { 3, new Promotion[]{ new Promotion(3, "Promotion_3_0"), new Promotion(3, "Promotion_3_1"), new Promotion(3, "Promotion_3_2") } },
            { 4, new Promotion[]{ new Promotion(3, "Promotion_4_0"), new Promotion(3, "Promotion_4_1"), new Promotion(3, "Promotion_4_2") } },
            { 5, new Promotion[]{ new Promotion(3, "Promotion_5_0"), new Promotion(3, "Promotion_5_1"), new Promotion(3, "Promotion_5_2") } },
            { 6, new Promotion[]{ new Promotion(3, "Promotion_6_0"), new Promotion(3, "Promotion_6_1"), new Promotion(3, "Promotion_6_2") } },
        };

        public School()
        {
            FillSchool();
        }

        public void PromotionManagement()
        {
            Dictionary<int, HashSet<Student>> promotedStudentsByLevel = new Dictionary<int,HashSet<Student>>();

            //parcourir mes classes
            for(int level = 0; level < 7; level++)
            {
                Promotion[] currentLevel = promotions[level];
                promotedStudentsByLevel.Add(level, new HashSet<Student>());
                //stocker les élèves promu par niveau
                foreach (Promotion promotion in currentLevel)
                {
                    promotedStudentsByLevel[level].UnionWith(promotion.PromoteStudents());
                }
            }
            //détecter la meilleur moyenne dans chaque niveau et décerner à l'élève une récompense
            GiveAReward(promotedStudentsByLevel);
            //Par niveau, attribuer les élèves en fonction des places disponibles
            DispatchStudents(promotedStudentsByLevel);
            //libérer les élèves qui n'ont pas de place
            ReleaseOtherStudents(promotedStudentsByLevel);
        }

        public void GiveAReward(Dictionary<int, HashSet<Student>> students)
        {
            for (int level = 0; level < 7; level++)
            {
                HashSet<Student> currentLevelStudents = students[level];
                if (currentLevelStudents.Count == 0)
                {
                    return;
                }
                Student toReward = currentLevelStudents.OrderByDescending(x => x.globalScore).First();
                Console.WriteLine("{0} {1} est major du niveau {2} avec {3} de moyenne.", toReward.firstName, toReward.lastName, level, toReward.globalScore);
            }
        }

        public void DispatchStudents(Dictionary<int, HashSet<Student>> students)
        {
            for (int level = 0; level < 7; level++)
            {
                //passage classe supérieure
                if (level < 6) 
                {
                    HashSet<Student> toDispatch = students[level];
                    int promotionIndex = 0;
                    while (toDispatch.Count > 0 && promotionIndex < promotions[level+1].Length)
                    {
                        Promotion currentPromotion = promotions[level+1][promotionIndex];
                        if (currentPromotion.studentsMaxNumber > currentPromotion.students.Count)
                        {
                            Student student = toDispatch.First();
                            currentPromotion.RegisterStudent(student);
                            toDispatch.Remove(student);
                            Console.WriteLine("{0} {1} est passé en classe {2}", student.firstName, student.lastName, currentPromotion.promotionName);
                        }
                        else
                        {
                            promotionIndex++;
                        }
                    }
                }
                //diplome
                else
                {
                    HashSet<Student> toReward = students[level];
                    foreach (Student student in toReward)
                    {
                        Console.WriteLine("{0} {1} est diplomé {2}", student.firstName, student.lastName, level);
                    }
                    students[level].Clear();
                }
            }
        }

        public void ReleaseOtherStudents(Dictionary<int, HashSet<Student>> students)
        {
            for (int level = 0; level <= 6; level++)
            {
                HashSet<Student> currentLevelStudents = students[level];
                foreach (Student student in currentLevelStudents)
                {
                    Console.WriteLine("{0} {1} est invité à se trouver une nouvelle école.", student.firstName, student.lastName);
                }
            }
        }

        public void FillSchool()
        {
            //parcourir mes classes
            for (int level = 0; level <= 6; level++)
            {
                RegisterNewStudents(level, 1);
            }
        }

        public void RegisterNewStudents(int level, int number)
        {
            //parcourir mes classes
            Promotion[] currentLevel = promotions[level];
            for (int j = 0; j < currentLevel.Length; j++)
            {
                Promotion promotion = currentLevel[j];
                for (int i = 0; i < number; i++)
                {
                    Student student = Program.CreateRandomStudent((level + 1) + (j + 1) * 2 + i * 3);
                    promotion.RegisterStudent(student);
                    if (level == 0)
                    {
                        Console.WriteLine("{0} {1} est un nouvel élève de l'école.", student.firstName, student.lastName);
                    }
                }
            }
        }
    }
}
