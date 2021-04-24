using System;
using System.Collections.Generic;
using System.IO;
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
            Error error = new Error();
            string newUsername = enterField.Text;
            // matches only strings the entirety of which are words of word characters
            // seperated by one or more spaces but no trailing spaces
            Regex words = new Regex(@"^(\w+ *\w+)+$");
            if (!words.IsMatch(newUsername))
            { 
                error.tb_ErrorText.Text = "Invalid username: only use alphanumeric characters\nor spaces," +
                    "and don't end with spaces.";
                error.ShowDialog();
                return;
            }
            if (newUsername.Length > 28)
            {
                error.tb_ErrorText.Text = "Invalid username: max length username is 32 characters.";
                error.ShowDialog();
                return;
            }
            Regex reserved = new Regex(@"^CON$|^PRN$|^AUX$|^NUL$|^COM[0-9]$|^LPT[0-9]", RegexOptions.IgnoreCase); // Windows reserved filenames
            if (reserved.IsMatch(newUsername))
            {
                error.tb_ErrorText.Text = "Invalid username: that filename is reserved by Windows.";
                error.ShowDialog();
                return;
            }
            if (Directory.Exists(Globals.dataDir + newUsername))
            {
                error.tb_ErrorText.Text = "User file already exists!";
                error.ShowDialog();
                return;
                
            }
            else
            {
                Directory.CreateDirectory(Globals.dataDir + newUsername);
                parent.loadDropdown();
                parent.userDropdown.SelectedItem = newUsername;
                this.Close();
            }

        }

        /// <summary>
        /// Deletes the default text of the CreateUser TextBox
        /// </summary>
        /// <param name="sender">the TextBox which is focused</param>
        /// <param name="e">the event arguments (unused)</param>
        private void enterField_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= enterField_GotFocus; // remove this handler (we only want to delete text on first focus)
        }
    }
}
