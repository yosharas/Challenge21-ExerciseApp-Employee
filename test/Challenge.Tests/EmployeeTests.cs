using System;
using Xunit;
using ChallengeApp;
using System.Collections.Generic;

namespace Challenge.Tests
{
    public class EmployeeTests
    {
        [Fact]
        public void Test1()
        {
            //arrange
            var emp = new ChallengeApp.Employee("Stefan","M");
            emp.AddGrade("1.1");
            emp.AddGrade("2.2");
            emp.AddGrade("3.3");
            emp.AddGrades(new List<double>{1.1, 2.2, 3.3});

     
            //act
            var result = emp.GetStatistic();
            //assert
             Assert.Equal(2.2, result.Average, 1);
             Assert.Equal(3.3, result.High);

            
        }
    }
}
 