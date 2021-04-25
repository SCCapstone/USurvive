using Microsoft.VisualStudio.TestTools.UnitTesting;
using USurvive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace USurvive.Tests
{
    [TestClass()]
    public class GlobalListsTests
    {
        string name = "testCW";
        DateTime? dueDate = null;
        int priority = 1;
        bool? autoInc = false;
        int autoIncDays = 1;
        ClassworkType type = ClassworkType.Assignment;
        DateTime? notifTime = null;
        
        /// <summary>
        /// Ensure that when classwork is deleted it's associated grade is also deleted.
        /// </summary>
        [TestMethod()]
        public void DeleteClassworkAndGradeTest()
        {
            Class tempClass = new Class("testClass", "instructor", 3 , null, null, null, 1, "notes", new ObservableCollection<MeetingTime>(), null);
            string cl = tempClass.Name;
            Grade tempGrade = new Grade(cl, dueDate);
            Classwork tempClasswork = new Classwork(
                    name, cl, dueDate, priority, tempGrade.gradeID, (bool)autoInc, autoIncDays, type, notifTime);
            Globals.gradebook.AddGrade(tempGrade);
            Assert.Fail();
        }
    }
}