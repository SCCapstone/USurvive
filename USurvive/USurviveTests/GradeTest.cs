using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using System.Collections.Generic;
using USurvive;

namespace USurviveTests
{
    [TestClass]
    public class GradeTest
    {
        [TestMethod]
        public void Test()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                String aClass = "Class name";
                int aGrade = 90;
                int creditHours = 3;
                String aName = "Name";
                DateTime aDate = new DateTime(2021, 1, 31);
                int pointsEarned = 90;
                int maxPoints = 100;
                int gradeWeight = 10; 

                USurvive.Grade grade = new USurvive.Grade(aClass, aGrade, creditHours, aName, aDate, pointsEarned, maxPoints, gradeWeight);
               

                Assert.IsTrue(grade.Name.Equals(aName));
            }
        }
    }
}