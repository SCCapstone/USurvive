using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using System.Collections.ObjectModel;
using USurvive;

namespace USurviveTests
{
    [TestClass]
    public class UnitTest1
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
                Syllabus syllabus = null;
                int classType = 0;
                string notes = "notes";
                ObservableCollection<MeetingTime> meetingTimes = null;
                GradeScale gradeScale = new GradeScale(7, 0);

                //USurvive.Assignment assignment = new USurvive.Assignment(name, new USurvive.Class("Class name", null, 0, null, null, null, 0, "", null), new DateTime(), new DateTime(), 0, null, false, 0);
                Class UClass = new Class(name, instructor, creditHours, instructorEmail,classWebsite, syllabus, classType, notes, meetingTimes, gradeScale);

                Assert.IsTrue(UClass.Name.Equals(name));
            }
        }
    }
}
