using System;
using System.IO;
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
using TaskDialogInterop;

namespace USurvive
{
    /// <summary>
    /// Interaction logic for UserSelection.xaml
    /// </summary>
    public partial class UserSelection : Window
    {
        public UserSelection()
        {
            InitializeComponent();
            loadDropdown();
            
        }

        public void loadDropdown()
        {
            string[] fileList = Directory.GetDirectories(Globals.dataDir, "*");
            for (int i = 0; i < fileList.Length; i++)
            {
                fileList[i] = fileList[i].Replace(Globals.dataDir, "");
            }
            Array.Resize(ref fileList, fileList.Length + 1);
            fileList[fileList.Length - 1] = "<Create new user...>";
            userDropdown.ItemsSource = fileList;
            
        }
        private void CloseClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            
            string settingfile = Globals.dataDir + "databaseSetting";
            if (File.Exists(settingfile))
            {
                File.Delete(settingfile);
            }
            using (StreamWriter fileOutput = new StreamWriter(settingfile, true))
            {
                fileOutput.WriteLine(userDropdown.SelectedItem);
                Globals.databaseName = (string)userDropdown.SelectedItem + "\\";
            }
            DatabaseLoad.LoadDatabase();
            this.Close();
        }

        private void databaseClick(object sender, RoutedEventArgs e)
        {
            //Adapted from https://stackoverflow.com/a/6872106
            TaskDialogOptions databaseWindow = new TaskDialogOptions();

            databaseWindow.Owner = this;
            databaseWindow.Title = "Database Management";
            databaseWindow.MainInstruction = "What would you like to do with this database?";
            databaseWindow.Content = "Working on " + Globals.databaseName.Replace("\\","") + "'s database";
            databaseWindow.CommandButtons = new string[]
            {
                "Export the database for the current user\nThis will allow you to copy the database onto another computer",
                "Import a new database\nWarning: This will overwrite the database for " + Globals.databaseName.Replace("\\",""),
                "Do nothing"
            };
            TaskDialogResult res = TaskDialog.Show(databaseWindow);

            switch (res.CommandButtonResult)
            {
                case 0:
                    //Export the database
                    DatabaseExport.ExportDatabase();
                    break;
                case 1:
                    //Import the database
                    //Should we ask if this is okay?  On one hand, we already warn them in text.  On the other, this is a potentially destructive operation.
                    DatabaseExport.ImportDatabase();
                    break;
                case 2:
                    //Do nothing.
                    break;

            }
        }

        private void userDropdown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if((String)userDropdown.SelectedItem == "<Create new user...>")
            {
                userDropdown.SelectedIndex = 0;
                CreateUser usercreate = new CreateUser(this);
                usercreate.Show();

            }
        }
        
        private void aboutButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO Add about screen with our names and stuff
        }
    }
}
