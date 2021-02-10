using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USurvive
{
    public class GradeList
    {
        System.Collections.ObjectModel.ObservableCollection<Grade> grades { get; set; }

        public GradeList()
        {
            this.grades = new System.Collections.ObjectModel.ObservableCollection<Grade>();
        }

        public GradeList(System.Collections.ObjectModel.ObservableCollection<Grade> grades) //Will likely be used when reading JSON
        {
            this.grades = grades;
        }

        public System.Collections.ObjectModel.ObservableCollection<Grade> GetGrades()
        {
            return this.grades;
        }
        public void AddGrade (Grade grade)
        {
            this.grades.Add(grade);
        }

        public System.Collections.ObjectModel.ObservableCollection<Grade> GetGradesForClass(Class UClass)
        {
            //Not implemented
            return null;
        }
        public Grade GetGradeForClasswork(Classwork classwork)
        {
            //Not implemented
            return null;
        }

        public int ItemCount()
        {
            return grades.Count;
        }
    }
}
