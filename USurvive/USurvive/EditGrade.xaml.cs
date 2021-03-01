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
    /// Interaction logic for EditGrade.xaml
    /// </summary>
    public partial class EditGrade : Window
    {
        public Grade createdGrade { get; set; } = null; // property to expose to other windows
        public EditGrade()
        {
            InitializeComponent();
        }

        /// <summary>
        /// TODO: Generates edit dialouge with only one class option.
        /// </summary>
        /// <param name="cl">Class to be presented as only option.</param>
        public EditGrade(Class cl)
        {
            InitializeComponent();
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            //TODO: Save user input to a Grade object and add to Globals.gradebook
        }
    }
}
