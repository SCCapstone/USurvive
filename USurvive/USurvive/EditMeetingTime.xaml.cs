using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class EditMeetingTime : Window
    {
        public Class clas;
        public EditMeetingTime(Class cl)
        {
            InitializeComponent();
            clas = cl;
            dgMeetingTimes.DataContext = clas.MeetingTimes;
            tpTime.Value = DateTime.Now;
        }

        private void AddMeetingClick(object sender, RoutedEventArgs e)
        { 
            DateTime? hrsMins = tpTime.Value;
            int[] time = new int[2];
            if (hrsMins.HasValue)
            {
                time[0] = hrsMins.Value.Hour;
                time[1] = hrsMins.Value.Minute;
            }
            else
            {
                Error err = new Error();
                err.tb_ErrorText.Text = "Please select a valid time.";
                err.ShowDialog();
                return;
            }

            int length;
            if (!string.IsNullOrEmpty(tbLengthInMin.Text))
                length = int.Parse(tbLengthInMin.Text);
            else
                length = 0;
            
            bool[] daysOfWeek = new bool[7];
            //function to set null to false
            bool nBoolToBool(bool? nb)
            {
                return nb.HasValue ? nb.Value : false;
            }
            if (nBoolToBool(Sun.IsChecked))
                daysOfWeek[0] = true;
            if (nBoolToBool(Mon.IsChecked))
                daysOfWeek[1] = true;
            if (nBoolToBool(Tu.IsChecked))
                daysOfWeek[2] = true;
            if (nBoolToBool(Wed.IsChecked))
                daysOfWeek[3] = true;
            if (nBoolToBool(Th.IsChecked))
                daysOfWeek[4] = true;
            if (nBoolToBool(Fri.IsChecked))
                daysOfWeek[5] = true;
            if (nBoolToBool(Sat.IsChecked))
                daysOfWeek[6] = true;

            MeetingTime mt = new MeetingTime(time, length, daysOfWeek);
            clas.MeetingTimes.Add(mt);
        }

        private void RemoveMeetingTimeClick(object sender, RoutedEventArgs e)
        {
           clas.MeetingTimes.Remove((MeetingTime)dgMeetingTimes.SelectedItem);
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true; // clas.MeetingTimes property recieved by EditClass.xaml.cs on close (see EditMeetingsClick)
            this.Close(); 
        }
        private void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
