using System.Collections.Generic;

namespace ChallengeApp
{
    public abstract class UniversityFrequenter : Person, IEvaluable
    {
        public UniversityFrequenter(string name)
        {
        }
        public UniversityFrequenter(string name, string sex)
        {
        }
        public event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(string input);
        public abstract void AddGrades(List<double> gradeList);
        public abstract Statistics GetStatistic();
    }
}