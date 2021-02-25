using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace USurvive
{
    /// <summary>
    /// Interaction logic for GradebookView.xaml
    /// </summary>
    public partial class GradebookView : Page
    {
        System.Collections.ObjectModel.ObservableCollection<Grade> grades;
        public GradebookView()
        {
            InitializeComponent();

            DG1.DataContext = Globals.gradebook.grades;
            GPACalculator gPAViewer = new GPACalculator();
            int totalcredits = 0;
            double totalgradeweight = 0;


            foreach (Grade grade in Globals.gradebook.grades)
            {
                grade.UGrade = (int)(((double)grade.PointsEarned / (double)grade.MaxPoints) * 100);
                if (grade.UGrade >= 90)
                {
                    gPAViewer.tbGPA.Text += grade.ClassName;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "4.0\r\n";
                    totalgradeweight += grade.Hours * 4.0;
                }
                if (grade.UGrade >= 87 && grade.UGrade < 90)
                {
                    gPAViewer.tbGPA.Text += grade.ClassName;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "3.5\r\n";
                    totalgradeweight += grade.Hours * 3.5;
                }
                if (grade.UGrade >= 80 && grade.UGrade < 87)
                {
                    gPAViewer.tbGPA.Text += grade.ClassName;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "3.0\r\n";
                    totalgradeweight += grade.Hours * 3.0;
                }
                if (grade.UGrade >= 77 && grade.UGrade < 80)
                {
                    gPAViewer.tbGPA.Text += grade.ClassName;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "2.5\r\n";
                    totalgradeweight += grade.Hours * 2.5;
                }
                if (grade.UGrade >= 70 && grade.UGrade < 77)
                {
                    gPAViewer.tbGPA.Text += grade.ClassName;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "2.0\r\n";
                    totalgradeweight += grade.Hours * 2.0;
                }
                if (grade.UGrade >= 67 && grade.UGrade < 70)
                {
                    gPAViewer.tbGPA.Text += grade.ClassName;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "1.5\r\n";
                    totalgradeweight += grade.Hours * 1.5;
                }
                if (grade.UGrade >= 60 && grade.UGrade < 67)
                {
                    gPAViewer.tbGPA.Text += grade.ClassName;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "1.0\r\n";
                    totalgradeweight += grade.Hours * 1.0;
                }
                if (grade.UGrade < 60)
                {
                    gPAViewer.tbGPA.Text += grade.ClassName;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "0\r\n";
                    totalgradeweight += grade.Hours * 0.0;
                }
                totalcredits += grade.Hours;
            }
            double semestergpa = totalgradeweight / totalcredits;
            tbSGPA.Text = semestergpa.ToString();

        }
        private void DisplayGPA(object sender, RoutedEventArgs e)
        {
            GPACalculator gPAViewer = new GPACalculator();
            int totalcredits = 0;
            double totalgradeweight = 0;
            double gpa = 0;

            foreach (Grade grade in Globals.gradebook.grades)
            {
                grade.UGrade = (int)(((double)grade.PointsEarned / (double)grade.MaxPoints) * 100);
                if (grade.UGrade >= 90)
                {
                    gPAViewer.tbGPA.Text += grade.ClassName;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "4.0\r\n";
                    totalgradeweight += grade.Hours * 4.0;
                }
                if (grade.UGrade >= 87 && grade.UGrade < 90)
                {
                    gPAViewer.tbGPA.Text += grade.ClassName;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "3.5\r\n";
                    totalgradeweight += grade.Hours * 3.5;
                }
                if (grade.UGrade >= 80 && grade.UGrade < 87)
                {
                    gPAViewer.tbGPA.Text += grade.ClassName;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "3.0\r\n";
                    totalgradeweight += grade.Hours * 3.0;
                }
                if (grade.UGrade >= 77 && grade.UGrade < 80)
                {
                    gPAViewer.tbGPA.Text += grade.ClassName;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "2.5\r\n";
                    totalgradeweight += grade.Hours * 2.5;
                }
                if (grade.UGrade >= 70 && grade.UGrade < 77)
                {
                    gPAViewer.tbGPA.Text += grade.ClassName;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "2.0\r\n";
                    totalgradeweight += grade.Hours * 2.0;
                }
                if (grade.UGrade >= 67 && grade.UGrade < 70)
                {
                    gPAViewer.tbGPA.Text += grade.ClassName;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "1.5\r\n";
                    totalgradeweight += grade.Hours * 1.5;
                }
                if (grade.UGrade >= 60 && grade.UGrade < 67)
                {
                    gPAViewer.tbGPA.Text += grade.ClassName;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "1.0\r\n";
                    totalgradeweight += grade.Hours * 1.0;
                }
                if (grade.UGrade < 60)
                {
                    gPAViewer.tbGPA.Text += grade.ClassName;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "0\r\n";
                    totalgradeweight += grade.Hours * 0.0;
                }
                totalcredits += grade.Hours;
            }
            double semestergpa = totalgradeweight / totalcredits;
            tbSGPA.Text += semestergpa;
            gpa = totalgradeweight / totalcredits;
            gPAViewer.tbGPA.Text += "Total GPA: ";
            gPAViewer.tbGPA.Text += gpa;
            gPAViewer.Show();
        }

        private void UpdateGPA(object sender, RoutedEventArgs e)
        {
            GPACalculator gPAViewer = new GPACalculator();
            int totalcredits = 0;
            double totalgradeweight = 0;
            double gpa = 0;

            foreach (Grade grade in Globals.gradebook.grades)
            {
                grade.UGrade = (int)(((double)grade.PointsEarned / (double)grade.MaxPoints) * 100);
                if (grade.UGrade >= 90)
                {
                    gPAViewer.tbGPA.Text += grade.ClassName;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "4.0\r\n";
                    totalgradeweight += grade.Hours * 4.0;
                }
                if (grade.UGrade >= 87 && grade.UGrade < 90)
                {
                    gPAViewer.tbGPA.Text += grade.ClassName;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "3.5\r\n";
                    totalgradeweight += grade.Hours * 3.5;
                }
                if (grade.UGrade >= 80 && grade.UGrade < 87)
                {
                    gPAViewer.tbGPA.Text += grade.ClassName;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "3.0\r\n";
                    totalgradeweight += grade.Hours * 3.0;
                }
                if (grade.UGrade >= 77 && grade.UGrade < 80)
                {
                    gPAViewer.tbGPA.Text += grade.ClassName;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "2.5\r\n";
                    totalgradeweight += grade.Hours * 2.5;
                }
                if (grade.UGrade >= 70 && grade.UGrade < 77)
                {
                    gPAViewer.tbGPA.Text += grade.ClassName;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "2.0\r\n";
                    totalgradeweight += grade.Hours * 2.0;
                }
                if (grade.UGrade >= 67 && grade.UGrade < 70)
                {
                    gPAViewer.tbGPA.Text += grade.ClassName;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "1.5\r\n";
                    totalgradeweight += grade.Hours * 1.5;
                }
                if (grade.UGrade >= 60 && grade.UGrade < 67)
                {
                    gPAViewer.tbGPA.Text += grade.ClassName;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "1.0\r\n";
                    totalgradeweight += grade.Hours * 1.0;
                }
                if (grade.UGrade < 60)
                {
                    gPAViewer.tbGPA.Text += grade.ClassName;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "0\r\n";
                    totalgradeweight += grade.Hours * 0.0;
                }
                totalcredits += grade.Hours;
            }
            double semestergpa = totalgradeweight / totalcredits;
            tbSGPA.Text = semestergpa.ToString();
        }
    }
}
