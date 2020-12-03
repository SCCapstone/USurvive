using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Sidebar.xaml
    /// </summary>
    public partial class Sidebar : Page
    {
        ObservableCollection<Class> classList;
        public Sidebar()
        {
            InitializeComponent();

            classList = new ObservableCollection<Class>();
            foreach (Class newClass in Globals.tempClasses)
            {
                classList.Add(newClass);
            }
            dgClassList.DataContext = classList;
            
        }

        private void RefreshClick(object sender, RoutedEventArgs e)
        {
            classList = new ObservableCollection<Class>();
            foreach (Class newClass in Globals.tempClasses)
            {
                classList.Add(newClass);
            }
            dgClassList.DataContext = classList;
        }
    }
}
