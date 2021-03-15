using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace USurvive
{
    static class Globals
    {
        public static System.Collections.ObjectModel.ObservableCollection<Class> tempClasses;
        //Will be intialized when MainWindow loads
        public static String dataDir;
        public static String databaseName;

        public static String workingDir;

        public static List<Assignment> tempAssignments;


        //List objects
        public static ClassworkList cwList;
        public static GradeList gradebook;
        public static ClassList clList;

        public static int SidebarWidth;

        
    }

    
}
