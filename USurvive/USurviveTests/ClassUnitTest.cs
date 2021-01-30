using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using USurvive;

namespace USurviveTests
{
    [TestClass]
    class ClassUnitTest
    {
        [TestMethod]
        public void TestCreditHoursTrue()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                int creditHours = 3;
                USurvive.Class test = new USurvive.Class("name", "instructor", creditHours, null, null, null, 0, "", null);

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
                USurvive.Class test = new USurvive.Class("name", "instructor", creditHours, null, null, null, 0, "", null);

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
                USurvive.Class test = new USurvive.Class("name", "instructor", creditHours, null, null, null, 0, "", null);

                Assert.IsTrue(test.CreditHours == creditHours);
            }
        }
    }
}
