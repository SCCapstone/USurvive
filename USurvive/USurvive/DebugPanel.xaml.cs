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
using System.Media;

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
            DatabaseSave.SaveDatabase();
        }


        //JSON Load
        private void JSONLoadClick(Object sender, RoutedEventArgs e)
        {
            DatabaseLoad.LoadClasses();
        }

        //Show notification
        private void ShowNotificationClick(Object sender, RoutedEventArgs e)
        {
            //Define variables so the code can be reused later
            string name = "Fake Assignment";
            int time = 5;
            string[] notificationUnit = new string[]{ "minutes", "hours", "days", "weeks" };


            //Reusable part of the code
            Notification notification = new Notification(new Classwork(name,"dummyClass",DateTime.Now,1,Guid.NewGuid(),false,0,0,DateTime.Now + new TimeSpan(time, 0, 0, 0, 0)));
            string notificationText = notification.tb_NoteText.Text;
            //notificationText = notificationText.Replace("$ASSIGNMENT", name);
            //notificationText = notificationText.Replace("$TIME", time.ToString());
            //notificationText = notificationText.Replace("$UNITS", notificationUnit[2]);
            //notification.tb_NoteText.Text = notificationText;
            //Play notification sound
            SystemSounds.Exclamation.Play();
            //Show window
            notification.Show();
        }


        private void WriteDebug(String text)
        {
            debugOutput.Text += "\n" + text;
            debugOutput.ScrollToEnd();
        }

        private void AddAssignmentClick(object sender, RoutedEventArgs e)
        {
            EditAssignment editor = new EditAssignment();
            editor.Show();
        }

        private void ExportDatabaseClick(object sender, RoutedEventArgs e)
        {
            DatabaseExport.ExportDatabase();
        }
        private void ImportDatabaseClick(object sender, RoutedEventArgs e)
        {
            DatabaseExport.ImportDatabase();
        }

        private void MakeSyllabusClick(object sender, RoutedEventArgs e)
        {
            //Show file load dialog
            Microsoft.Win32.OpenFileDialog openDialog = new Microsoft.Win32.OpenFileDialog();

            bool? result = openDialog.ShowDialog();

            if(result == true)
            {
                Syllabus syllabus = new Syllabus(openDialog.FileName);
            }
        }
    }
}
