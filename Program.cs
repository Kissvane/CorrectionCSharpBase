using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;

namespace CorrectionBaseCSharp
{
    enum FireState { GREEN, ORANGE, RED };
    class Program
    {
        static void Main(string[] args)
        {
            Exercice28();
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

            Add(value1, value2);
            Divide(value1, value2);
        }

        static void Add(int f1, int f2)
        {
           Console.WriteLine($"{f1} + {f2} = {f1+f2}");
        }

        static void Divide(int f1, int f2)
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

            Add(value1, value2);

            if (value2 == 0)
            {
                Console.WriteLine("Tentative de division par 0");
                Console.WriteLine("restarting the program...");
                Exercice5_v2();
                return;
            }

            Divide(value1, value2);
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

        static void Exercice7()
        {
            Console.WriteLine("Température de l'eau ?");
            int temperature = int.Parse(Console.ReadLine());
            if (temperature <= 0)
            {
                Console.WriteLine("ETAT SOLIDE");
            }
            else if (temperature <100)
            {
                Console.WriteLine("ETAT LIQUIDE");
            }
            else
            {
                Console.WriteLine("ETAT GAZEUX");
            }
        }

        static void Exercice8()
        {
            Console.WriteLine("Rentrez le premier nombre");
            int value1 = 0;
            int value2 = 0;
            try
            {
                value1 = int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("Vous ne devez taper que des chiffres.");
                Exercice8();
                return;
            }
            Console.WriteLine("Rentrez le second nombre");
            try
            {
                value2 = int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("Vous ne devez taper que des chiffres.");
                Exercice8();
                return;
            }

            Add_ManageException(value1, value2);
            Divide_ManageException(value1, value2);
        }

        //version plus optimisée
        static void Exercice8_v2()
        {
            int? value1 = null;
            int? value2 = null;
            while (!value1.HasValue)
            {
                Console.WriteLine("Rentrez le premier nombre");
                bool canParse = int.TryParse(Console.ReadLine(), out int temp);
                if (canParse)
                {
                    value1 = temp;
                }
                else
                {
                    Console.WriteLine("Vous ne devez taper que des chiffres.");
                }
            }

            while (!value2.HasValue)
            {
                Console.WriteLine("Rentrez le premier nombre");
                bool canParse = int.TryParse(Console.ReadLine(), out int temp);
                if (canParse)
                {
                    value2 = temp;
                }
                else
                {
                    Console.WriteLine("Vous ne devez taper que des chiffres.");
                }
            }

            Add_ManageException(value1.Value, value2.Value);
            Divide_ManageException(value1.Value, value2.Value);
        }

        static void Add_ManageException(int f1, int f2)
        {
            Console.WriteLine($"{f1} + {f2} = {f1 + f2}");
        }

        static void Divide_ManageException(int f1, int f2)
        {
            try
            {
                Console.WriteLine($"{f1} / {f2} = {f1 / f2} reste {f1 % f2}");
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine("Diviser par 0 est impossible.");
            }
        }

        static void Exercice9()
        {
            int value1 = WaitForGoodIntInput("Rentrez le premier nombre");
            int value2 = WaitForGoodIntInput("Rentrez le second nombre");
            int value3 = WaitForGoodIntInput("Rentrez le troisième nombre");

            Random random = new Random((int)DateTime.Now.Ticks);

            int value4 = random.Next(1, 101);
            int value5 = random.Next(1, 101);
            int value6 = random.Next(1, 101);

            List<int> list = new List<int> { value1, value2, value3, value4, value5, value6 };
            list.Sort();//classer la liste
            list.Reverse();

            Console.WriteLine("-----------------------------------");

            foreach (int i in list)
            {
                Console.WriteLine(i);
            }
        }

        static int WaitForGoodIntInput(string s)
        {
            bool assigned = false;
            int result = 0;
            while (!assigned)
            {
                Console.WriteLine(s);
                bool canParse = int.TryParse(Console.ReadLine(), out result);
                if (canParse)
                {
                    assigned = true;
                }
                else
                {
                    Console.WriteLine("Vous ne devez taper que des chiffres.");
                }
            }

            return result;
        }

        static void Exercice10()
        {
            float value1 = WaitForGoodFloatInput("Rentrez le premier nombre");
            float value2 = WaitForGoodFloatInput("Rentrez le second nombre");
            float value3 = WaitForGoodFloatInput("Rentrez le troisième nombre");

            List<float> list = new List<float> { value1, value2, value3 };
            list.Sort();

            Console.WriteLine("-----------------------------------");

            foreach (float i in list)
            {
                Console.WriteLine(i);
            }
        }

        static float WaitForGoodFloatInput(string s)
        {
            bool assigned = false;
            float result = 0;
            while (!assigned)
            {
                Console.WriteLine(s);
                bool canParse = float.TryParse(Console.ReadLine(), out result);
                if (canParse)
                {
                    assigned = true;
                }
                else
                {
                    Console.WriteLine("Vous ne devez taper que des chiffres.");
                }
            }

            return result;
        }

        static float WaitForGoodFloatInputTryCatch(string s)
        {
            bool assigned = false;
            float result = 0;
            while (!assigned)
            {
                Console.WriteLine(s);
                try
                {
                    result = float.Parse(Console.ReadLine());
                }
                catch(FormatException e)
                {
                    Console.WriteLine("Vous ne devez taper que des chiffres.");
                }
            }

            return result;
        }

        static void Exercice11()
        {
            for(int i = 0; i <= 20; i++)
            {
                if (i % 2 == 0)// n'afficher que les chiffres pairs
                {
                    Console.WriteLine(i);
                }
            }
        }

        static void Exercice11_v2()
        {
            for (int i = 0; i <= 20; i = i+2)
            {
                Console.WriteLine(i);
            }
        }

        static void Exercice12()
        {
            int number = WaitForGoodIntInput("Saisir un nombre");
            int result = 0;
            for (int i = 1; i <= number; i++)
            {
                result += i;
            }

            Console.WriteLine(result);
        }

        static void Exercice13()
        {
            string result = "";
            for (int i = 30; i >= 0; i -= 3)
            {
                result += i;
                if (i != 0)
                {
                    result += " ";
                }
            }

            Console.WriteLine(result);
        }

        static void Exercice13_v2()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 30; i >= 0; i -= 3)
            {
                builder.Append(i);
                if (i != 0)
                {
                    builder.Append(" ");
                }
            }

            Console.WriteLine(builder.ToString());
        }

        static void Exercice13_v3()
        {
            for (int i = 30; i >= 0; i -= 3)
            {
                Console.Write(i);
                if (i != 0)
                {
                    Console.Write(" ");
                }
            }
        }

        static void PerformanceComparison()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Exercice13();
            sw.Stop();
            long time1 = sw.ElapsedMilliseconds;

            sw.Restart();
            Exercice13_v2();
            sw.Stop();
            long time2 = sw.ElapsedMilliseconds;
            sw.Restart();
            Exercice13_v3();
            sw.Stop();
            long time3 = sw.ElapsedMilliseconds;
            Console.WriteLine();
            Console.WriteLine("V1 : " + time1);
            Console.WriteLine("V2 : " + time2);
            Console.WriteLine("V3 : " + time3);
        }

        static void Exercice14()
        {
            int i = 2;
            Console.WriteLine(i);
            while (i <= 21)
            {
                i += 3;
                Console.WriteLine(i);
            }
        }

        static void Exercice15()
        {
            int result = 0;
            bool IsANumber = true;
            while (IsANumber)
            {
                try
                {
                    result += int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(result);
                    IsANumber = false;
                }
            }
        }

        static void Exercice15_v2()
        {
            int result = 0;
            bool IsANumber = true;
            while (IsANumber)
            {
                IsANumber = int.TryParse(Console.ReadLine(),out int parsed);
                if (IsANumber)
                    result += parsed;
            }

            Console.WriteLine(result);
        }

        static void Exercice16()
        {
            int number = WaitForGoodIntInput("Tapez un nombre");
            int divisionNumber = 0;
            while (number > 1)
            {
                number /= 2;
                Console.WriteLine(number);
                divisionNumber++;
            }
            Console.WriteLine("-------------------------");
            Console.WriteLine(divisionNumber);
        }

        static void Exercice17()
        {
            int[] myArray = new int[] {5,6,7,8,9,10,11,12,13};

            myArray[2] = 111;

            foreach (int i in myArray)
            {
                Console.WriteLine(i);
            }
        }

        static void Exercice18(int[] myArray)
        {
            for (int i = 0; i < myArray.Length; i++)//i prend les valeurs de chaque index possible dans le tableau
            {
                if(myArray[i]%2 == 0)//si la valeur dans le tableau est pair
                {
                    myArray[i] = i;//je remplace la valeur par l'index
                    Console.WriteLine(i);
                }
                else
                {
                    Console.WriteLine(myArray[i]);
                }
            }
        }

        static void Exercice19(int[] myArray1, int[] myArray2)
        {
            //creation du tableau final
            int[] result = new int[myArray1.Length+myArray2.Length];

            //calcul de la taille du plus grand tableau
            int maxArrayLength = Math.Max(myArray1.Length, myArray2.Length);
            int currentIndex = 0;
            int currentIndexInResult = 0;
            int[] continuingArray = null;
            for (int i = 0; i < maxArrayLength; i++)
            {
                //si les deux tableaux ont une taille supérieur a l'index actuel
                if (myArray1.Length > i && myArray2.Length > i) 
                {
                    result[i * 2] = myArray1[i];
                    Console.WriteLine(result[i * 2]);
                    result[(i * 2) + 1] = myArray2[i];
                    Console.WriteLine(result[(i * 2) + 1]);
                }
                //si la taille de myArray1 est inférieur à l'index actuel
                else if (myArray1.Length <= i)
                {
                    currentIndex = i;
                    currentIndexInResult = i * 2;
                    continuingArray = myArray2;
                    break;
                }
                //si la taille de myArray2 est inférieur à l'index actuel
                else
                {
                    currentIndex = i;
                    currentIndexInResult = i * 2;
                    continuingArray = myArray1;
                    break;
                }
            }

            //continuer à remplir le tableau avec la liste survivante
            if (continuingArray != null) 
            {
                for (int i = currentIndex; i < continuingArray.Length; i++)
                {
                    result[currentIndexInResult] = continuingArray[i];
                    Console.WriteLine(continuingArray[i]);
                }
            }
        }

        static void Exercice20(int[] array1, int[] array2, int index)
        {
            //array1 is null => exception
            if(array1 == null || array1.Length == 0)
            {
                Console.WriteLine("Le premier tableau ne peut être nul ou vide");
                return;
            }
            //array2 is null => return array1
            //managed in the the loop

            //if index > array1.length ou index < 0
            if(index >= array1.Length || index < 0)
            {
                Console.WriteLine("l'index ne peux pas être plus grand que la taille de array1 ou inférieur à 0");
                return;
            }

            int[] result = new int[array1.Length+array2.Length];

            for (int i = 0; i < array1.Length; i++)
            {
                if(i < index)
                {
                    result[i] = array1[i];
                    Console.WriteLine(array1[i]);
                }
                else if (i == index)
                {
                    for (int j = 0; j < array2.Length; j++)
                    {
                        result[i+j] = array2[j];
                        Console.WriteLine(array2[j]);
                    }
                    result[i + array2.Length] = array1[i];
                    Console.WriteLine(array1[i]);
                }
                else
                {
                    result[i+array2.Length] = array1[i];
                    Console.WriteLine(array1[i]);
                }
            }
        }

        static void Exercice21()
        {
            string word = Console.ReadLine().Trim();
            char[] array = new char[word.Length];
            /*int i = 0;
            foreach (char c in word)
            {
                if (!char.IsLetter(c))
                {
                    Console.WriteLine("Un mot ne peux contenir que des lettres. Arret de la fonction...");
                    return;
                }

                array[i] = c;
                i++;
            }*/

            for (int i = 0; i < word.Length; i++)
            {
                if (!char.IsLetter(word[i]))
                {
                    Console.WriteLine("Un mot ne peux contenir que des lettres. Arret de la fonction...");
                    return;
                }

                array[i] = word[i];
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                if (i != array.Length-1)
                {
                    Console.Write(".");
                }
            }

            for (int i = 0; i < array.Length/2; i++)
            {
                char p1 = array[i];
                char p2 = array[array.Length-1-i];
                char temp = p2;
                array[array.Length - 1 - i] = p1;
                array[i] = temp;
            }

            Console.WriteLine();

            foreach (char c in array)
            {
                Console.Write(c);
            }
        }

        static void Exercice22()
        {
            string toProcess = Console.ReadLine();
            toProcess = toProcess.Replace('#', '$');
            Console.WriteLine(toProcess);
        }

        static void Exercice23()
        {
            string toProcess = Console.ReadLine().Trim();

            for (int i = 0; i < toProcess.Length / 2; i++)
            {
                char p1 = toProcess[i];
                char p2 = toProcess[toProcess.Length - 1 - i];
                if(p1 != p2)
                {
                    Console.WriteLine("Ce n'est pas un palindrome");
                    return;
                }
            }

            Console.WriteLine("C'est un palindrome");
        }

        static void Exercice23_v2()
        {
            string toProcess = Console.ReadLine().Trim();
            char[] array = toProcess.ToCharArray();
            Array.Reverse(array);
            string reversed = new string(array);

            if (string.Equals(toProcess, reversed))
            {
                Console.WriteLine("C'est un palindrome");
            }
            else
            {
                Console.WriteLine("Ce n'est pas un palindrome");
            }
        }

        static void Exercice24()
        {
            List<string> names = new List<string>();
            bool userTypedANumber = false;
            while (names.Count < 6 || !userTypedANumber)
            {
                userTypedANumber = false;
                Console.WriteLine("Tapez un nom");
                string userInpt = Console.ReadLine();
                foreach (char c in userInpt)
                {
                    if (char.IsDigit(c))
                    {
                        userTypedANumber = true;
                        break;
                    }
                }
                names.Add(userInpt);
            }

            names.RemoveAt(4);
            names.RemoveAt(1);
            names.Insert(2, "Toto");
            names.Reverse();

            Console.WriteLine("-------------------------------");
            Console.WriteLine();
            foreach (string s in names)
            {
                Console.WriteLine(s);
            }
        }

        static void Exercice25()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            HashSet<int> hashset = new HashSet<int>();
            for (int i = 0; i <= 100000000; i++)
            {
                hashset.Add(i);
            }
            sw.Stop();
            Console.WriteLine($"ADD TIME HASHET : {sw.ElapsedMilliseconds}");
            sw.Restart();
            List<int> list = new List<int>();
            for (int i = 0; i <= 100000000; i++)
            {
                list.Add(i);
            }
            sw.Stop();
            Console.WriteLine($"ADD TIME LIST : {sw.ElapsedMilliseconds}");
            sw.Restart();
            bool found = hashset.Contains(90000000);
            sw.Stop();
            Console.WriteLine($"SEARCH TIME HASHSET : {sw.ElapsedMilliseconds}");
            sw.Restart();
            bool found2 = list.Contains(90000000);
            sw.Stop();
            Console.WriteLine($"SEARCH TIME LIST : {sw.ElapsedMilliseconds}");
        }

        static void Exercice26()
        {
            HashSet<int> hashset = new HashSet<int>();
            for (int i = 0; i <= 100; i++)
            {
                hashset.Add(i);
            }

            hashset.Add(0);
            for (int i = 40; i <= 50; i++)
            {
                hashset.Remove(i);
            }

            string result = "";
            foreach (int i in hashset)
            {
                result += $"{i} ";
            }
            Console.WriteLine(result);
        }

        static void Exercice27()
        {
            Dictionary<string, int> scores = new Dictionary<string, int>();
            for (int i = 0; i < 10000; i++)
            {
                scores.Add($"Player{i}", i);
            }
            
            scores.Add("Paul", 10);
            scores.Add("Simon", 0);
            scores.Add("Jules", 15);
            scores.Add("Vegeta", 9001);
            scores.Add("Marc", 56);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            scores.ContainsKey("Vegeta");
            sw.Stop();
            Console.WriteLine($"SEARCH TIME {sw.ElapsedMilliseconds}");

            Random random = new Random();

            List<string> keys = scores.Keys.ToList();

            for (int i = 0; i < 5; i++)
            {
                string randomKey = keys[random.Next(0, keys.Count)];
                keys.Remove(randomKey);
                Console.WriteLine($"{randomKey} : {scores[randomKey]}");
            }
        }

        static void Exercice28()
        {

        }

        public static DateTime GetRandomBirthdate()
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            return new DateTime(random.Next(1980, 2000), random.Next(1,12), random.Next(1,31));
        }

        public static string GetRandomString()
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            string result = "";
            int size = random.Next(1, 101);
            for (int i = 0; i < size; i++)
            {
                int myChar = random.Next(65, 90);
                int randomLower = random.Next(0, 2);
                if (randomLower == 1)
                {
                    myChar += 32;
                }
                result += (char)myChar;
            }
            return result;
        }

        static int studentNumber = 0;

        public static Student CreateRandomStudent(int seed)
        {
            Random random = new Random(seed);
            Student result = new Student("Student", studentNumber.ToString(), GetRandomBirthdate());
            studentNumber++;
            return result;
        }
    }
}
