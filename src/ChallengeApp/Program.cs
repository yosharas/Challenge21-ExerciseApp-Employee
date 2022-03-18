using System;
using System.Collections.Generic;   // dodać aby móc używać LIST

namespace ChallengeApp
{

    class Program
    {
        static void Main(string[] args)
        {
            var studenttofile = new StudentSavedToFile("Joachim");
            studenttofile.SetFileName();
            studenttofile.GradeAdded += StudentSavedToFile.OnGradeAdded; // dodanie delegatu, który wywołuje event

            EnterGrade(studenttofile);
            // studenttofile.GetStatistic();
            var stat = studenttofile.GetStatistic();
        }

        private static void EnterGrade(StudentSavedToFile studenttofile)
        {
            while (true)
            {
                Console.WriteLine($"Please enter grade {studenttofile.Name}");
                var input = Console.ReadLine();
                // var input = "3";
                if (input.Equals("q"))
                {
                    Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                    break;
                }
                try
                {
                    studenttofile.AddGrade(input);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                }
            }
        }
        // ExerciseWithMethodExtraction();

        // // private static void ExerciseWithMethodExtraction()
        // {
        //     Console.WriteLine($"=================\n wersja z tablicami \n=================");

        //     string[] names = new string[] { "Anna", "Jan", "Marek", "Jarek", "Joanna", "January", "Mikołaj", "Ada", "Ewa", "Jakub" };
        //     int[] age = new int[] { 22, 34, 44, 11, 24, 25, 35, 31, 77, 45 };
        //     for (int i = 0; i < names.Length; i++)
        //     {
        //         Console.WriteLine($"{names[i]}  {age[i]}");
        //     }

        //     Console.WriteLine($"=================\n wersja z listami \n=================");

        //     List<string> lnames = new List<string>() { "Anna", "Jan", "Marek", "Jarek", "Joanna", "January", "Mikołaj", "Ada", "Ewa", "Jakub" };
        //     List<int> lage = new List<int>() { 22, 34, 44, 11, 24, 25, 35, 31, 77, 45 };
        //     for (int i = 0; i < lnames.Count; i++)
        //     {
        //         Console.WriteLine($"{lnames[i]}  {lage[i]}");
        //     }
        // }
    }
}