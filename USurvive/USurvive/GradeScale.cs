using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USurvive
{
    public class GradeScale
    {
        public int pointIncrement { get; set; }
        public int roundingType { get; set; }
        public char specialGrade { get; set; }//Used for unique grades, such as 'W' and 'I'

        public GradeScale(int pointIncrement, int roundingType)
        {
            this.pointIncrement = pointIncrement;
            //Eventually, add checks to ensure this is valid
            this.roundingType = roundingType;
        }

        public char GetLetterGrade(int gradeValue)
        {
            Console.WriteLine("Not implemented!");
            return 'z';
        }
    }
}
