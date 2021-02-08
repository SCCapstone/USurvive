using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;

namespace USurvive
{
    public class DatabaseExport
    {
        public static bool ExportDatabase()
        {
            Microsoft.Win32.SaveFileDialog saveDialog = new Microsoft.Win32.SaveFileDialog(); //https://stackoverflow.com/a/5623071
            saveDialog.FileName = "USurvive Database - " + Globals.databaseName.Replace("\\","") + " - " + DateTime.Now.ToString("yyyy-MM-dd"); //https://stackoverflow.com/a/115002
            saveDialog.DefaultExt = ".usurvive";
            saveDialog.Filter = "USurvive Database Files (.usurvive)|*.usurvive";

            bool? result = saveDialog.ShowDialog();

            if (result == true)
            {
                string filename = saveDialog.FileName;
                //Create file containing database name
                using (System.IO.StreamWriter fileOutput = new System.IO.StreamWriter(Globals.dataDir + Globals.databaseName + "dbname"))
                    fileOutput.WriteLine(Globals.databaseName);
                //Delete the existing file.  Windows has already gotten permission for us. 
                if (File.Exists(filename))
                    File.Delete(filename);
                
                ZipFile.CreateFromDirectory(Globals.dataDir + Globals.databaseName.Replace("\\", ""), filename);
                File.Delete(Globals.dataDir + Globals.databaseName + "dbname");
                return true;
            }
            return false;
        }

        public static bool ImportDatabase()
        {
            return false;
        }
    }
}
