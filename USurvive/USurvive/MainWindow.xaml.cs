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
using System.Collections.ObjectModel;
using System.Threading;

namespace USurvive
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Thread backWork;
        public MainWindow()
        {
            InitializeComponent();
            Globals.tempClasses = new System.Collections.ObjectModel.ObservableCollection<Class>();
            Globals.tempAssignments = new List<Assignment>();
            //NavigationService service = NavigationService.GetNavigationService(NavigationFrame);
            
            
            //Set up dataDir varaiable
            Globals.dataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Globals.dataDir += "\\USurvive";
            //Set up data directory
            if (!Directory.Exists(Globals.dataDir))
            {
                //Create data dir in AppData
                Directory.CreateDirectory(Globals.dataDir);
                //Create default database directory
                Directory.CreateDirectory(Globals.dataDir + "\\default");
            }
            //Add final '\' to place path inside %AppData%/USurvive
            Globals.dataDir += "\\";

            Globals.databaseName = "default";
            //Check for different database setting
            if (File.Exists(Globals.dataDir+"databaseSetting"))
            {
                string[] databaseName = File.ReadAllLines(Globals.dataDir + "databaseSetting");
                if (databaseName.Length == 1)//Ensure database file is somewhat correct
                {
                    string databaseString = databaseName[0];
                    if (Directory.Exists(Globals.dataDir + databaseString))
                        Globals.databaseName = databaseString;
                }
            }

            //Add final '\' to path
            Globals.databaseName += "\\";

            //Ensure a directory exists
            if (!Directory.Exists(Globals.dataDir + Globals.databaseName))
            {
                //Display message saying database is corrupt
                //TODO: Display message saying database is corrupt

                //Ask user to choose new database file

                //Create new folder if none exist
                Directory.CreateDirectory(Globals.dataDir + Globals.databaseName);
            }


            //Make sure temporary directory doesn't exist
            if (Directory.Exists(Globals.dataDir + "\\tempDir"))
                Directory.Delete(Globals.dataDir + "\\tempDir", true);
            
            //Set up working dir variable
            Globals.workingDir = Globals.dataDir + Globals.databaseName;

            //Ensure syllabus folder exists
            if (!Directory.Exists(Globals.workingDir + "syllabus")){
                Directory.CreateDirectory(Globals.workingDir + "syllabus");
            }

            Globals.clList = new ClassList();
            Globals.cwList = new ClassworkList();
            Globals.gradebook = new GradeList();

            //Load databases
            DatabaseLoad.LoadDatabase();//Load the database
            
            if(Globals.cwList == null)
            {
                Globals.cwList = new ClassworkList();
            }

            //Set up sidebar
            Sidebar sidebar = new Sidebar();
            SidebarFrame.Navigate(sidebar);


            //Start background work thread
            backWork = new Thread(BackgroundTasks.backWork);
            backWork.SetApartmentState(ApartmentState.STA);
            backWork.Start();

            //Now opens to the Home View 
            HomeView homeView = new HomeView();
            NavigationFrame.Navigate(homeView);
            DatabaseSave.SaveDatabase();
        }
        private void DebugClick(Object sender, RoutedEventArgs e)
        {
            DebugPanel debugPanel = new DebugPanel();
            debugPanel.Show();
        }

        private void Assignments_Click(object sender, RoutedEventArgs e)
        {
            AssignmentsView assignmentsView = new AssignmentsView();
            NavigationFrame.Navigate(assignmentsView);
        }

        private void Classes_Click(object sender, RoutedEventArgs e)
        {
            
            ClassesView classesView = new ClassesView();
            NavigationFrame.Navigate(classesView);
            /*
            Classes classesWindow = new Classes();
            classesWindow.Show();
            */
        }
    
        private void Gradebook_Click(object sender, RoutedEventArgs e)
        {
            GradebookView gradebookView = new GradebookView();
            NavigationFrame.Navigate(gradebookView);
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            HomeView homeView = new HomeView();
            NavigationFrame.Navigate(homeView);
        }

        void DataWindow_Closing(object sender, EventArgs e)
        {
            backWork.Abort();
            System.Windows.Application.Current.Shutdown();
        }


    }


}
