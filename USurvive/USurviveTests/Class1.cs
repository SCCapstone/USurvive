using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using System.Collections.Generic;
using USurvive;

namespace USurviveTests
{
    [TestClass]
    public class Class1
    {
        [TestMethod]
        public void TestAssignment()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                string name = "Name";
                string instructor = "Inst";
                int creditHours = 5;
                Uri instructorEmail = null;
                Uri classWebsite = null;
                USurvive.Syllabus syllabus = null;
                int classType = 0;
                string notes = "notes";
                List<MeetingTime> meetingTimes = null;

                USurvive.Assignment assignment = new USurvive.Assignment(name, new USurvive.Class("Class name", null, 0, null, null, null, 0, "", null), new DateTime(), new DateTime(), 0, null, false, 0);
                //USurvive.Class UClass = new USurvive.Class(name, instructor, creditHours, instructorEmail, classWebsite, syllabus, classType, notes, meetingTimes);

                Assert.IsTrue(assignment.name.Equals(name));
            }
        }
    }
}
