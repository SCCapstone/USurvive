using System;
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
    /// Interaction logic for Sidebar.xaml
    /// </summary>
    public partial class Sidebar : Page
    {
        System.Collections.ObjectModel.ObservableCollection<Class> classList;
        System.Collections.ObjectModel.ObservableCollection<Classwork> assignmentList;

        DateTime SelectedDate;
        public Sidebar()
        {
            InitializeComponent();

            SelectedDate = DateTime.Now;

            classList = Globals.clList.GetClassesForDay(DateTime.Now);
            assignmentList = Globals.cwList.GetClassworkForDate(DateTime.Now);

            dgClassList.DataContext = classList;

            //assignmentList = new System.Collections.ObjectModel.ObservableCollection<Assignment>();
            //foreach ( Assignment newAssignment in Globals.tempAssignments)
            //{
            //    assignmentList.Add(newAssignment);
            //}
            dgAssignmentList.DataContext = assignmentList;
            displayGreeting();
            
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            Calendar calendar = (Calendar)sender;
            SelectedDate = (DateTime)calendar.SelectedDate;

            assignmentList = Globals.cwList.GetClassworkForDate(SelectedDate);
            dgAssignmentList.DataContext = assignmentList;

            classList = Globals.clList.GetClassesForDay(SelectedDate);
            dgClassList.DataContext = classList;

            //DateTest.Content = SelectedDate;
        }

        public void refresh()
        {
            this.displayGreeting();

            assignmentList = Globals.cwList.GetClassworkForDate(SelectedDate);
            dgAssignmentList.DataContext = assignmentList;

            classList = Globals.clList.GetClassesForDay(SelectedDate);
            dgClassList.DataContext = classList;
        }

        public void displayGreeting()
        {
            greeting.Text = "Welcome, ";
            if(Globals.databaseName.Substring(0, Globals.databaseName.Length - 1).Length > 13)
            {
                greeting.Text += "\n" + Globals.databaseName.Substring(0, Globals.databaseName.Length - 1);
                greeting.Margin = new Thickness(0,5,0,0);
                    //"0,15,0,0"
            }
            else
            {
                greeting.Text += Globals.databaseName.Substring(0, Globals.databaseName.Length - 1);
                greeting.Margin = new Thickness(0, 15, 0, 0);
            }
        }
    }
}
