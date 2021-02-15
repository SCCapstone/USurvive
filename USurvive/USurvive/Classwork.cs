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
        public DateTime DueDate { get; set; }
        public int Priority { get; set; }
        public bool AutoIncrement { get; set; }
        public int AutoIncrementDays { get; set; }
        public ClassworkType Type { get; set; }
        public bool ShownNotification { get; set; }

        public DateTime NotificationTime { get; set; }
        public Guid CWID1 { get; }
        public Guid GradeID { get; set; }
        public Guid CWID { get; set; }

        public Classwork(string name, DateTime dueDate, int priority, Guid gradeID, bool autoIncrement, int autoIncrementDays, ClassworkType type, DateTime notificationTime)
        {
            //Generate ID
            this.CWID = System.Guid.NewGuid();

            this.Name = name;
            this.DueDate = dueDate;
            this.Priority = priority;
            this.GradeID = gradeID;
            this.AutoIncrement = autoIncrement;
            this.AutoIncrementDays = autoIncrementDays;
            this.Type = type;
            this.NotificationTime = notificationTime;
            this.ShownNotification = false;



            JsonSerializerOptions options = new JsonSerializerOptions() { IncludeFields = true, };
        }

        public Classwork(string name, DateTime dueDate, int priority, Guid gradeID, bool autoIncrement, int autoIncrementDays, ClassworkType type, DateTime notificationTime, Guid CWID)
        { 

            this.Name = name;
            this.DueDate = dueDate;
            this.Priority = priority;
            this.GradeID = gradeID;
            this.AutoIncrement = autoIncrement;
            this.AutoIncrementDays = autoIncrementDays;
            this.Type = type;
            this.NotificationTime = notificationTime;
            this.CWID = CWID;
            this.ShownNotification = false;



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
            //TODO: Figure this out
            string dueTimeRemaining = "unfinshed";
            string dueUnits = "unfinished";

            Notification notification = new Notification();
            notification.tb_NoteText.Text = notification.tb_NoteText.Text.Replace("$ASSIGNMENT", Name);
            notification.tb_NoteText.Text = notification.tb_NoteText.Text.Replace("$TIME", dueTimeRemaining);
            notification.tb_NoteText.Text = notification.tb_NoteText.Text.Replace("$UNITS", dueUnits);

            notification.Show();

            this.ShownNotification = true;//Set this to false once snoozed
        }

        public static void showNotification(Classwork classwork)
        {
            classwork.ShowNotification();
        }
    }
}
