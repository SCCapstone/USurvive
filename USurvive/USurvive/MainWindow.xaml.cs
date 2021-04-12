
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
using System.Windows.Threading;
using Windows.UI.ViewManagement;

namespace USurvive
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private enum Selection
        {
            Home,
            Classes,
            Assignments,
            Gradebook
        }
        Sidebar sidebar;
        private Brush accent;
        public MainWindow()
        {
            InitializeComponent();
            Globals.tempClasses = new ObservableCollection<Class>();
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
            Globals.SidebarWidth = 200;
            SidebarColumn.Width = new GridLength(Globals.SidebarWidth);
            sidebar = new Sidebar();
            SidebarFrame.Navigate(sidebar);


            //Timer that calls tick every 200ms 
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 200);
            dispatcherTimer.Start();

            //Determine what color to paint the buttons
            var uiSettings = new UISettings();
            var accentColor = uiSettings.GetColorValue(UIColorType.Accent);
            accent = new SolidColorBrush(Color.FromArgb(accentColor.A, accentColor.R, accentColor.G, accentColor.B));

            //Check if accent color is dark.  If it is, we don't want to use it since it won't be easy to see
            if(accentColor.R <= 50 && accentColor.G <= 50 && accentColor.B <= 50)
            {
                accent = new SolidColorBrush(Color.FromArgb(accentColor.A, 0, 120, 215));
            }

            //Now opens to the Home View 
            HomeView homeView = new HomeView();
            Select(Selection.Home);
            NavigationFrame.Navigate(homeView);
            DatabaseSave.SaveDatabase();
        }

        /// <summary>
        /// checks if every classwork has passed its notification time and if it has and needs to notify it generates the notification. 
        /// </summary>
        void tick(object sender, EventArgs e)
        {
            foreach (Classwork cw in Globals.cwList.classwork)
            {
                if (!cw.ShownNotification && cw.NotificationTime != null && cw.NotificationTime <= DateTime.Now) 
                {
                    cw.ShowNotification();
                }

                if(cw.DueDate != null && DateTime.Now.AddDays(1) >= cw.DueDate && cw.AutoIncrement == true)
                {
                    cw.Priority = 1;
                }

                if(cw.DueDate != null && cw.AutoIncrement == true && cw.Priority >= 2)
                {
                    int lookAheadDays = cw.AutoIncrementDays * (cw.Priority - 1);
                    if(DateTime.Today.AddDays(lookAheadDays) >= cw.DueDate)
                    {
                        cw.Priority--;
                    }
                }
               
                
            }
            sidebar.refresh();
        }

        private void DebugClick(Object sender, RoutedEventArgs e)
        {
            DebugPanel debugPanel = new DebugPanel();
            debugPanel.Show();
        }

        private void Assignments_Click(object sender, RoutedEventArgs e)
        {
            AssignmentsView assignmentsView = new AssignmentsView();
            Select(Selection.Assignments);
            NavigationFrame.Navigate(assignmentsView);
        }

        private void Classes_Click(object sender, RoutedEventArgs e)
        {
            
            ClassesView classesView = new ClassesView();
            Select(Selection.Classes);
            NavigationFrame.Navigate(classesView);
        }
    
        private void Gradebook_Click(object sender, RoutedEventArgs e)
        {
            GradebookView gradebookView = new GradebookView();
            Select(Selection.Gradebook);
            NavigationFrame.Navigate(gradebookView);
        }
        
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            HomeView homeView = new HomeView();
            Select(Selection.Home);
            NavigationFrame.Navigate(homeView);
        }

        private void Select(Selection select)
        {
            /*Change colors of the buttons.
             * Unselected buttons are black
             * The selected button uses the Windows accent color.  If the color is dark (all RGB values below 60), use the default blue color
             */

            //Paint everything black
            Rect_Home.Fill = Brushes.Black;
            Rect_Classes.Fill = Brushes.Black;
            Rect_Assignments.Fill = Brushes.Black;
            Rect_Gradebook.Fill = Brushes.Black;

            switch (select)
            {
                case Selection.Home:
                    Rect_Home.Fill = accent;
                    break;

                case Selection.Classes:
                    Rect_Classes.Fill = accent;
                    break;

                case Selection.Assignments:
                    Rect_Assignments.Fill = accent;
                    break;

                case Selection.Gradebook:
                    Rect_Gradebook.Fill = accent;
                    break;
            }
            //Img_Assignments.
        }

        void DataWindow_Closing(object sender, EventArgs e)
        {
            //backWork.Abort();
            DatabaseSave.SaveDatabase();
            System.Windows.Application.Current.Shutdown();
        }

        //private void MainWindow_Resize(object sender, EventArgs e)
        //{
        //    Control control = (Control)sender;

        //    MainColumn.Width = new GridLength(control.RenderSize.Width - Globals.SidebarWidth);
        //}

    }


}
