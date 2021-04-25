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

        /// <summary>
        /// Logic for clicking Select (formerly ok) button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OK_Click(object sender, RoutedEventArgs e)
        {
            
            string settingfile = Globals.dataDir + "databaseSetting";
            if (File.Exists(settingfile))
            {
                try
                {
                    File.Delete(settingfile);
                }
                catch
                {
                    Error err = new Error();
                    err.tb_ErrorText.Text = "Can't delete settings file. \nAnother program might be using it.";
                    err.ShowDialog();
                    return;
                }
            }
            using (StreamWriter fileOutput = new StreamWriter(settingfile, true))
            {
                fileOutput.WriteLine(userDropdown.SelectedItem);
                Globals.databaseName = (string)userDropdown.SelectedItem + "\\";
            }
            DatabaseLoad.LoadDatabase();
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            string userDir = Globals.dataDir + (string)userDropdown.SelectedItem;
            if (!Globals.databaseName.Equals((string)userDropdown.SelectedItem + "\\"))
            {
                
                if (Directory.Exists(userDir))
                {
                    try
                    {
                        Directory.Delete(userDir, true);  // recursively delete user directory
                    }
                    catch
                    {
                        Error err = new Error();
                        err.tb_ErrorText.Text = "Can't delete user file. \nAnother program might be using it.";
                        err.ShowDialog();
                        return;
                    }
                    loadDropdown();
                    userDropdown.SelectedIndex = 0;  // reselect first item so we don't get an empty TextBox
                }
                else  // The file doesn't exist, just "delete" it by reloading the dropdown
                {
                    loadDropdown();
                    userDropdown.SelectedIndex = 0;
                }
            }
            else
            {
                Error err = new Error();
                err.tb_ErrorText.Text = "You can't delete the user that is currently in use.";
                err.ShowDialog();
                return;
            }
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
                "Import a new database\nAdd a new database to USurvive",
                "Do nothing"
            };
            TaskDialogResult res = TaskDialog.Show(databaseWindow);

            switch (res.CommandButtonResult)
            {
                case 0:
                    //Export the database
                    DatabaseExport.ExportDatabase();
                    Done doneExport = new Done(Globals.databaseName.Replace("\\", ""), "export");
                    doneExport.Show();
                    break;
                case 1:
                    //Import the database
                    //Should we ask if this is okay?  On one hand, we already warn them in text.  On the other, this is a potentially destructive operation.

                    //Make sure the database is valid
                    if (DatabaseExport.ImportDatabase())
                    {
                        Done doneImport = new Done(Globals.databaseName.Replace("\\", ""), "import");
                        loadDropdown();
                        doneImport.Show();
                    }

                    
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
            About about = new About();
            about.Show();
        }
    }
}
