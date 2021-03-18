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
using System.Windows.Shapes;

namespace USurvive
{
    /// <summary>
    /// Interaction logic for EditAssignment.xaml
    /// </summary>
    public partial class EditAssignment : Window
    {
        public Classwork createdCW { get; set; } = null; // property to expose to other windows

        public EditAssignment()
        {
            InitializeComponent();
            //By default, don't enable the auto increment
            tbAutoIncrementDays.Text = "0";
            tbAutoIncrementDays.IsEnabled = false;
            cmbClasses.ItemsSource = Globals.clList.classes;
        }

        public EditAssignment(Class cl)
        {
            InitializeComponent();
            ObservableCollection<Class> singletonClass = new ObservableCollection<Class>();
            singletonClass.Add(cl);
            cmbClasses.ItemsSource = singletonClass;
            cmbClasses.SelectedItem = cl;
        }


        private void SaveClick(object sender, RoutedEventArgs e)
        {
            string name = tbAssignmentName.Text;
            //string grade = tbGrade.Text;
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
            int autoIncDays = 0;
            try { autoIncDays = int.Parse(tbAutoIncrementDays.Text); } catch (Exception) { }

            DateTime? noteTime = dpNoteTime.Value;
            DateTime notifTime;
            if (noteTime == null)
            {
                notifTime = new DateTime();
            }
            else notifTime = (DateTime)(noteTime);

            //DateTime dueDate = dpDueDate.DisplayDate;
            DateTime dueDate;
            if (dpDueDate.Value == null)
            {
                dueDate = new DateTime();
            }
            else dueDate = (DateTime)(dpDueDate.Value);

            string cl;
            Grade tempGrade;
            try
            {
                cl = ((Class)cmbClasses.SelectedItem).Name;
                tempGrade = new Grade(((Class)cmbClasses.SelectedItem).Name, dueDate);

            }
            catch (NullReferenceException)
            {
                cl = null;
                tempGrade = new Grade(null, dueDate);
            }
            Classwork tempClasswork = new Classwork(name, cl, dueDate, cmbPriority.SelectedIndex + 1, tempGrade.gradeID, (bool)cbAutoIncrement.IsChecked, autoIncDays, type, notifTime);
            tempGrade.cwID = tempClasswork.CWID;

            if ((bool)cbComplete.IsChecked)
            {
                tempClasswork.Completed = true;
            }

            Globals.gradebook.AddGrade(tempGrade);
            createdCW = tempClasswork;
            Globals.cwList.AddClasswork(tempClasswork);

            this.Close();

        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbAutoIncrement_Checked(object sender, RoutedEventArgs e)
        {
            if (!(bool)cbAutoIncrement.IsChecked)
            {
                tbAutoIncrementDays.Text = "0";
                tbAutoIncrementDays.IsEnabled = false;
            }
            else tbAutoIncrementDays.IsEnabled = true;
        }
    }

}

