using System.Collections.Generic;

namespace ChallengeApp
{
    public abstract class UniversityFrequenter : Person, IEvaluable
    {
        public UniversityFrequenter(string name)
        {
            Name = name;
        }
        public UniversityFrequenter(string name, string sex)
        {
            Name = name;
        }
        public List<double> Grades {get; set;} = new List<double>();

        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(string input);
        public abstract Statistics GetStatistic();
    }
}