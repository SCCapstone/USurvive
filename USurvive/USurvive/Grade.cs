using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USurvive
{
    class Grade
    {
        public string Class { get; set; }
        public int TheGrade { get; set; }
        public int Hours { get; set; }
        public Grade(string aClass, int aTheGrade, int aHours)
        {
            Class = aClass;
            TheGrade = aTheGrade;
            Hours = aHours;
        }
    }
}
