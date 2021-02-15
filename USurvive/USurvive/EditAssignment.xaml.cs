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
            string name = tbAssignmentName.Text;
            string grade = tbGrade.Text;
            string autoIncrementDays = tbAutoIncrementDays.Text;
            ClassworkType type = ClassworkType.Assignment;

            switch (cmbType.SelectedIndex)
            {
                case 0:
                    type = ClassworkType.Assignment;
                    break;
                case 1:
                    type = ClassworkType.Assessment;
                    break;
                case 2:
                    type = ClassworkType.ExtraCredit;
                    break;
            }

            DateTime? noteTime = dpNoteTime.Value;
            DateTime notifTime;
            if (noteTime == null)
            {
                notifTime = new DateTime();
            }
            else notifTime = (DateTime)(noteTime);

            DateTime dueDate = dpDueDate.DisplayDate;


            Globals.cwList.AddClasswork(new Classwork(name, dueDate, 0, null, cbAutoIncrement.IsEnabled, int.Parse(autoIncrementDays), type, notifTime));
            //throw new NotImplementedException();

            //Globals.tempAssignments.Add(new Assignment(name, null, new DateTime(), new DateTime(), 0, null, (bool)cbAutoIncrement.IsChecked, 0));
            this.Close();


        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}

