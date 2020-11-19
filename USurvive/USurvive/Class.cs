using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USurvive
{
    class Class
    {
        private string Name { get; set; }
        private string Instructor { get; set; }
        private int CreditHours { get; set; }
        private Uri InstructorEmail { get; set; }
        private Uri ClassWebsite { get; set; }
        private Syllabus Syllabus { get; set; }
        private int ClassType { get; set; } //In person, online live, online async, etc.
        private string Notes { get; set; }
        private List<MeetingTime> MeetingTimes { get; set; }

        public Class(string name, string instructor, int creditHours, Uri instructorEmail, Uri classWebsite, Syllabus syllabus, int classType, string notes, List<MeetingTime> meetingTimes){
            this.Name = name;
            this.Instructor = instructor;
            this.CreditHours = creditHours;
            this.InstructorEmail = instructorEmail;
            this.ClassWebsite = classWebsite;
            this.Syllabus = syllabus;
            this.ClassType = classType;
            this.Notes = notes;
            this.MeetingTimes = meetingTimes;
        }

        public override string ToString()
        {
            string ret = "";
            ret += this.Name;
            ret += ",";
            ret += this.Instructor;
            ret += ",";
            ret += this.CreditHours;
            ret += ",";
            //ret += MeetingTimes.ToString();
            ret += "";

            return ret;
        }
    }
}
