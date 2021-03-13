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
    public partial class Notification : Window
    {
        public Notification()
        {
            InitializeComponent();
            cbSnooze.SelectedIndex = 0; // 15 minutes
        }

        private void CloseClick(Object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void SnoozeClick(Object sender, RoutedEventArgs e)
        {
            Console.WriteLine(cbSnooze.SelectedItem);  // TODO: renotify at current time plus snooze time
        }
        
    }
}
