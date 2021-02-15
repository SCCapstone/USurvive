﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace USurvive
{
    public class Grade
    {
        public string Class { get; set; }
        public int TheGrade { get; set; }
        public int Hours { get; set; }
        public String Name { get; set; }
        public DateTime ADate { get; set; }
        public int PointsEarned { get; set; }
        public int MaxPoints { get; set; }
        public int GradeWeight { get; set; }
        public Grade(String aClass, int aTheGrade, int aHours, String AName, DateTime AADate, int APointsE, int AMaxP, int AGradeW)
        {
            Class = aClass;
            TheGrade = aTheGrade;
            Hours = aHours;
            Name = AName;
            ADate = AADate;
            PointsEarned = APointsE;
            MaxPoints = AMaxP;
            GradeWeight = AGradeW;

            JsonSerializerOptions options = new JsonSerializerOptions() { IncludeFields = true, };
        }

        public String ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
