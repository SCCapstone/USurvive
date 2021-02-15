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
        public string name { get; set; }
        public DateTime dueDate { get; set; }
        public int priority { get; set; }
        public Grade grade { get; set; }
        public bool autoIncrement { get; set; }
        public int autoIncrementDays { get; set; }
        public ClassworkType type { get; set; }
        public bool shownNotification { get; set; }

        public DateTime notificationTime { get; set; }

        public Classwork(string name, DateTime dueDate, int priority, Grade grade, bool autoIncrement, int autoIncrementDays, ClassworkType type, DateTime notificationTime)
        {
            this.name = name;
            this.dueDate = dueDate;
            this.priority = priority;
            this.grade = grade;
            this.autoIncrement = autoIncrement;
            this.autoIncrementDays = autoIncrementDays;
            this.type = type;
            this.notificationTime = notificationTime;
            this.shownNotification = false;

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
            notification.tb_NoteText.Text = notification.tb_NoteText.Text.Replace("$ASSIGNMENT", name);
            notification.tb_NoteText.Text = notification.tb_NoteText.Text.Replace("$TIME", dueTimeRemaining);
            notification.tb_NoteText.Text = notification.tb_NoteText.Text.Replace("$UNITS", dueUnits);

            notification.Show();

            this.shownNotification = true;//Set this to false once snoozed
        }

        public static void showNotification(Classwork classwork)
        {
            classwork.ShowNotification();
        }
    }
}
