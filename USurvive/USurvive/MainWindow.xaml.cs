﻿using System;
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
            }
            //Add final '\' to place path inside %AppData%/USurvive
            Globals.dataDir += "\\";

            //Load databases
            DatabaseLoad.LoadClasses();//Load the classes database

            //Set up sidebar
            Sidebar sidebar = new Sidebar();
            SidebarFrame.Navigate(sidebar);

            //For now, open to the Classes view.  Eventually this will open to the Today view once that is implemented
            ClassesView classesView = new ClassesView();
            NavigationFrame.Navigate(classesView);
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

        void DataWindow_Closing(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }


}
