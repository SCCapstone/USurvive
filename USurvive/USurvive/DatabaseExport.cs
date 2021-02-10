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
            Microsoft.Win32.OpenFileDialog openDialog = new Microsoft.Win32.OpenFileDialog();
            openDialog.DefaultExt = ".usurvive";
            openDialog.Filter = "USurvive Database Files (.usurvive)|*.usurvive";

            bool? result = openDialog.ShowDialog();

            if(result == true)
            {
                //Windows won't let us open a file that doesn't exist, so assume it exists.
                string filename = openDialog.FileName;
                ZipFile.ExtractToDirectory(filename, Globals.dataDir + "tempDir");//Extract to a working directory.  This will be deleted when we are done.

                if (!File.Exists(Globals.dataDir + "tempDir\\dbname"))
                {
                    //Database is invalid
                    //Show a message saying the database is corrupt (missing dbname file)
                    //TODO: Show a message saying the database is corrupt
                    Directory.Delete(Globals.dataDir + "tempDir", true);
                    return false;
                }
                string[] databaseName = File.ReadAllLines(Globals.dataDir + "tempDir\\dbname");
                string databaseString;
                if (databaseName.Length == 1)//Ensure database file is somewhat correct
                {
                    databaseString = databaseName[0];
                    while (Directory.Exists(Globals.dataDir + databaseString))
                    {
                        //Globals.databaseName = databaseString;
                        //Our directory already exists
                        databaseString = databaseString.Replace("\\", "");
                        databaseString += "-duplicate\\";
                    }
                }
                else
                {
                    Directory.Delete(Globals.dataDir + "tempDir", true);
                    return false;
                }
                //We have the data we need, delete the temporary directory
                Directory.Delete(Globals.dataDir + "tempDir", true);

                //Create the new directory
                Directory.CreateDirectory(Globals.dataDir + databaseString);
                ZipFile.ExtractToDirectory(filename, Globals.dataDir + databaseString);
                File.Delete(Globals.dataDir + databaseString + "dbname");//Delete name file
                return true;





            }

            return false;
        }
    }
}
