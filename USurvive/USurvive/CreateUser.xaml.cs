using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for CreateUser.xaml
    /// </summary>
    public partial class CreateUser : Window
    {
        UserSelection parent;
        public CreateUser(UserSelection parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            string newUsername = enterField.Text;
            newUsername.Replace("\"", "");
            newUsername.Replace("*", "");
            newUsername.Replace("\\", "");
            newUsername.Replace("/", "");
            newUsername.Replace(":", "");
            newUsername.Replace("<", "");
            newUsername.Replace(">", "");
            newUsername.Replace("?", "");
            newUsername.Replace("|", "");
            if (Directory.Exists(Globals.dataDir + newUsername))
            {
                Error error = new Error();
                error.tb_ErrorText.Text = "User file already exists!";
                error.Show();
                
            }
            else
            {
                Directory.CreateDirectory(Globals.dataDir + newUsername);
                parent.loadDropdown();
                parent.userDropdown.SelectedItem = newUsername;
                this.Close();
            }

        }
    }
}
