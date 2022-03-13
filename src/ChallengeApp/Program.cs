using System;
using System.Collections.Generic;   // dodać aby móc używać LIST

namespace ChallengeApp
{

    class Program
    {
        static void Main(string[] args)
        {
            var employee = new Employee("Joachim");
            Console.WriteLine(employee.Sex);
            employee.AddGrades(new List<double>() { 1.1, 2.2, 3.3 });
             
            
            var stat = employee.GetStatistic();
            
            // employee.AddGrade("   20,22  ");
            employee.AddGrade("5+");
            employee.AddGrade("6");
            
            employee.ChangeName("Marek");
            Console.WriteLine(employee.Name);
            
            
            Console.WriteLine($"=================\n wersja z tablicami \n=================");
            
            string[] names = new string[] { "Anna", "Jan", "Marek", "Jarek", "Joanna", "January", "Mikołaj", "Ada", "Ewa", "Jakub" };
            int[] age = new int[] { 22, 34, 44, 11, 24, 25, 35, 31, 77, 45 };
            for (int i = 0; i < names.Length; i++)
            {
            Console.WriteLine($"{names[i]}  {age[i]}");
            }
            
            Console.WriteLine($"=================\n wersja z listami \n=================");
            
            List<string> lnames = new List<string>() { "Anna", "Jan", "Marek", "Jarek", "Joanna", "January", "Mikołaj", "Ada", "Ewa", "Jakub" };
            List<int> lage = new List<int>() { 22, 34, 44, 11, 24, 25, 35, 31, 77, 45 };
            for (int i = 0; i < lnames.Count; i++)
            {
            Console.WriteLine($"{lnames[i]}  {lage[i]}");
            }

            employee.GradeAdded+=Employee.OnGradeAdded; // dodanie delegatu, który wywołuje event
            Console.WriteLine("podaj ocenę");
            string input = Console.ReadLine();
            employee.AddGrade(input);         
        }
    }
}