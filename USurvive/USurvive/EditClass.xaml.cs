﻿using System;
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
using System.Collections.ObjectModel;

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
            cmbGradeScale.SelectedIndex = 0;
            cmbClassType.SelectedIndex = 0; 
        }

        public EditClass(Class cl)
        {
            InitializeComponent();
            this.clas = cl;
            tbName.Text = cl.Name;
            tbInstructor.Text = cl.Instructor;
            tbCreditHours.Text = cl.CreditHours.ToString();
            try {
                tbInstEmail.Text = cl.InstructorEmailContent;
            } catch(NullReferenceException) {
                tbInstEmail.Text = "";
            }
            try {
                tbWebsite.Text = cl.ClassWebsiteContent;
            } catch(NullReferenceException) {
                tbWebsite.Text = "";
            }
            if (cl.GradeScale.pointIncrement == 7)
                cmbGradeScale.SelectedIndex = 1;
            else if (cl.GradeScale.pointIncrement == 10)
                cmbGradeScale.SelectedIndex = 0;
            tbNotes.Text = cl.Notes;
            tempSyllabus = cl.Syllabus;
            clas.MeetingTimes = cl.MeetingTimes;
            cmbClassType.SelectedIndex = cl.ClassType;
            
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

            if (clas != null) // this block runs only when editing an existing class
            {
                // Change class name (Cl) of classwork from old to new name
                foreach (var cw in Globals.cwList.classwork)
                {
                    if (cw.Cl != null && cw.Cl.Equals(clas.Name))
                    {
                        cw.Cl = name;
                    }
                }

                // Change ClassName of grades from old to new name
                foreach (var g in Globals.gradebook.grades)
                {
                    if (g.ClassName.Equals(clas.Name))
                    {
                        g.ClassName = name;
                    }
                }
            }

            // Ensure name is unique
            foreach (Class c in Globals.clList.classes)
            {
                if (c.Name.Equals(name))
                {
                    Error nameErr = new Error();
                    nameErr.tb_ErrorText.Text = "Class with that name already exists!";
                    nameErr.ShowDialog();
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
                Error nameErr = new Error();
                nameErr.tb_ErrorText.Text = "Please enter a valid number of credit hours.";
                nameErr.ShowDialog();
                return; // Stop saving so user can change credit hours.
            } catch (System.OverflowException)
            {
                Error nameErr = new Error();
                nameErr.tb_ErrorText.Text = "Too many credit hours, enter a valid number";
                nameErr.ShowDialog();
                return; // Stop saving so user can change credit hours.
            }

            foreach (var g in Globals.gradebook.grades)
            {
                if (g.ClassName.Equals(name))
                {
                    g.Hours = CreditHours;
                }
            }

            Uri ClassWebsite;
            Uri InstEmail;

            if (tbWebsite.Text == "")
                ClassWebsite = null;
            else
            {
                try
                {
                    ClassWebsite = new Uri("http://" + tbWebsite.Text + "/");
                }
                catch (UriFormatException)
                {
                    Error error = new Error();
                    error.tb_ErrorText.Text = "Please enter a vaild web address.";
                    error.ShowDialog();
                    return; // Stop saving so user can fix input
                }
                if (ClassWebsite.Scheme != Uri.UriSchemeHttp)
                {
                    Error error = new Error();
                    error.tb_ErrorText.Text = "Please enter a vaild web address.";
                    error.ShowDialog();
                    return; // Stop saving so user can fix input
                }
            }

            if (tbInstEmail.Text == "")
                InstEmail = null;
            else
            {
                try
                {
                    InstEmail = new Uri("mailto:" + tbInstEmail.Text);
                }
                catch (UriFormatException)
                {
                    Error error = new Error();
                    error.tb_ErrorText.Text = "Please enter a vaild email adress.";
                    error.ShowDialog();
                    return; // Stop saving so user can fix input
                }
                if (InstEmail.Scheme != Uri.UriSchemeMailto)
                {
                    Error error = new Error();
                    error.tb_ErrorText.Text = "Please enter a vaild email adress.";
                    error.ShowDialog();
                    return; // Stop saving so user can fix input
                }
            }

            int scaleIdxSelected;
            GradeScale gradeScale;
            try
            {
                scaleIdxSelected = cmbGradeScale.SelectedIndex;
            }
            catch (NullReferenceException)  // shouldn't happen as combobox defaults to 10 point
            {
                Error noScaleErr = new Error();
                noScaleErr.tb_ErrorText.Text = "Select a grade scale.";
                noScaleErr.Show();
                return;  // Quit saving so user can select a grade scale.
            }
            if (scaleIdxSelected == 0)
                gradeScale = new GradeScale(10, 0); // what is rounding type zero?
            else
                gradeScale = new GradeScale(7, 0);
            // Custom gradescales not supported (yet?).

            Syllabus syllabus = tempSyllabus;
            int classType = cmbClassType.SelectedIndex;
            String notes = tbNotes.Text;

            ObservableCollection<MeetingTime> meetingTimes;
            //Two cases Case 1: class is null (no meeting time object) Case 2: 
            try
            {
                 meetingTimes = clas.MeetingTimes;
            }
            catch (NullReferenceException)
            {
                meetingTimes = new ObservableCollection<MeetingTime>(); // empty collection 
            }
            Globals.clList.AddClass(new Class(name, instructor, CreditHours, InstEmail, ClassWebsite, syllabus, classType, notes, meetingTimes, gradeScale));
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
                tempSyllabus = new Syllabus(openDialog.FileName);
            }
        }

        private void EditMeetingsClick(object sender, RoutedEventArgs e)
        {
            if (clas == null)
            {
                clas = new Class(null,null,0,null,null,null,0,null,null,null);
                clas.MeetingTimes = new System.Collections.ObjectModel.ObservableCollection<MeetingTime>();
            }
            EditMeetingTime mt = new EditMeetingTime(clas);
            if (mt.ShowDialog() == true)
            {
                clas.MeetingTimes = mt.clas.MeetingTimes;
            }
        }
    }
}
    