using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    public class StudentSavedToMemory : StudentBase
    {
        public StudentSavedToMemory(string name) : base(name)
        {
        }
        public StudentSavedToMemory(string name, string sex) : base(name, sex)
        {
        }
        public override event GradeAddedDelegate GradeAdded;
        public override void AddGrade(string input)
        {
            
            if (double.TryParse(input, out var grade))
            {
                if (grade >= 1 && grade <= 6)
                {
                    Grades.Add(grade);
                    if (grade < 3)
                    {
                        if (GradeAdded != null)
                        {
                            GradeAdded(this, new EventArgs());
                        }
                    }
                }
                else
                {
                    throw new Exception($"Podana wartość:\"{input}\" jest nieprawdłowa. Ocena musi zostać podana w formacie cyfry od 1 do 6 z opcjonalnym znakiem \"+\" lub \"-\"");
                }
            }
            else
            {
                switch (input)
                {
                    case "6+":
                        grade = 6.5;
                        break;
                    case "6-":
                        grade = 5.75;
                        break;
                    case "5+":
                        grade = 5.5;
                        break;
                    case "5-":
                        grade = 4.75;
                        break;
                    case "4+":
                        grade = 4.5;
                        break;
                    case "4-":
                        grade = 3.75;
                        break;
                    case "3+":
                        grade = 3.5;
                        break;
                    case "3-":
                        grade = 2.75;
                        break;
                    case "2+":
                        grade = 2.5;
                        break;
                    case "2-":
                        grade = 1.75;
                        break;
                    case "1+":
                        grade = 1.5;
                        break;
                    case "1-":
                        grade = 0.75;
                        break;
                    default:
                        throw new Exception($"Podana wartość:\"{input}\" jest nieprawdłowa. Ocena musi zostać podana w formacie cyfry od 1 do 6 z opcjonalnym znakiem \"+\" lub \"-\"");
                }
                if (grade < 3)
                {
                    if (GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }
                }
                Grades.Add(grade);
            }
            Console.WriteLine($"Dodano wartość {grade}");
        }
        public static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine("Oh no! We should inform students' parents about this fact");
        }
        public override Statistics GetStatistic()
        {
            var result = new Statistics();

            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach (var grade in Grades)
            {
                result.Low = Math.Min(result.Low, grade);
                result.High = Math.Max(result.High, grade);
                result.Average += grade;
            }
            result.Average /= Grades.Count;

            Console.WriteLine("Najniższa ocena to " + result.Low.ToString("N2"));
            Console.WriteLine("Najwyższa ocena to " + result.High.ToString("N2"));
            Console.WriteLine("Średnia ocen to " + result.Average.ToString("N2"));

            return result;
        }
    }
}