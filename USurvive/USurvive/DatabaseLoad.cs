using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace USurvive
{
    public static class DatabaseLoad
    {
        public static void LoadDatabase()
        {
            LoadClasses();
            LoadWork();
            LoadGrades();
        }

        public static void LoadClasses()
        {
            string classFile = Globals.dataDir + Globals.databaseName + "classes.json";

            string hashFile = classFile + ".md5";
            byte[] verifyHash;

            try
            {
                verifyHash = File.ReadAllBytes(hashFile);
            } catch (FileNotFoundException)
            {
                verifyHash = new byte[] { 0x00 };
            }

            byte[] hash;

            if (File.Exists(classFile))
            {
                using (MD5 md5 = MD5.Create())
                {
                    using (FileStream stream = File.OpenRead(classFile))
                    {
                        hash = md5.ComputeHash(stream);
                        hashFile = classFile + ".md5";
                        //File.WriteAllBytes(hashFile, hash);
                    }
                }

                bool corrupt = false;
                if (hash.Length == verifyHash.Length)
                {
                    for (int i = 0; i < hash.Length; ++i)
                    {
                        if (hash[i] != verifyHash[i])
                            corrupt = true;
                    }
                }
                else corrupt = true;

                if (corrupt)
                {
                    Error error = new Error();
                    error.tb_ErrorText.Text = classFile + " is corrupt!  Attempting to load anyway.";
                    error.Show();
                }

                string[] jsonLines = File.ReadAllLines(classFile);

                foreach (string jsonLine in jsonLines)
                {
                    Globals.clList.AddClass(JsonSerializer.Deserialize<Class>(jsonLine));
                }
            }
        }

        public static void LoadWork()
        {
            string workFile = Globals.dataDir + Globals.databaseName + "work.json";

            string hashFile = workFile + ".md5";
            byte[] verifyHash;

            if (File.Exists(workFile))
            {

                try
                {
                    verifyHash = File.ReadAllBytes(hashFile);
                }
                catch (FileNotFoundException)
                {
                    verifyHash = new byte[] { 0x00 }; ;
                }
                byte[] hash;

                using (MD5 md5 = MD5.Create())
                {
                    using (FileStream stream = File.OpenRead(workFile))
                    {
                        hash = md5.ComputeHash(stream);
                        hashFile = workFile + ".md5";
                        //File.WriteAllBytes(hashFile, hash);
                    }
                }

                bool corrupt = false;
                if (hash.Length == verifyHash.Length)
                {
                    for (int i = 0; i < hash.Length; ++i)
                    {
                        if (hash[i] != verifyHash[i])
                            corrupt = true;
                    }
                }
                else corrupt = true;

                if (corrupt)
                {
                    Error error = new Error();
                    error.tb_ErrorText.Text = workFile + " is corrupt!  Attempting to load anyway.";
                    error.Show();
                }

                string[] jsonLines = File.ReadAllLines(workFile);

                foreach (string jsonLine in jsonLines)
                {
                    Globals.clList.AddClass(JsonSerializer.Deserialize<Class>(jsonLine));
                }
            }
        }

        public static void LoadGrades()
        {
            string gradeFile = Globals.dataDir + Globals.databaseName + "grade.json";

            string hashFile = gradeFile + ".md5";
            byte[] verifyHash;

            if (File.Exists(gradeFile))
            {
                try
                {
                    verifyHash = File.ReadAllBytes(hashFile);
                }
                catch (FileNotFoundException)
                {
                    verifyHash = new byte[] { 0x00 }; ;
                }
                byte[] hash;

                using (MD5 md5 = MD5.Create())
                {
                    using (FileStream stream = File.OpenRead(gradeFile))
                    {
                        hash = md5.ComputeHash(stream);
                        hashFile = gradeFile + ".md5";
                        //File.WriteAllBytes(hashFile, hash);
                    }
                }

                bool corrupt = false;
                if (hash.Length == verifyHash.Length)
                {
                    for (int i = 0; i < hash.Length; ++i)
                    {
                        if (hash[i] != verifyHash[i])
                            corrupt = true;
                    }
                }
                else corrupt = true;

                if (corrupt)
                {
                    Error error = new Error();
                    error.tb_ErrorText.Text = gradeFile + " is corrupt!  Attempting to load anyway.";
                    error.Show();
                }
                string[] jsonLines = File.ReadAllLines(gradeFile);

                foreach (string jsonLine in jsonLines)
                {
                    Globals.clList.AddClass(JsonSerializer.Deserialize<Class>(jsonLine));
                }
            }
        }
    }
}
