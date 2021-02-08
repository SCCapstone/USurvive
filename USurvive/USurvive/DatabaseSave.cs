using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace USurvive
{
    public static class DatabaseSave
    {
        public static bool SaveClasses()
        {
            string classFile = Globals.dataDir + Globals.databaseName + "classes.json";
            string bakFile = classFile + ".bak";
            if (File.Exists(classFile))
            {
                //Create backup file
                if (File.Exists(bakFile))
                {
                    //Backup already exists, delete it
                    File.Delete(bakFile);
                }
                File.Copy(classFile, bakFile);
                //Delete file
                File.Delete(classFile);
            }
            using (System.IO.StreamWriter fileOutput = new System.IO.StreamWriter(classFile, true))
            {
                foreach(Class clas in Globals.tempClasses)
                {
                    fileOutput.WriteLine(clas.ToJson());
                }
            }

            return false;
        }
    }
}
