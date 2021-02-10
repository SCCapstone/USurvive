using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USurvive
{
    public class MeetingTime
    {
        int[] time { get; set;  }//Starting time in the format [HH,mm].  24 hour time is used here to make implementation easier.
        int length { get; set; }//Length of the meeting in minutes
        bool[] meetingTimes { get; set; }//One for each day of the week
        string name {get; set; }//Name.  Pretty self explanitory.  May end up not being used.

        public MeetingTime(int[] time, int length, bool[] meetingTimes)
        {
            if(time.Length == 2)
            {
                //Verify format
                if (time[0] < 24)
                    if (time[1] < 60)
                        this.time = time;
            }
            if(this.time == null)
            {
                //Show error dialog
                Error error = new Error();
                error.tb_ErrorText.Text = "Time is invalid!";
                error.Show();
                return;
            }

            this.length = length;

            if (meetingTimes.Length == 7)
                this.meetingTimes = meetingTimes;
            else
            {//This should never happen, just a sanity check
                //Show error dialog
                Error error = new Error();
                error.tb_ErrorText.Text = "Meeting Times array is invalid!";
                error.Show();
                return;
            }
        }

        public string GetMeetingTime()
        {
            //Get the meeting time as a formatted string
            string ret = "";

            //SuMTuWThFSa
            if (this.meetingTimes[0])
                ret += "Su";
            if (this.meetingTimes[1])
                ret += "M";
            if (this.meetingTimes[2])
                ret += "Tu";
            if (this.meetingTimes[3])
                ret += "W";
            if (this.meetingTimes[4])
                ret += "Th";
            if (this.meetingTimes[5])
                ret += "F";
            if (this.meetingTimes[6])
                ret += "Sa";

            ret += "-"; //Can be displayed as is, or code can split at this character to show only part of the string

            bool PM = false;
            if (this.time[0] >= 13)
                PM = true;
            ret += this.time[0];
            ret += ":";
            ret += this.time[1];
            ret += " ";
            ret += (PM ? "PM" : "AM");//Ternary conditional operator

            return ret;

        }

        public DateTime GetNextMeeting()
        {
            Console.WriteLine("Not implemented yet!");
            return new DateTime();//Return default value for now, eventually we will write this code
        }

        public void setMeetingTime(int[] time, int length, bool[] meetingTimes)
        {
            if (time.Length == 2)
            {
                //Verify format
                if (time[0] < 24)
                    if (time[1] < 60)
                        this.time = time;
            }
            if (this.time == null)
            {
                //Show error dialog
                Error error = new Error();
                error.tb_ErrorText.Text = "Time is invalid!";
                error.Show();
                return;
            }

            this.length = length;

            if (meetingTimes.Length == 7)
                this.meetingTimes = meetingTimes;
            else
            {//This should never happen, just a sanity check
                //Show error dialog
                Error error = new Error();
                error.tb_ErrorText.Text = "Meeting Times array is invalid!";
                error.Show();
                return;
            }
        }
    }
}
