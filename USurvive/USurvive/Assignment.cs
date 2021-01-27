using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace USurvive
{
    public class Assignment
    {
        public String name { get; set; }
        public Class className { get; set; }
        public DateTime date { get; set; }

        public DateTime dueDate { get; set; }

        public int priority { get; set; }
        public Grade grade { get; set; }

        public bool autoIncrement { get; set; }
        public int autoIncrementDays { get; set; }
        

        public Assignment( String name, Class className, DateTime date, DateTime dueDate, int priority,
            Grade grade, bool autoIncrement, int autoIncrementDays)
        {
            this.name = name;
            this.className = className;
            this.date = date;
            this.dueDate = dueDate;
            this.priority = priority;
            this.grade = grade;
            this.autoIncrement = autoIncrement;
            this.autoIncrementDays = autoIncrementDays;

            JsonSerializerOptions options = new JsonSerializerOptions() { IncludeFields = true, };



        }
        public String ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

    }

    
}
