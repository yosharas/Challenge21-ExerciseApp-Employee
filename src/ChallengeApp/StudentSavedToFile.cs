using System;
using System.Collections.Generic;
using System.IO;

namespace ChallengeApp
{
    public class StudentSavedToFile : StudentBase
    {
        public StudentSavedToFile(string name) : base(name)
        {
        }
        public StudentSavedToFile(string name, string sex) : base(name, sex)
        {
        }

        private string filename { get; set; }

        public void SetFileName()
        {
            this.filename = $"{Name}_StudentSavedToFile.txt";
        }


        public override event GradeAddedDelegate GradeAdded;
        public override void AddGrade(string input)
        {
            using (var writer = File.AppendText($"{filename}"))
            {
                if (double.TryParse(input, out var grade))
                {
                    if (grade >= 1 && grade <= 6)
                    {
                        writer.WriteLine(grade);
                        if (GradeAdded != null)
                        {
                            GradeAdded(this, new EventArgs());
                        }
                        this.Grades.Add(grade);
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
                    writer.WriteLine(grade);
                    this.Grades.Add(grade);
                    if (GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }
                }
            }
        }
        public static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine($"Grade has been added.");
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