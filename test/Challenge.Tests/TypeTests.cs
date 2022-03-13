using System;
using Xunit;
using ChallengeApp;
using System.Collections.Generic;

namespace Challenge.Tests
{
    public class TypeTests
    {
        [Fact]
        public void GetEmployeeReturnsDiffrentObjects()
        {
            //arrange          
            var emp1 = GetEmployee("Adam");
            var emp2 = GetEmployee("Tomek");
            //assert
            Assert.NotSame(emp1, emp2);
            Assert.False(Object.ReferenceEquals(emp1, emp2));

        }
        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            //arrange
            var emp1 = GetEmployee("Anna");
            var emp2 = emp1;

            //assert
            Assert.Same(emp1, emp2);
            Assert.True(Object.ReferenceEquals(emp1, emp2));
            Assert.True(emp1.Equals(emp2));
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            //arrange
            var emp1 = GetEmployee("Anna");
            //act
            this.SetName(emp1, "Ewa");
            //asert
            Assert.Equal("Ewa", emp1.Name);
        }

        [Fact]
        public void TestAddGradeFromString()
        {
            //arrange            
            var emp1 = GetEmployee("Anna");
            //act            
            emp1.AddGrade("  2020  ");
            //asert
            Assert.Equal(2020.0, emp1.Grades[0]);
        }
        private Employee GetEmployee(string name)
        {
            return new Employee(name);
        }

        private void SetName(Employee employee, string name)
        {
            employee.Name = name;
        }
    }
}
