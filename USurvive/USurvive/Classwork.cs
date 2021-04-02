using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace USurvive
{
    public class Classwork
    {
        
        //We really only need this one class, the others are redundant.
        public string Name { get; set; }
        public bool Completed { get; set; }
        public string Cl { get; set; }
        public DateTime? DueDate { get; set; }
        public int Priority { get; set; }
        public bool AutoIncrement { get; set; }
        public int AutoIncrementDays { get; set; }
        public ClassworkType Type { get; set; }
        public bool ShownNotification { get; set; }
        public bool Done { get; set; }

        public DateTime? NotificationTime { get; set; }
        public Guid CWID1 { get; }
        public Guid GradeID { get; set; }
        public Guid CWID { get; set; }

        public string PrettyDate
        {
            get
            {
                return DueDate != null ? DueDate.Value.ToString("M/d hh:mm tt") : "N/A";
            }
        }

        public Classwork(string name, string cl, DateTime? dueDate, int priority, Guid gradeID, bool autoIncrement, int autoIncrementDays, ClassworkType type, DateTime? notificationTime)
        {
            //Generate ID
            this.CWID = System.Guid.NewGuid();

            this.Name = name;
            this.Completed = false;
            this.Cl = cl;
            this.DueDate = dueDate;
            this.Priority = priority;
            this.GradeID = gradeID;
            this.AutoIncrement = autoIncrement;
            this.AutoIncrementDays = autoIncrementDays;
            this.Type = type;
            this.NotificationTime = notificationTime;
            if (notificationTime == null)
                this.ShownNotification = true;
            else
                this.ShownNotification = false;

            this.Completed = false;


            JsonSerializerOptions options = new JsonSerializerOptions() { IncludeFields = true, };
        }

        public Classwork(string name, string cl, DateTime dueDate, int priority, Guid gradeID, bool autoIncrement, int autoIncrementDays, ClassworkType type, DateTime notificationTime, Guid CWID)
        { 

            this.Name = name;
            this.Completed = false;
            this.Cl = cl;
            this.DueDate = dueDate;
            this.Priority = priority;
            this.GradeID = gradeID;
            this.AutoIncrement = autoIncrement;
            this.AutoIncrementDays = autoIncrementDays;
            this.Type = type;
            this.NotificationTime = notificationTime;
            this.CWID = CWID;
            this.ShownNotification = false;

            this.Completed = false;

            JsonSerializerOptions options = new JsonSerializerOptions() { IncludeFields = true, };
        }
        public Classwork()
        {
            JsonSerializerOptions options = new JsonSerializerOptions() { IncludeFields = true, };
        }

        public String ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public void ShowNotification()
        {
            Notification notification = new Notification(this);
            string dueMinRemaining = "";
            string dueHrsRemaining = "";
            string dueDaysRemaining = "";
            string inTxt = "in ";
            string agoTxt = "";
            string isWasTxt = "is";
            if (DueDate != null)
            {
                TimeSpan dueTimeRemaining = (DateTime)DueDate - DateTime.Now;
                // when dueTimeRemaining is negative switch langauge to refect "was due ... ago" instead of "is due ... in"
                if (dueTimeRemaining.TotalMilliseconds < 0)
                {
                    inTxt = "";
                    agoTxt = " ago";
                    isWasTxt = "was";
                    dueTimeRemaining = dueTimeRemaining.Duration();
                }
                // find maximal units to represent remaining time
                if (Math.Floor(dueTimeRemaining.TotalDays) == 1)
                {
                    dueDaysRemaining = dueTimeRemaining.Days.ToString() + " day";
                }
                else if (dueTimeRemaining.TotalDays > 1)
                {
                    dueDaysRemaining = dueTimeRemaining.Days.ToString() + " days";
                }
                else if (dueTimeRemaining.TotalHours >= 1)
                {
                    dueHrsRemaining = dueTimeRemaining.Hours.ToString() + " hr ";
                    dueMinRemaining = dueTimeRemaining.Minutes.ToString() + " min";
                }
                else
                {
                    dueMinRemaining = dueTimeRemaining.Minutes.ToString() + " min";
                }

                notification.tb_NoteText.Text = notification.tb_NoteText.Text.Replace("$ASSIGNMENT", Name);
                notification.tb_NoteText.Text = notification.tb_NoteText.Text.Replace("$DAYS", dueDaysRemaining);
                notification.tb_NoteText.Text = notification.tb_NoteText.Text.Replace("$HRS", dueHrsRemaining);
                notification.tb_NoteText.Text = notification.tb_NoteText.Text.Replace("$MIN", dueMinRemaining);
                notification.tb_NoteText.Text = notification.tb_NoteText.Text.Replace("$IN", inTxt);
                notification.tb_NoteText.Text = notification.tb_NoteText.Text.Replace("$AGO", agoTxt);
                notification.tb_NoteText.Text = notification.tb_NoteText.Text.Replace("$ISWAS", isWasTxt);
            }
            else  // No due date, so give a generic reminder
            {
                notification.tb_NoteText.Text = "Reminder for " + Name;
            }
            

            this.ShownNotification = true; //Set this to false once snoozed
            notification.Show();
        }

        public static void showNotification(Classwork classwork)
        {
            classwork.ShowNotification();
        }
    }
}
