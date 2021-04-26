using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace USurvive
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : Page
    {
        public int timeframe;
        public HomeView()
        {
            setTimeframe(7);
            InitializeComponent();
            showCurrentClasses();
            //showUpcomingClasses();
            showUpcomingAssignments();
            showOverdueAssignments();
        }

        public void refresh()
        {
            setTimeframe(7);
            InitializeComponent();
            showCurrentClasses();
            showUpcomingAssignments();
            showOverdueAssignments();
        }

        public void setTimeframe(int t)
        {
            timeframe = t;
        }

        private void ChooseUser_Click(object sender, RoutedEventArgs e)
        {
            DatabaseSave.SaveDatabase();
            UserSelection userSelection = new UserSelection(this);
            userSelection.Show();
        }

        private void showCurrentClasses()
        {
            String names = "";
            foreach(Class newClass in Globals.clList.classes){
                names += (newClass.Name + " (");
                if (getClassGrade(newClass) == -1)
                {
                    names += "N/A";
                }
                else
                {
                    names += getClassGrade(newClass);
                }
                names += ") " + "   "; ;
            }
            this.class_list.Text = names;
        }

        private double getClassGrade(Class newClass)
        {
            ArrayList gradeList = new ArrayList();
            foreach (Grade grade in Globals.gradebook.grades)
            {
                if(grade.ClassName == newClass.Name && grade.MaxPoints > 0)
                {
                    gradeList.Add((double)grade.PointsEarned/(double)grade.MaxPoints);
                }
            }
            double sum = 0;
            foreach (double score in gradeList)
            {
                sum += score;
            }

            if(gradeList.Count < 1)
            {
                return -1;
            }
            
            return (sum / gradeList.Count)*100;
        }

        private void showUpcomingAssignments()
        {
            String names = "";
            
            foreach (Classwork newAssignment in Globals.cwList.classwork)
            {
                if (newAssignment.DueDate != null && newAssignment.Completed == false && Nullable.Compare(newAssignment.DueDate, DateTime.Now.AddDays(timeframe)) < 0
                    && Nullable.Compare(newAssignment.DueDate, DateTime.Now) >= 0)
                {
                    
                    names += (newAssignment.Name + "\n" + newAssignment.Cl + "\n" + newAssignment.DueDate + "\n" + "Priority: " + newAssignment.Priority + "\n" + "\n");
                }
            }

            this.upcomingassignment_list.Text = names;

        }

        private void showOverdueAssignments()
        {
            String names = "";

            foreach (Classwork newAssignment in Globals.cwList.classwork)
            {
                if (newAssignment.DueDate != null && Nullable.Compare(newAssignment.DueDate, DateTime.Now) < 0 && !newAssignment.Completed)
                {
                    newAssignment.Priority = 1;
                    
                    names += (newAssignment.Name + "\n" + newAssignment.Cl + "\n" + newAssignment.DueDate + "\n" + "Priority: " + newAssignment.Priority + "\n" + "\n"); // Add class name
                    
                }
            }

            if(names == "")
            {
                names = "No assignments are overdue";
                overdueassignment_list.Foreground = Brushes.Green;
            }

            this.overdueassignment_list.Text = names;
        }

        private void upcomingSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.Weeks.Text = (int)this.upcomingSlider.Value + ((int)this.upcomingSlider.Value == 1 ? " week ahead" : " weeks ahead");
            timeframe = (int)this.upcomingSlider.Value * 7;
            showUpcomingAssignments();
        }
    }
}
