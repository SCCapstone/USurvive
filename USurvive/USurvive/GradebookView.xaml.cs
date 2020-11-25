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
        ObservableCollection<Grade> grades;
        public GradebookView()
        {
            InitializeComponent();

            grades = new ObservableCollection<Grade>();


            DG1.DataContext = grades;
            grades.Add(new Grade("CSCE 522", 99, 3));
            grades.Add(new Grade("CSCE 520", 86, 3));
            grades.Add(new Grade("MART 210", 96, 3));
        }
        private void DisplayGPA(object sender, RoutedEventArgs e)
        {
            GPACalculator gPAViewer = new GPACalculator();
            int totalcredits = 0;
            double totalgradeweight = 0;
            double gpa = 0;
            foreach (Grade grade in grades)
            {
                if (grade.TheGrade >= 90)
                {
                    gPAViewer.tbGPA.Text += grade.Class;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "4.0\r\n";
                    totalgradeweight += grade.Hours * 4.0;
                }
                if (grade.TheGrade >= 87 && grade.TheGrade < 90)
                {
                    gPAViewer.tbGPA.Text += grade.Class;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "3.5\r\n";
                    totalgradeweight += grade.Hours * 3.5;
                }
                if (grade.TheGrade >= 80 && grade.TheGrade < 87)
                {
                    gPAViewer.tbGPA.Text += grade.Class;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "3.0\r\n";
                    totalgradeweight += grade.Hours * 3.0;
                }
                if (grade.TheGrade >= 77 && grade.TheGrade < 80)
                {
                    gPAViewer.tbGPA.Text += grade.Class;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "2.5\r\n";
                    totalgradeweight += grade.Hours * 2.5;
                }
                if (grade.TheGrade >= 70 && grade.TheGrade < 77)
                {
                    gPAViewer.tbGPA.Text += grade.Class;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "2.0\r\n";
                    totalgradeweight += grade.Hours * 2.0;
                }
                if (grade.TheGrade >= 67 && grade.TheGrade < 70)
                {
                    gPAViewer.tbGPA.Text += grade.Class;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "1.5\r\n";
                    totalgradeweight += grade.Hours * 1.5;
                }
                if (grade.TheGrade >= 60 && grade.TheGrade < 67)
                {
                    gPAViewer.tbGPA.Text += grade.Class;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "1.0\r\n";
                    totalgradeweight += grade.Hours * 1.0;
                }
                if (grade.TheGrade < 60)
                {
                    gPAViewer.tbGPA.Text += grade.Class;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "0\r\n";
                    totalgradeweight += grade.Hours * 0.0;
                }
                totalcredits += grade.Hours;
            }
            gpa = totalgradeweight / totalcredits;
            gPAViewer.tbGPA.Text += "Total GPA: ";
            gPAViewer.tbGPA.Text += gpa;
            gPAViewer.Show();
        }
    }
}
