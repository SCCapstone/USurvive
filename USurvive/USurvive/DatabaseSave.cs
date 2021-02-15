using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace USurvive
{
    public static class DatabaseSave
    {
        //TODO: Split this into multiple methods, so individual databases can be saved without writing everything to disk again
        public static bool SaveDatabase()
        {
            string classFile = Globals.dataDir + Globals.databaseName + "classes.json";
            string workFile = Globals.dataDir + Globals.databaseName + "work.json";
            string gradeFile = Globals.dataDir + Globals.databaseName + "grade.json";
            string hashFile = Globals.dataDir + Globals.databaseName + "hashes";

            //Create backup files
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

            bakFile = workFile + ".bak";
            if (File.Exists(workFile))
            {
                //Create backup file
                if (File.Exists(bakFile))
                {
                    //Backup already exists, delete it
                    File.Delete(bakFile);
                }
                File.Copy(workFile, bakFile);
                //Delete file
                File.Delete(workFile);
            }

            bakFile = gradeFile + ".bak";
            if (File.Exists(gradeFile))
            {
                //Create backup file
                if (File.Exists(bakFile))
                {
                    //Backup already exists, delete it
                    File.Delete(bakFile);
                }
                File.Copy(gradeFile, bakFile);
                //Delete file
                File.Delete(gradeFile);
            }


            using (System.IO.StreamWriter fileOutput = new System.IO.StreamWriter(classFile, true))
            {
                foreach(Class clas in Globals.clList.classes)
                {
                    fileOutput.WriteLine(clas.ToJson());
                }
            }

            using (System.IO.StreamWriter fileOutput = new System.IO.StreamWriter(workFile, true))
            {
                foreach(Classwork work in Globals.cwList.classwork)
                {
                    fileOutput.WriteLine(work.ToJson());
                }
            }

            using (System.IO.StreamWriter fileOutput = new System.IO.StreamWriter(gradeFile, true))
            {
                foreach (Grade grade in Globals.gradebook.grades)
                {
                    fileOutput.WriteLine(grade.ToJson());
                }
            }


            //Generate checksums
            //MD5 isn't secure, but it's good enough to make sure files aren't corrupted at some point

            //https://stackoverflow.com/a/10520086
            using (MD5 md5 = MD5.Create())
            {
                byte[] hash;
                using (FileStream stream = File.OpenRead(classFile))
                {
                    hash = md5.ComputeHash(stream);
                    hashFile = classFile + ".md5";
                    if(File.Exists(hashFile))
                        File.Delete(hashFile);
                    File.WriteAllBytes(hashFile, hash);
                }
                using (FileStream stream = File.OpenRead(workFile))
                {
                    hash = md5.ComputeHash(stream);
                    hashFile = workFile + ".md5";
                    if (File.Exists(hashFile))
                        File.Delete(hashFile);
                    File.WriteAllBytes(hashFile, hash);
                }
                using (FileStream stream = File.OpenRead(gradeFile))
                {
                    hash = md5.ComputeHash(stream);
                    hashFile = gradeFile + ".md5";
                    if (File.Exists(hashFile))
                        File.Delete(hashFile);
                    File.WriteAllBytes(hashFile, hash);
                }
            }

            return true;
        }
    }
}
