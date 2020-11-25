//using Newtonsoft.Json;
using System.Text.Json;
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
    /// Interaction logic for DebugPanel.xaml
    /// </summary>
    public partial class DebugPanel : Window
    {
        public DebugPanel()
        {
            InitializeComponent();
        }
        private void NewClassClick(Object sender, RoutedEventArgs e)
        {
            EditClass editClass = new EditClass();
            editClass.Show();
        }
        private void ShowClassClick(Object sender, RoutedEventArgs e)
        {
            foreach (Class clas in Globals.tempClasses)
            {
                //Console.WriteLine(clas);
                this.WriteDebug(clas.ToString());
            }
        }


        //JSON Save
        private void JSONSaveClick(Object sender, RoutedEventArgs e)
        {
            DatabaseSave.SaveClasses();
        }


        //JSON Load
        private void JSONLoadClick(Object sender, RoutedEventArgs e)
        {
            DatabaseLoad.LoadClasses();
        }

        //Show notification
        private void ShowNotificationClick(Object sender, RoutedEventArgs e)
        {
            //Notification notification = new Notification();
        }


        private void WriteDebug(String text)
        {
            debugOutput.Text += "\n" + text;
            debugOutput.ScrollToEnd();
        }
    }
}
