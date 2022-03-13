using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    public interface IEvaluable
    {
        void AddGrade(string input);
        void AddGrades(List<double> gradeList);
        Statistics GetStatistic();
        event GradeAddedDelegate GradeAdded;
    }
}