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
    /// Interaction logic for Window1.xaml
    /// </summary>
    /// 
    public partial class Notification : Window
    {
        private Classwork classwork;

        public Notification(Classwork cw)
        {
            InitializeComponent();
            cbSnooze.SelectedIndex = 0; // 15 minutes by default
            TimeSpan snooze = new TimeSpan(0); // no time at all unless snooze is hit
            classwork = cw;
        }

        private void CloseClick(Object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void SnoozeClick(Object sender, RoutedEventArgs e)
        {
            
            int idx = cbSnooze.SelectedIndex;
            TimeSpan snooze;
            if (idx == 0)
                snooze = new TimeSpan(0, 15, 0);  // 15 min 
            else if (idx == 1)
                snooze = new TimeSpan(0, 30, 0);  // 30 min
            else  // idx should equal 2
                snooze = new TimeSpan(1, 0, 0);  // 1 hr
            classwork.NotificationTime = DateTime.Now + snooze;
            classwork.ShownNotification = false;
            this.Close();
        }
        
    }
}
