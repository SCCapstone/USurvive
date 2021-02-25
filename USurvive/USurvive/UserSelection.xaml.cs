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

            string[] fileList = Directory.GetDirectories(Globals.dataDir, "*");
            for(int i = 0; i < fileList.Length; i++){
                fileList[i] = fileList[i].Replace(Globals.dataDir, "");
            }
            userDropdown.ItemsSource = fileList;
        }

        public void loadUsers()
        {

            //== Setting the new database==
            //1.Delete existing "Globals.dataDir + "databaseSetting"" file
            //2.Create new "Globals.dataDir + "databaseSetting"" file with the name of the new database folder(if user chooses to set new database as default)
            //3.Set Globals.databaseName to the name of the database folder
            //4.Call DatabaseLoad.LoadDatabase to load the new database file
            //

            string userFile = Globals.dataDir + Globals.databaseName + ".usurvive";
            Globals.databaseName = userFile;
            DatabaseLoad.LoadDatabase();


        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
