using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using USurvive;
using System.Collections.ObjectModel;

namespace USurviveTests
{
    [TestClass]
    public class ClassUnitTest
    {
        string name = "className";
        string instructor = "class instructor";
        int creditHours = 3;
        Uri email = new Uri("mailto:a@a.com");
        Uri website = new Uri("https://www.sc.edu");
        USurvive.Syllabus syllabus = null;
        int classType = 1;
        string notes = "These are some notes for the class";
        ObservableCollection<USurvive.MeetingTime> meetingTimes = new ObservableCollection<USurvive.MeetingTime>();
        USurvive.GradeScale gradeScale = null;//We don't use this

        [TestInitialize]
        public void TestInitialize()
        {
            meetingTimes.Add(new USurvive.MeetingTime(new int[] { 16, 30 }, 70, new bool[] { false, true, false, true, false, true, false }));
            //new MeetingTime(null, 0, null);
            /*Meets at 4:30 PM for 70 minutes on MWF*/
        }

        [TestMethod]
        public void TestConstructor()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                USurvive.Class test = new USurvive.Class(name, instructor, creditHours, email, website, syllabus, classType, notes, meetingTimes, gradeScale);

                //Verify everything is correct
                Assert.IsTrue(test.Name.Equals(name));
                Assert.IsTrue(test.Instructor.Equals(instructor));
                Assert.IsTrue(test.CreditHours == creditHours);
                Assert.IsTrue(test.InstructorEmail.Equals(email));
                Assert.IsTrue(test.ClassWebsite.Equals(website));
                Assert.IsTrue(test.ClassType == classType);
                Assert.IsTrue(test.Notes.Equals(notes));
                Assert.IsTrue(test.MeetingTimes.Equals(meetingTimes));
                Assert.IsTrue(test.GradeScale == null);

                //MeetingTime meet = new USurvive.MeetingTime(null, 0, null);
            }
        }

        [TestMethod]
        public void TestCreditHoursTrue()
        {





            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                int creditHours = 3;
                USurvive.Class test = new USurvive.Class("name", "instructor", creditHours, null, null, null, 0,
                                                         "", null, null);

                Assert.IsTrue(test.CreditHours == creditHours);
            }
        }

        [TestMethod]
        public void TestCreditHoursFalse()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                int creditHours = 3;
                USurvive.Class test = new USurvive.Class("name", "instructor", creditHours, null, null, null, 0, "", null, null);

                Assert.IsFalse(test.CreditHours == 4);
            }
        }

        [TestMethod]
        public void TestCreditHoursNegative()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                int creditHours = -3;
                USurvive.Class test = new USurvive.Class("name", "instructor", creditHours, null, null, null, 0, "", null, null); ;

                Assert.IsTrue(test.CreditHours == creditHours);
            }
        }
    }
}
