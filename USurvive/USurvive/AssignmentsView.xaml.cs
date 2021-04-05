using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for AssignmentsView.xaml
    /// </summary>
    public partial class AssignmentsView : Page
    {
        public AssignmentsView()
        {
            InitializeComponent();
             dgAssignmentsList.ItemsSource = Globals.cwList.classwork;
             dgAssignmentsList.Items.SortDescriptions.Add(new SortDescription("Cl", ListSortDirection.Ascending));
        }

        private void btnNewAssignment_Click(object sender, RoutedEventArgs e)
        {
            EditAssignment editor = new EditAssignment();
            editor.Show();
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Classwork cw = (Classwork)button.DataContext;
            EditAssignment edit = new EditAssignment(cw);
            edit.Show();
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Classwork cw = (Classwork)button.DataContext;
            Globals.cwList.DeleteClasswork(cw);
        }
    }
}
