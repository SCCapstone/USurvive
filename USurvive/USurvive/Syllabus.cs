using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USurvive
{
    public class Syllabus
    {
        public string fileName { get; set; }
        public string uiName { get; set; }
        
        /** Deserialization only allows one constructor when there is no constructor with zero arguments!
        public Syllabus(string fileName, string uiName)
        {
            //Verify that the file exists
            if (File.Exists(fileName))
            {
                //Copy the file into the syllabus directory
                string[] fileNameSplit = fileName.Split('\\');//Split the file name.  NTFS doesn't allow '\' to be used in filenames, so this is safe

                while (File.Exists(Globals.workingDir + "syllabus\\" + fileNameSplit[fileNameSplit.Length - 1]))
                {
                    //Eventually this can cause an issue with NTFS.  Solution: Avoid making a bunch of files with the same filename.
                    string[] splitName = fileNameSplit[fileNameSplit.Length - 1].Split('.');
                    splitName[splitName.Length - 2] += "-duplicate";
                    fileNameSplit[fileNameSplit.Length - 1] = "";

                    foreach (string str in splitName)
                    {
                        fileNameSplit[fileNameSplit.Length - 1] += str;
                    }
                }

                File.Copy(fileName, Globals.workingDir + "syllabus\\" + fileNameSplit[fileNameSplit.Length - 1]);
                this.fileName = Globals.workingDir + "syllabus\\" + fileNameSplit[fileNameSplit.Length - 1];
            }

            else
            {
                //This SHOULD never happen.  SHOULD.

                //Show error dialog
                Error error = new Error();
                error.tb_ErrorText.Text = "Syllabus does not exist on the filesystem!";
                error.Show();
                return;
            }

            this.uiName = uiName;
        }
        */

        public Syllabus(string fileName)
        {

            //Verify that the file exists
            if (File.Exists(fileName))
            {
                //Copy the file into the syllabus directory
                string[] fileNameSplit = fileName.Split('\\');//Split the file name.  NTFS doesn't allow '\' to be used in filenames, so this is safe

                while (File.Exists(Globals.workingDir + "syllabus\\" + fileNameSplit[fileNameSplit.Length - 1]))
                {
                    //Eventually this can cause an issue with NTFS.  Solution: Avoid making a bunch of files with the same filename.
                    string[] splitName = fileNameSplit[fileNameSplit.Length - 1].Split('.');
                    splitName[splitName.Length - 2] += "-duplicate";
                    splitName[splitName.Length - 1] = "." + splitName[splitName.Length - 1];
                    fileNameSplit[fileNameSplit.Length - 1] = "";

                    foreach (string str in splitName) {
                        fileNameSplit[fileNameSplit.Length - 1] += str;
                    }
                }

                File.Copy(fileName, Globals.workingDir + "syllabus\\" + fileNameSplit[fileNameSplit.Length - 1]);
                this.fileName = Globals.workingDir + "syllabus\\" + fileNameSplit[fileNameSplit.Length - 1];
            }
            else
            {
                //This SHOULD never happen.  SHOULD.

                //Show error dialog
                Error error = new Error();
                error.tb_ErrorText.Text = "Syllabus does not exist on the filesystem!";
                error.Show();
                return;
            }
            this.uiName = "Untitled Syllabus";
        }

        public void OpenSyllabus()
        {
            //Open syllabus file
            //Verify that syllabus still exists
            if (File.Exists(this.fileName))
            {
                System.Diagnostics.Process.Start(this.fileName);//Open the file with default system application.  This will specify the user to select an application if one isn't set
            }
            else
            {
                //Show error dialog
                Error error = new Error();
                error.tb_ErrorText.Text = "Syllabus does not exist on the filesystem!";
                error.Show();
                return;
            }
        }
    }
}
