﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USurvive
{
    public class Classwork
    {
        
        //We really only need this one class, the others are redundant.
        string name;
        DateTime dueDate;
        int priority;
        Grade grade;
        bool autoIncrement;
        int autoIncrementDays;
        ClassworkType type;

        public Classwork(string name, DateTime dueDate, int priority, Grade grade, bool autoIncrement, int autoIncrementDays, ClassworkType type)
        {
            this.name = name;
            this.dueDate = dueDate;
            this.priority = priority;
            this.grade = grade;
            this.autoIncrement = autoIncrement;
            this.autoIncrementDays = autoIncrementDays;
            this.type = type;
        }
        string GetClassworkType()
        {
            throw new NotImplementedException();
        }
        string GetName()
        {
            throw new NotImplementedException();
        }
        DateTime GetDueDate()
        {
            throw new NotImplementedException();
        }
        int GetPriority()
        {
            throw new NotImplementedException();
        }
        Grade getGrade()
        {
            throw new NotImplementedException();
        }
        void SetName(string name)
        {
            throw new NotImplementedException();
        }
        void SetDueDate(DateTime date)
        {
            throw new NotImplementedException();
        }
        void SetPriority(int priority)
        {
            throw new NotImplementedException();
        }
        void setGrade(Grade grade)
        {
            throw new NotImplementedException();
        }

    }
}
