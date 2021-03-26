using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace USurvive
{
    public class Class
    {
        public string Name { get; set; }
        public string Instructor { get; set; }
        public int CreditHours { get; set; }
        public String InstructorEmailContent { 
            get
            {
                return InstructorEmail.ToString().Replace("mailto:","");
            }
            set
            {
                return;
            }
        }
        public Uri InstructorEmail { get; set; }
        public String ClassWebsiteContent { 
            get
            {
                return ClassWebsite.Host.ToString();
            }
            set 
            {
                return;
            }
        }
        public Uri ClassWebsite { get; set; }       
        public Syllabus Syllabus { get; set; }        
        public int ClassType { get; set; } //In person, online live, online async, etc.        
        public string Notes { get; set; }        
        public ObservableCollection<MeetingTime> MeetingTimes { get; set; }
        public string MtsDisp  // Property for binding pretty printed meeting times to datagrid
        {
            get
            {
                string ret = "";
                foreach (MeetingTime mt in MeetingTimes)
                {
                    ret += mt.GetMeetingTime() + "\n";
                }
                ret = ret.TrimEnd('\n');
                return ret;
            }
            set
            {
                return;
            }
        }

        public string TimeDisp
        {
            get
            {
                //For right now, just use the first meeting time.  Eventually we will try to read from the calendar to get the proper date.  Code for this is already implemented in this class
                if(MeetingTimes == null || MeetingTimes.Count == 0)
                {
                    return null;
                }
                return MeetingTimes[0].GetMeetingTime().Split('-')[1];
            }
        }
        public DateTime NotificationTime { get; set; }
        public GradeScale GradeScale { get; set; }


        public Class(string name, string instructor, int creditHours, Uri instructorEmail, Uri classWebsite, Syllabus syllabus, int classType, string notes, ObservableCollection<MeetingTime> meetingTimes, GradeScale gradeScale){
            this.Name = name;
            this.Instructor = instructor;
            this.CreditHours = creditHours;
            this.InstructorEmail = instructorEmail;
            this.ClassWebsite = classWebsite;
            this.Syllabus = syllabus;
            this.ClassType = classType;
            this.Notes = notes;
            this.MeetingTimes = meetingTimes;
            this.NotificationTime = NotificationTime;
            this.GradeScale = gradeScale;

            JsonSerializerOptions options = new JsonSerializerOptions() { IncludeFields = true, };
        }

        public String ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        //public DateTime GetCurrentMeeting()
        //{
        //    DateTime ret;

        //    return ret;
        //}

        public override string ToString()
        {
            string ret = "";
            ret += this.Name;
            ret += ", ";
            ret += this.Instructor;
            ret += ", ";
            ret += this.CreditHours;
            ret += ", ";
            if (MeetingTimes == null || MeetingTimes.Count() == 0)
                ret += "No meeting times set";
            else
                ret += MeetingTimes[0].GetMeetingTime();  // Show first Meeting Time

            return ret;
        }

        public bool MeetsToday()
        {
            return MeetsOnDate(DateTime.Now);
        }

        public bool MeetsOnDate(DateTime date)
        {
            int DOWInt = (int)date.DayOfWeek;
            if (MeetingTimes == null) return false;
            foreach (MeetingTime time in MeetingTimes)
            {
                if (time.MeetsOnDay(DOWInt))
                    return true;
            }
            return false;  // Doesn't meet on that day, apparently.
        }

        public MeetingTime GetDayMeeting(DateTime date) {
            int DOWInt = (int)date.DayOfWeek;
            if (MeetingTimes == null) return null;
            foreach (MeetingTime time in MeetingTimes)
            {
                if (time.MeetsOnDay(DOWInt))
                    return time;
            }
            return null;  // Doesn't meet on that day, apparently.
        }

    }
}
