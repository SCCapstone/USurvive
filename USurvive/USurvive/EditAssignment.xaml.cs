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

namespace USurvive
{
    /// <summary>
    /// Interaction logic for EditAssignment.xaml
    /// </summary>
    public partial class EditAssignment : Window
    {
        public EditAssignment()
        {
            InitializeComponent();
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            String name = tbAssignmentName.Text;
            String date = tbDate.Text;
            String dueDate = tbDueDate.Text;
            String grade = tbGrade.Text;
            String autoIncrementDays = tbAutoIncrementDays.Text;

            throw new NotImplementedException();

            //Globals.tempAssignments.Add(new Assignment(name, null, new DateTime(), new DateTime(), 0, null, (bool)cbAutoIncrement.IsChecked, 0));
            this.Close();


        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}

