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
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : Page
    {
        private int timeframe = 7;
        public HomeView()
        {
            InitializeComponent();
            showCurrentClasses();
            showUpcomingClasses();
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
            UserSelection userSelection = new UserSelection();
            userSelection.Show();
        }

        private void showCurrentClasses()
        {
            String names = "";
            foreach(Class newClass in Globals.clList.classes){
               names += (newClass.Name + "\n");
            }
            this.class_list.Text = names;
        }

        private void showUpcomingClasses() //ClassList method for obtaining all classes of the day. Iterate through observable collection and convert to string
        {
            String names = "";
            ObservableCollection<Class> upcomingList = Globals.clList.GetClassesForDay(DateTime.Now);
            foreach (Class newClass in upcomingList)
            {
                names += newClass.Name + " @ " + "$Next Meeting Variable" + "\n";
            }
            this.upcomingclass_list.Text = names;
        }

        private void showUpcomingAssignments()
        {
            String names = "";
            
            foreach (Classwork newAssignment in Globals.cwList.classwork)
            {
                if (DateTime.Compare(newAssignment.DueDate, DateTime.Now.AddDays(timeframe)) < 0 && DateTime.Compare(newAssignment.DueDate, DateTime.Now) >= 0)
                {
                    //names += (newAssignment.Name + " - - -  Priority:" + newAssignment.Priority + "\n"); // Add class name
                    names += (newAssignment.Name + "\n" + newAssignment.Cl + "\n" + "Priority: "+ newAssignment.Priority + "\n" + "\n");
                }
            }

            this.upcomingassignment_list.Text = names;

        }

        private void showOverdueAssignments()
        {
            String names = "";

            foreach (Classwork newAssignment in Globals.cwList.classwork)
            {
                if (DateTime.Compare(newAssignment.DueDate, DateTime.Now) < 0)
                {
                    newAssignment.Priority = 1;
                    //names += (newAssignment.Name + " - - -  Priority:" + newAssignment.Priority + "\n");
                    names += (newAssignment.Name + "\n" + newAssignment.Cl + "\n" + "Priority: " + newAssignment.Priority + "\n" + "\n"); // Add class name
                    
                }
            }

            this.overdueassignment_list.Text = names;
        }
    }
}
