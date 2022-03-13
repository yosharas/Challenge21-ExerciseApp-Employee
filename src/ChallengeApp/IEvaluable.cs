using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    public interface IEvaluable
    {
        void AddGrade(string input);
        void AddGrades(List<double> gradeList);
        Statistics GetStatistic();
        event GradeAddedDelegate GradeAdded;
    }
}