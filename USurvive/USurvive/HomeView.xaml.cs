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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace USurvive
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : Page
    {
        public HomeView()
        {
            InitializeComponent();
            showCurrentClasses();
        }

        private void ChooseUser_Click(object sender, RoutedEventArgs e)
        {
            //UserSelection userSelection = new UserSelection();
            //userSelection.Show();
            //Window temp = new Window();
            //temp.Show();
            //NavigationFrame.Navigate(temp);
        }

        private void showCurrentClasses()
        {
            String names = "";
            foreach(Class newClass in Globals.clList.classes){
               names += (newClass.Name + "\n");
            }
            this.class_list.Text = names;
            
        }
    }
}
