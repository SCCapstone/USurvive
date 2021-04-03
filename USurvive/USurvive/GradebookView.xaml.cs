using System;
using System.Collections;
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
        private class GPAClass
        {
            public ArrayList grades { get; set; }
            public String classname { get; set; }
            public int hours { get; set; }
            public GPAClass(String name, int tHour)
            {
                classname = name;
                hours = tHour;
                grades = new ArrayList();
            }
            public void insert(int grade)
            {
                grades.Add(grade);
            }
        }
            System.Collections.ObjectModel.ObservableCollection<Grade> grades;
        public GradebookView()
        {
            InitializeComponent();
            cmbGrades.ItemsSource = Globals.clList.classes;

            DG1.DataContext = Globals.gradebook.grades;
            GPACalculator gPAViewer = new GPACalculator();
            int totalcredits = 0;
            double totalgradeweight = 0;
            ArrayList classes = new ArrayList();
            
            foreach (Grade grade in Globals.gradebook.grades)
            {
                bool stop = false;

                foreach (GPAClass uclass in classes)
                {
                    if (grade.ClassName == uclass.classname)
                    {
                        stop = true;
                        uclass.insert((int)(((double)grade.PointsEarned / (double)grade.MaxPoints) * 100));
                    }
                    if (!stop)
                    {
                        GPAClass tempc = new GPAClass(grade.ClassName,grade.Hours);
                        tempc.insert((int)(((double)grade.PointsEarned / (double)grade.MaxPoints) * 100));
                        classes.Add(tempc);

                    }

                }
            }
           
            foreach (GPAClass uclass in classes)
            {
                int totalavg = 0;
                int counter = 0;
                foreach (int agrade in uclass.grades)
                {
                    totalavg += agrade;
                    counter++;

                }
                int grade = totalavg / counter;
                if (grade >= 90)
                {
                    gPAViewer.tbGPA.Text += uclass.classname;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "4.0\r\n";
                    totalgradeweight += uclass.hours * 4.0;
                }
                if (grade >= 87 && grade < 90)
                {
                    gPAViewer.tbGPA.Text += uclass.classname;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "3.5\r\n";
                    totalgradeweight += uclass.hours * 3.5;
                }
                if (grade >= 80 && grade < 87)
                {
                    gPAViewer.tbGPA.Text += uclass.classname;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "3.0\r\n";
                    totalgradeweight += uclass.hours * 3.0;
                }
                if (grade >= 77 && grade < 80)
                {
                    gPAViewer.tbGPA.Text += uclass.classname;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "2.5\r\n";
                    totalgradeweight += uclass.hours * 2.5;
                }
                if (grade >= 70 && grade < 77)
                {
                    gPAViewer.tbGPA.Text += uclass.classname;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "2.0\r\n";
                    totalgradeweight += uclass.hours * 2.0;
                }
                if (grade >= 67 && grade < 70)
                {
                    gPAViewer.tbGPA.Text += uclass.classname;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "1.5\r\n";
                    totalgradeweight += uclass.hours * 1.5;
                }
                if (grade >= 60 && grade < 67)
                {
                    gPAViewer.tbGPA.Text += uclass.classname;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "1.0\r\n";
                    totalgradeweight += uclass.hours * 1.0;
                }
                if (grade < 60)
                {
                    gPAViewer.tbGPA.Text += uclass.classname;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "0\r\n";
                    totalgradeweight += uclass.hours * 0.0;
                }
                totalcredits += uclass.hours;
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
            ArrayList classes = new ArrayList();
            double semestergpa = 0.0;
            foreach (Grade grade in Globals.gradebook.grades)
            {
                bool stop = false;

                foreach (GPAClass uclass in classes)
                {
                    if (grade.ClassName == uclass.classname)
                    {
                        stop = true;
                        uclass.insert((int)(((double)grade.PointsEarned / (double)grade.MaxPoints) * 100));
                    }
                   

                }
                 if (!stop)
                    {
                        GPAClass tempc = new GPAClass(grade.ClassName, grade.Hours);
                    Console.WriteLine("gradeHours");
                    Console.WriteLine(grade.Hours);
                        tempc.insert((int)(((double)grade.PointsEarned / (double)grade.MaxPoints) * 100));
                        classes.Add(tempc);

                    }
            }

            foreach (GPAClass uclass in classes)
            {
                int totalavg = 0;
                int counter = 0;
                foreach (int agrade in uclass.grades)
                {
                    totalavg += agrade;
                    counter++;

                }
                int grade = totalavg / counter;
                if (grade >= 90)
                {
                    gPAViewer.tbGPA.Text += uclass.classname;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "4.0\r\n";
                    totalgradeweight += (double)uclass.hours * 4.0;
                }
                if (grade >= 87 && grade < 90)
                {
                    gPAViewer.tbGPA.Text += uclass.classname;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "3.5\r\n";
                    totalgradeweight += (double)uclass.hours * 3.5;
                }
                if (grade >= 80 && grade < 87)
                {
                    gPAViewer.tbGPA.Text += uclass.classname;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "3.0\r\n";
                    totalgradeweight += (double)uclass.hours * 3.0;
                }
                if (grade >= 77 && grade < 80)
                {
                    gPAViewer.tbGPA.Text += uclass.classname;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "2.5\r\n";
                    totalgradeweight += (double)uclass.hours * 2.5;
                }
                if (grade >= 70 && grade < 77)
                {
                    gPAViewer.tbGPA.Text += uclass.classname;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "2.0\r\n";
                    totalgradeweight += (double)uclass.hours * 2.0;
                }
                if (grade >= 67 && grade < 70)
                {
                    gPAViewer.tbGPA.Text += uclass.classname;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "1.5\r\n";
                    totalgradeweight += (double)uclass.hours * 1.5;
                }
                if (grade >= 60 && grade < 67)
                {
                    gPAViewer.tbGPA.Text += uclass.classname;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "1.0\r\n";
                    totalgradeweight += (double)uclass.hours * 1.0;
                }
                if (grade < 60)
                {
                    gPAViewer.tbGPA.Text += uclass.classname;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "0\r\n";
                    totalgradeweight += (double)uclass.hours * 0.0;
                }
                totalcredits += uclass.hours;
            }
            semestergpa = totalgradeweight / totalcredits;
            //tbSGPA.Text += semestergpa;
            gpa = totalgradeweight / (double)totalcredits;
            gPAViewer.tbGPA.Text += "Total GPA: ";
            gPAViewer.tbGPA.Text += semestergpa;
            gPAViewer.Show();
        }

        private void UpdateGPA(object sender, RoutedEventArgs e)
        {
            GPACalculator gPAViewer = new GPACalculator();
            int totalcredits = 0;
            double totalgradeweight = 0;
            double gpa = 0;
            ArrayList classes = new ArrayList();
            double semestergpa = 0.0;
            int counter2 = 0;
            foreach (Grade grade in Globals.gradebook.grades)
            {
                bool stop = false;

                foreach (GPAClass uclass in classes)
                {
                    if (grade.ClassName == uclass.classname)
                    {
                        stop = true;
                        uclass.insert((int)(((double)grade.PointsEarned / (double)grade.MaxPoints) * 100));
                    }


                }
                if (!stop)
                {
                    GPAClass tempc = new GPAClass(grade.ClassName, grade.Hours);
                    tempc.insert((int)(((double)grade.PointsEarned / (double)grade.MaxPoints) * 100));
                    classes.Add(tempc);

                }
            }

            foreach (GPAClass uclass in classes)
            {
                int totalavg = 0;
                int counter = 0;
             
                foreach (int agrade in uclass.grades)
                {
                    totalavg += agrade;
                    counter++;

                }
                int grade = totalavg / counter;
                if (grade >= 90)
                {
                    gPAViewer.tbGPA.Text += uclass.classname;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "4.0\r\n";
                    totalgradeweight += (double)uclass.hours * 4.0;
                }
                if (grade >= 87 && grade < 90)
                {
                    gPAViewer.tbGPA.Text += uclass.classname;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "3.5\r\n";
                    totalgradeweight += (double)uclass.hours * 3.5;
                }
                if (grade >= 80 && grade < 87)
                {
                    gPAViewer.tbGPA.Text += uclass.classname;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "3.0\r\n";
                    totalgradeweight += (double)uclass.hours * 3.0;
                }
                if (grade >= 77 && grade < 80)
                {
                    gPAViewer.tbGPA.Text += uclass.classname;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "2.5\r\n";
                    totalgradeweight += (double)uclass.hours * 2.5;
                }
                if (grade >= 70 && grade < 77)
                {
                    gPAViewer.tbGPA.Text += uclass.classname;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "2.0\r\n";
                    totalgradeweight += (double)uclass.hours * 2.0;
                }
                if (grade >= 67 && grade < 70)
                {
                    gPAViewer.tbGPA.Text += uclass.classname;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "1.5\r\n";
                    totalgradeweight += (double)uclass.hours * 1.5;
                }
                if (grade >= 60 && grade < 67)
                {
                    gPAViewer.tbGPA.Text += uclass.classname;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "1.0\r\n";
                    totalgradeweight += (double)uclass.hours * 1.0;
                }
                if (grade < 60)
                {
                    gPAViewer.tbGPA.Text += uclass.classname;
                    gPAViewer.tbGPA.Text += " GPA: ";
                    gPAViewer.tbGPA.Text += "0\r\n";
                    totalgradeweight += (double)uclass.hours * 0.0;
                }
                totalcredits += uclass.hours;
             
               
            }
            semestergpa = totalgradeweight/totalcredits;
            tbSGPA.Text = semestergpa.ToString();
        }

        private void cmbGrades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string name = cmbGrades.SelectedItem.ToString();
            ObservableCollection<Grade> grades = new ObservableCollection<Grade>();
            foreach (Grade grade in Globals.gradebook.grades)
            {
                if (grade.ClassName == name)
                    grades.Add(grade);

            }
            DG1.DataContext = grades;
        }
    }
}
