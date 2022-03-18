using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    public interface IEvaluable
    {
        void AddGrade(string input);
        Statistics GetStatistic();
        event GradeAddedDelegate GradeAdded;
    }
}