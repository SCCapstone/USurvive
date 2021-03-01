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
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace USurvive
{
    /// <summary>
    /// Interaction logic for ClassOverview.xaml
    /// </summary>
    public partial class ClassOverview : Window
    {
        ObservableCollection<Classwork> classworkList;
        ObservableCollection<Grade> grades;
        Class clas;
        ObservableCollection<Classwork> uncompletedClasswork;
        ObservableCollection<Classwork> uncompletedAssessments;
        public ClassOverview(Class source)
        {
            InitializeComponent();
            this.clas = source;
            classNameText.Text = source.Name;
            classworkList = Globals.cwList.classwork;
            grades = Globals.gradebook.grades;
            uncompletedClasswork = new ObservableCollection<Classwork>();
            uncompletedAssessments = new ObservableCollection<Classwork>();

            foreach (Classwork work in classworkList)
            {
                if (work.Cl != null && work.Cl.Equals(source.Name))
                {
                    if (work.Completed == false && work.Type == ClassworkType.Assignment)
                        uncompletedClasswork.Add(work);
                    else if (work.Completed == false && work.Type == ClassworkType.Assessment)
                        uncompletedAssessments.Add(work);
                }
            }

            float totGrade = -1;
            foreach (Grade grade in grades)
            {
                // don't grade assignments worth zero points or not in this class
                if ( grade.ClassName != null && grade.ClassName.Equals(source.Name) && grade.MaxPoints != 0)  
                {
                    if (totGrade == -1)    
                        totGrade = grade.GradeWeight * (grade.PointsEarned/grade.MaxPoints);
                    else
                        totGrade += grade.GradeWeight * (grade.PointsEarned / grade.MaxPoints);
                }
            }

            if (totGrade == -1)
                gradeText.Text = "Nothing scorable assigned yet.";  // here scorable means with a MaxPoints greater than zero
            else
                gradeText.Text = "" + totGrade; 
            dgUncompletedAssignments.DataContext = uncompletedClasswork;
            dgUncompletedAssessments.DataContext = uncompletedAssessments;

            tbMeetingTimes.Text = clas.MtsDisp;
        }

        private void addAssignmentClick(object sender, RoutedEventArgs e)
        {
            EditAssignment editWin = new EditAssignment(clas);
            editWin.ShowDialog();
            if (editWin.createdCW != null)
                uncompletedClasswork.Add(editWin.createdCW);
        }

        private void addGradeClick(object sender, RoutedEventArgs e)
        {
            EditGrade editWin = new EditGrade(clas);
            editWin.ShowDialog();
        }

        private void viewSyllabusClick(object sender, RoutedEventArgs e)
        {
            try
            {
                clas.Syllabus.OpenSyllabus();
            }
            catch (NullReferenceException)
            {
                Error err = new Error();
                err.tb_ErrorText.Text = "This class has no Syllabus";
                err.Show();
            }
        }

        private void EmailInstructorClick(object sender, RoutedEventArgs e)
        {
            if (clas.InstructorEmail == null)
            {
                Error noEmailErr = new Error();
                noEmailErr.tb_ErrorText.Text = "No associated email.";
                noEmailErr.ShowDialog();
                return;
            }
            var uri = clas.InstructorEmail.ToString();
            Process.Start(uri);
        }
    }
}
