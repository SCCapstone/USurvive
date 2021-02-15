using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace USurvive
{
    public class Grade
    {
        public string ClassName { get; set; }
        public int UGrade { get; set; }
        public int Hours { get; set; }
        public String Name { get; set; }
        public DateTime Date { get; set; }
        public int PointsEarned { get; set; }
        public int MaxPoints { get; set; }
        public int GradeWeight { get; set; }

        public Guid cwID { get; set; }
        public Guid gradeID { get; set; }

        public Grade(string className, int uGrade, int hours, string name, DateTime date, int pointsEarned, int maxPoints, int gradeWeight, Guid cwID)
        {
            this.ClassName = className;
            this.UGrade = uGrade;
            this.Hours = hours;
            this.Name = name;
            this.Date = date;
            this.PointsEarned = pointsEarned;
            this.MaxPoints = maxPoints;
            this.GradeWeight = gradeWeight;
            this.cwID = cwID;

            JsonSerializerOptions options = new JsonSerializerOptions() { IncludeFields = true, };
        }

        public Grade(string className, DateTime date)
        {
            //Generate ID
            this.gradeID = System.Guid.NewGuid();

            this.ClassName = className;
            this.Date = date;
            JsonSerializerOptions options = new JsonSerializerOptions() { IncludeFields = true, };

        }

        public Grade()
        {
            JsonSerializerOptions options = new JsonSerializerOptions() { IncludeFields = true, };

        }

        public String ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
