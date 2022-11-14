using System;

namespace CorrectionBaseCSharp
{
    enum FireState { GREEN, ORANGE, RED };
    class Program
    {
        static void Main(string[] args)
        {
            Exercice5_v2();
        }

        static void Exercice1()
        {
            Console.WriteLine("Quel est votre prénom ?");
            string prenom = Console.ReadLine();

            Console.WriteLine("Quel est votre nom ?");
            string nom = Console.ReadLine();

            Console.WriteLine($"Bonjour {prenom} {nom}");
        }

        static void Exercice2()
        {
            Console.WriteLine("Quel est votre date de naissance ? format(jj/mm/aaaa)");
            string date = Console.ReadLine();
            //DateTime datetime = DateTime.Parse(date);
            string[] splited = date.Split('/');
            DateTime birthDate = new DateTime(int.Parse(splited[2]), int.Parse(splited[1]), int.Parse(splited[0]));

            int age = DateTime.Now.Year - birthDate.Year;
            bool birthdayPassed = birthDate.Month < DateTime.Now.Month || (birthDate.Month == DateTime.Now.Month && birthDate.Day <= DateTime.Now.Day);
            if (!birthdayPassed)
            {
                age--;
            }

            Console.WriteLine($"Vous avez {age} an(s).");

            TimeSpan ts = DateTime.Now - birthDate;
            int years = (int) MathF.Floor(ts.Days / 365.25f);
            int month = (int)((ts.Days - (years * 365.25f)) / 31f);
            int day = (int)(ts.Days - (365.25f * years) - (month * 31f));
            Console.WriteLine($"année : {years} mois : {month} jour : {day}");
        }

        static void Exercice3()
        {
            Console.WriteLine("Quel est le prix du produit ?");
            int prix = int.Parse(Console.ReadLine());

            int finalPrice = (int) MathF.Round(prix * 1.2f);
            Console.WriteLine($"Le prix TTC est de {finalPrice}.");
        }

        static void Exercice3_v2()
        {
            Console.WriteLine("Quel est le prix du produit ?");
            int prix = int.Parse(Console.ReadLine());
            Console.WriteLine("Quel est le taux de TVA ?");
            float TVA = float.Parse(Console.ReadLine());
            float finalPrice = prix + (prix * TVA / 100f);
            Console.WriteLine($"Le prix TTC est de {finalPrice.ToString("#.##")}.");
        }

        static void Exercice4()
        {
            Console.WriteLine("Rentrez le premier nombre");
            int value1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Rentrez le second nombre");
            int value2 = int.Parse(Console.ReadLine());

            Addition(value1, value2);
            Division(value1, value2);
        }

        static void Addition(int f1, int f2)
        {
           Console.WriteLine($"{f1} + {f2} = {f1+f2}");
        }

        static void Division(int f1, int f2)
        {
            Console.WriteLine($"{f1} / {f2} = {f1/f2} reste {f1%f2}");
        }

        static void Exercice5()
        {
            try
            {
                Exercice4();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("restarting the program...");
                Exercice5();
            }
        }

        static void Exercice5_v2()
        {
            Console.WriteLine("Rentrez le premier nombre");
            if(!int.TryParse(Console.ReadLine(), out int value1))
            {
                Console.WriteLine("Erreur de parsing");
                Console.WriteLine("restarting the program...");
                Exercice5_v2();
                return;
            }

            Console.WriteLine("Rentrez le second nombre");
            if (!int.TryParse(Console.ReadLine(), out int value2))
            {
                Console.WriteLine("Erreur de parsing");
                Console.WriteLine("restarting the program...");
                Exercice5_v2();
                return;
            }

            Addition(value1, value2);

            if (value2 == 0)
            {
                Console.WriteLine("Tentative de division par 0");
                Console.WriteLine("restarting the program...");
                Exercice5_v2();
                return;
            }

            Division(value1, value2);
        }

        static void Exercice6()
        {
            Console.WriteLine("Quel est l'état du feu");
            // version 1
            //int current = int.Parse(Console.ReadLine());
            //int next = (current + 1) % 3/*Enum.GetValues(typeof(FireState)).Length*/;
            //Console.WriteLine((FireState)next);

            string current = Console.ReadLine().ToLower().Trim();
            switch (current)
            {
                case "green":
                    Console.WriteLine(FireState.ORANGE);
                    break;
                case "orange":
                    Console.WriteLine(FireState.RED);
                    break;
                case "red":
                    Console.WriteLine(FireState.GREEN);
                    break;
                default:
                    Console.WriteLine("Tapez coorectement la coueur du feu");
                    return;
            }
           
        }
    }
}
