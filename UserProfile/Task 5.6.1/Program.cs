using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5._6._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TupleDisplay(UserProfile());
        }
        static (string, string, byte, bool, byte, string[], byte, string[]) UserProfile()
        {
            (string Name, string LastName, byte Age, bool HasPet, byte PetCount, string[] PetNames, byte CountColors, string[] FavColors) User;
            User.Name = string.Empty;
            User.LastName = string.Empty;
            User.Age = 1;
            User.HasPet = true;
            User.PetCount = 1;
            User.CountColors = 1;
            User.PetNames = new string[1];
            User.FavColors = new string[1];
            Console.WriteLine("Enter name:");
            User.Name = Console.ReadLine();

            Console.WriteLine("Enter last name:");
            User.LastName = Console.ReadLine();

            string numRequest = "Enter user age, use only numbers";
            CheckUserInput(ref User.Age, ref numRequest);

            Console.WriteLine("Do you have a pet?(Yes or no)");
            var userInput = Console.ReadLine();
            if (userInput == "yes")
            {
                User.HasPet = true;
                string numRequest2 = "How many pets you have?";
                CheckUserInput(ref User.PetCount, ref numRequest2);
                Console.WriteLine("Please input pets names");
                PetConfig(User.PetCount, ref User.PetNames);
            }
            else if (userInput == "no")
            {
                User.HasPet = false;
                User.PetCount = 0;
            }

            string numRequest3 = "Enter numbers favorite colors";

            CheckUserInput(ref User.CountColors, ref numRequest3);
            Console.WriteLine("Enter colors names");

            Colors(User.CountColors, ref User.FavColors);

            return User;

        }
        static string[] PetConfig(byte petCount, ref string[] petNames)
        {
            petNames = new string[petCount];
            for (int i = 0; i <= petCount - 1; i++)
            {
                petNames[i] = Console.ReadLine();

            }
            return petNames;

        }
        static string[] Colors(byte countColors, ref string[] favColors)
        {
            favColors = new string[countColors];
            for (int j = 0; j <= countColors - 1; j++)
            {
                favColors[j] = Console.ReadLine();
            }
            return favColors;
        }
        static void CheckUserInput(ref byte count, ref string request)
        {

            Console.WriteLine(request);
            byte.TryParse(Console.ReadLine(), out count);
            if (count <= 0)
            {
                Console.WriteLine("Invalid input, please use only numbers for input");
                CheckUserInput(ref count, ref request);
            }


        }
        static void TupleDisplay((string, string, byte, bool, byte, string[], byte, string[]) Tuple)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.WriteLine($"User information:\n Name: {Tuple.Item1}\n Last Name: {Tuple.Item2}\n Age: {Tuple.Item3}");

            if (Tuple.Item4 == true)
            {
                Console.WriteLine($" Having a pet: yes");
                Console.WriteLine($" Pets count: {Tuple.Item5}");
                Console.Write($" Pets names:");
                for (int i = 0; i < Tuple.Item6.Length; i++)
                    Console.Write(" " + Tuple.Item6[i]);
                Console.WriteLine();
            }
            else Console.WriteLine($" Having a pet: no");

            Console.WriteLine($" Count favorite colors: {Tuple.Item7}");
            Console.Write(" Favorite colors:");
            for (int j = 0; j < Tuple.Item8.Length; j++)
                Console.Write(" " + Tuple.Item8[j]);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
