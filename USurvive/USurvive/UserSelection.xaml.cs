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

        private void createNewUser_Click(object sender, RoutedEventArgs e)
        {
            CreateUser usercreate = new CreateUser(this);
            usercreate.Show();
        }
    }
}
