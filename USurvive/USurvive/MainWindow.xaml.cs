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
            NavigationService service = NavigationService.GetNavigationService(NavigationFrame);

            //Set up dataDir varaiable
            Globals.dataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Globals.dataDir += "\\USurvive";
            //Set up data directory
            if (!Directory.Exists(Globals.dataDir))
            {
                //Create data dir in AppData
                Directory.CreateDirectory(Globals.dataDir);
            }
            //Add final '\' to place path inside %AppData%/USurvive
            Globals.dataDir += "\\";
        }
        private void DebugClick(Object sender, RoutedEventArgs e)
        {
            DebugPanel debugPanel = new DebugPanel();
            debugPanel.Show();
        }

        private void Assignments_Click(object sender, RoutedEventArgs e)
        {
            AssignmentsView classes = new AssignmentsView();
            NavigationFrame.Navigate(classes);
        }

        private void Classes_Click(object sender, RoutedEventArgs e)
        {
            
            ClassesView classes = new ClassesView();
            NavigationFrame.Navigate(classes);
            /*
            Classes classesWindow = new Classes();
            classesWindow.Show();
            */
        }
    
        private void Gradebook_Click(object sender, RoutedEventArgs e)
        {
            GradebookView classes = new GradebookView();
            NavigationFrame.Navigate(classes);
        }

        void DataWindow_Closing(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }


}
