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
        System.Collections.ObjectModel.ObservableCollection<Assignment> assignmentList;
        public Sidebar()
        {
            InitializeComponent();

            classList = new System.Collections.ObjectModel.ObservableCollection<Class>();
            foreach (Class newClass in Globals.tempClasses)
            {
                classList.Add(newClass);
            }
            dgClassList.DataContext = classList;

            //assignmentList = new System.Collections.ObjectModel.ObservableCollection<Assignment>();
            //foreach ( Assignment newAssignment in Globals.tempAssignments)
            //{
            //    assignmentList.Add(newAssignment);
            //}
            dgAssignmentList.DataContext = Globals.cwList.classwork;

            
        }

        private void RefreshClick(object sender, RoutedEventArgs e)
        {
            classList = new System.Collections.ObjectModel.ObservableCollection<Class>();
            foreach (Class newClass in Globals.tempClasses)
            {
                classList.Add(newClass);
            }
            dgClassList.DataContext = classList;


            assignmentList = new System.Collections.ObjectModel.ObservableCollection<Assignment>();
            foreach (Assignment newAssignment in Globals.tempAssignments)
            {
                assignmentList.Add(newAssignment);
            }
            dgAssignmentList.DataContext = assignmentList;

        }
    }
}
