using Microsoft.VisualStudio.TestTools.UnitTesting;
using USurvive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace USurviveTests
{
    [TestClass()]
    public class GlobalListsTests
    {
        string name = "testCW";
        DateTime? dueDate = DateTime.Now;
        int priority = 1;
        bool? autoInc = false;
        int autoIncDays = 1;
        ClassworkType type = ClassworkType.Assignment;
        DateTime? notifTime = DateTime.Now;
        
        /// <summary>
        /// Ensure that when classwork is deleted it's associated grade is also deleted.
        /// </summary>
        [TestMethod()]
        public void DeleteClassworkAndGradeTest()
        {
            string name = "className";
            string instructor = "class instructor";
            int creditHours = 3;
            Uri email = new Uri("mailto:a@a.com");
            Uri website = new Uri("https://www.sc.edu");
            Syllabus syllabus = null;
            int classType = 1;
            string notes = "These are some notes for the class";
            ObservableCollection<MeetingTime> meetingTimes = new ObservableCollection<USurvive.MeetingTime>();
            GradeScale gradeScale = null; //We don't use this
            Class tempClass = new Class(name, instructor, creditHours, email, website, syllabus, classType, notes, meetingTimes, gradeScale);
            string cl = tempClass.Name;
            Globals.cwList = new ClassworkList();
            Globals.gradebook = new GradeList();
            Globals.clList = new ClassList();
            Globals.clList.AddClass(tempClass);
            Grade tempGrade = new Grade(cl, dueDate);
            Classwork tempClasswork = new Classwork(
                    name, cl, dueDate, priority, tempGrade.gradeID, (bool)autoInc, autoIncDays, type, notifTime);
            Globals.gradebook.AddGrade(tempGrade);
            Globals.cwList.AddClasswork(tempClasswork);
            Assert.IsTrue(Globals.gradebook.grades.Contains(tempGrade));
            Assert.IsTrue(Globals.cwList.classwork.Contains(tempClasswork));
            Globals.cwList.DeleteClasswork(tempClasswork);
            Assert.IsFalse(Globals.gradebook.grades.Contains(tempGrade));
            Assert.IsFalse(Globals.cwList.classwork.Contains(tempClasswork));
        }
    }
}