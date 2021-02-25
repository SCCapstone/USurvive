using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace USurvive
{
    /// <summary>
    /// Interaction logic for EditClass.xaml
    /// </summary>
    public partial class EditClass : Window
    {
        Syllabus tempSyllabus = null;
        Class clas;

        public EditClass()
        {
            InitializeComponent();
        }

        public EditClass(Class cl)
        {
            InitializeComponent();
            this.clas = cl;
            tbName.Text = cl.Name;
            tbInstructor.Text = cl.Instructor;
            tbCreditHours.Text = cl.CreditHours.ToString();
            try {
                tbInstEmail.Text = cl.InstructorEmail.ToString();
            } catch(NullReferenceException) {
                tbInstEmail.Text = "";
            }
            try {
                tbWebsite.Text = cl.ClassWebsite.ToString();
            } catch(NullReferenceException e) {
                tbWebsite.Text = "";
            }
            tbNotes.Text = cl.Notes;
            tempSyllabus = cl.Syllabus;
        }


        //https://stackoverflow.com/a/12721673
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            String name = tbName.Text;
            Globals.clList.classes.Remove(clas);
            foreach (Class clas in Globals.clList.classes)
            {
                if (clas.Name.Equals(name))
                {
                    Error nameErr = new Error();
                    nameErr.tb_ErrorText.Text = "Class with that name already exists!";
                    nameErr.Show();
                    return; // Stop saving so user can change name.
                }
            }
            String instructor = tbInstructor.Text;
            int CreditHours;
            try
            {
              CreditHours = int.Parse(tbCreditHours.Text);
            } catch (System.FormatException)
            {
                //*******************************************
                //*                                         *
                //*          TEMPORARY SOLUTION!!           *
                //*                                         *
                //*******************************************
                CreditHours = 0;
            }
            Uri ClassWebsite;
            Uri InstEmail;
            try
            {
                ClassWebsite = new Uri("http://" + tbWebsite.Text + "/");
                InstEmail = new Uri("mailto:" + tbInstEmail.Text);
            } catch
            {
                //*******************************************
                //*                                         *
                //*          TEMPORARY SOLUTION!!           *
                //*                                         *
                //*******************************************

                Error error = new Error();
                error.tb_ErrorText.Text = "Website or email URI was invalid!  Setting to null.";
                error.Show();
                ClassWebsite = null;
                InstEmail = null;
            }
            Syllabus syllabus = tempSyllabus;
            int classType = 0;
            String notes = tbNotes.Text;
            List<MeetingTime> meetingTimes = null;
            Globals.clList.AddClass(new Class(name, instructor, CreditHours, InstEmail, ClassWebsite, syllabus, classType, notes, meetingTimes));
            //Console.WriteLine(Globals.tempClasses[0]);
            this.Close();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            //Close the window.  Don't bother saving.
            this.Close();
        }

        private void AddSyllabusClick(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openDialog = new Microsoft.Win32.OpenFileDialog();
            bool? result = openDialog.ShowDialog();
            if (result == true)
            {
                tempSyllabus     = new Syllabus(openDialog.FileName);
            }
        }
    }
}
    