using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;


namespace USurvive
{
    /// <summary>
    /// Interaction logic for ClassOverview.xaml
    /// </summary>
    public partial class ClassOverview : Window
    {
        ObservableCollection<Classwork> classworkList;
        ObservableCollection<Grade> grades;
        public ClassOverview(Class source)
        {
            InitializeComponent();
            classNameText.Text = source.Name;
            classworkList = Globals.cwList.classwork;
            grades = Globals.gradebook.grades;
            List <Classwork> uncompletedClasswork = new List<Classwork>();
            List<Classwork> uncompletedAssessments = new List<Classwork>();
            
            foreach (Classwork work in classworkList)
            {
                if ((work.Cl).Equals(source.Name))
                {
                    if (work.Completed == false && work.Type == ClassworkType.Assignment)
                        uncompletedClasswork.Add(work);
                    else if (work.Completed == false && work.Type == ClassworkType.Assessment)
                        uncompletedAssessments.Add(work);
                }
            }

            float totGrade = -1;
            foreach (Grade grade in grades)
            {
                if (grade.ClassName.Equals(source.Name))
                {
                    if (totGrade == -1)    
                        totGrade = grade.GradeWeight * (grade.PointsEarned/grade.MaxPoints);
                    else
                        totGrade += grade.GradeWeight * (grade.PointsEarned / grade.MaxPoints);
                }
            }

            if (totGrade == -1)
                gradeText.Text = "Nothing assigned yet.";
            else
                gradeText.Text = "" + totGrade; 
            dgUncompletedAssignments.DataContext = uncompletedClasswork;
            dgUncompletedAssessments.DataContext = uncompletedAssessments;
        }
    }
}
