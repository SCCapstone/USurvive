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
        ObservableCollection<Grade> grades { get; set; }

        public GradeList()
        {
            this.grades = new ObservableCollection<Grade>();
        }

        public GradeList(ObservableCollection<Grade> grades) //Will likely be used when reading JSON
        {
            this.grades = grades;
        }

        public ObservableCollection<Grade> GetGrades()
        {
            return this.grades;
        }
        public void AddGrade (Grade grade)
        {
            this.grades.Add(grade);
        }

        public ObservableCollection<Grade> GetGradesForClass(Class UClass)
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
