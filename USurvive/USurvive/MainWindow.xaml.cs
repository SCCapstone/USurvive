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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Globals.tempClasses = new List<Class>();
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
                Console.WriteLine(clas);
            }
            buttonShowClass.Content = "Written to console log";
        }
    }


}
