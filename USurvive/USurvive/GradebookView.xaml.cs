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
            public ArrayList totalpoints { get; set; }
            public ArrayList maxpoints { get; set; }
            public String classname { get; set; }
            public int hours { get; set; }
            public int gradeweight { get; set; }
            public GPAClass(String name, int tHour, int tgradeweight)
            {
                classname = name;
                hours = tHour;
                grades = new ArrayList();
                maxpoints = new ArrayList();
                totalpoints = new ArrayList();
                gradeweight = tgradeweight;
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
            double semestergpa = 0.0;

            foreach (Grade grade in Globals.gradebook.grades)
            {
                bool stop = false;

                foreach (GPAClass uclass in classes)
                {
                    if (grade.ClassName == uclass.classname)
                    {
                        stop = true;

                        if (grade.MaxPoints == 0)
                        {
                            uclass.insert(0);
                        }
                        else
                        {
                            uclass.maxpoints.Add(grade.MaxPoints);
                            uclass.totalpoints.Add(grade.PointsEarned);
                            uclass.insert((int)(((double)grade.PointsEarned / (double)grade.MaxPoints) * 100));
                        }
                    }


                }
                if (!stop)
                {
                    GPAClass tempc = new GPAClass(grade.ClassName, grade.Hours, grade.GradeWeight);

                    if (grade.MaxPoints == 0)
                    {
                        tempc.insert(0);
                    }
                    else
                    {
                        tempc.insert((int)(((double)grade.PointsEarned / (double)grade.MaxPoints) * 100));
                        tempc.maxpoints.Add(grade.MaxPoints);
                        tempc.totalpoints.Add(grade.PointsEarned);
                    }
                    classes.Add(tempc);

                }
            }

            foreach (GPAClass uclass in classes)
            {
                int totalavg = 0;
                int counter = 0;
                int totalpoints = 0;
                int totalweight = 0;
                int totalmax = 0;
                foreach (int atp in uclass.totalpoints)
                {
                    totalpoints += atp;
                    counter++;

                    totalweight += uclass.gradeweight;

                }
                foreach (int amp in uclass.maxpoints)
                {
                    totalmax += amp;
                    counter++;

                    totalweight += uclass.gradeweight;

                }
                foreach (int agrade in uclass.grades)
                {
                    totalavg += agrade;
                    counter++;

                    totalweight += uclass.gradeweight;

                }
                double test = ((double)totalpoints) / ((double)totalmax);
                double grade = Math.Round(((double)totalpoints / (double)totalmax) * 100,2);
                Console.WriteLine("Test" + test);
                if (totalmax == 0)
                    grade = 0;
                string sgrade = grade.ToString();
                Console.WriteLine(sgrade);
                Console.WriteLine(grade);
                Console.WriteLine(totalmax);
                Console.WriteLine(totalpoints);
                Current.Text += "\n";
                Current.Text += "Class: " + uclass.classname + " Grade: " + sgrade;
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
            if (totalgradeweight == 0.0)
            {
                semestergpa = 0.0;
            }
            else
            {
                semestergpa = totalgradeweight / totalcredits;
            }
            tbSGPA.Text = "Semester GPA: " + semestergpa.ToString();




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
                    GPAClass tempc = new GPAClass(grade.ClassName, grade.Hours, grade.GradeWeight);
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
            if (totalgradeweight == 0.0)
            {
                semestergpa = 0.0;
            }
            else
            {
                semestergpa = totalgradeweight / totalcredits;
            }
            tbSGPA.Text = "Semester GPA: " + semestergpa;
            double numgpa = 0.0;
            gpa = totalgradeweight / (double)totalcredits;
            if (!string.IsNullOrEmpty(oldgpa.Text) && Double.TryParse(oldgpa.Text, out numgpa))
            {
                gpa = (gpa + numgpa) / 2;
                gPAViewer.tbGPA.Text += "Old GPA: ";
                gPAViewer.tbGPA.Text += numgpa;
                gPAViewer.tbGPA.Text += "\n";
            }
            gPAViewer.tbGPA.Text += "Total GPA: ";
            gPAViewer.tbGPA.Text += gpa;
            gPAViewer.Show();
        }

        private void UpdateGPA(object sender, RoutedEventArgs e)
        {
            GPACalculator gPAViewer = new GPACalculator();
            int totalcredits = 0;
            double totalgradeweight = 0;
  
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
                    GPAClass tempc = new GPAClass(grade.ClassName, grade.Hours, grade.GradeWeight);
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
            if (totalgradeweight == 0.0)
            {
                semestergpa = 0.0;
            }
            else
            {
                semestergpa = totalgradeweight / totalcredits;
            }

            tbSGPA.Text = "Semester GPA: " + semestergpa.ToString();
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

        private void RefreshGrade(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            cmbGrades.ItemsSource = Globals.clList.classes;

            DG1.DataContext = Globals.gradebook.grades;
            GPACalculator gPAViewer = new GPACalculator();
            int totalcredits = 0;
            double totalgradeweight = 0;
            double globalestimated;
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
                        if (grade.MaxPoints == 0)
                        {
                            uclass.insert(0);
                        }
                        else
                        {
                            uclass.insert((int)(((double)grade.PointsEarned / (double)grade.MaxPoints) * 100));
                        }
                    }


                }
                if (!stop)
                {
                    GPAClass tempc = new GPAClass(grade.ClassName, grade.Hours, grade.GradeWeight);
                    if (grade.MaxPoints == 0)
                    {
                        tempc.insert(0);
                    }
                    else
                    {
                        tempc.insert((int)(((double)grade.PointsEarned / (double)grade.MaxPoints) * 100));
                    }
                    classes.Add(tempc);

                }
            }
            Current.Text = "";
            Current.Text = "Current Grades: ";
            foreach (GPAClass uclass in classes)
            {
                int totalavg = 0;
                int counter = 0;
                double estimated = 0.0;
                double estimated2 = 0.0;
                int totalweight = 0;

                foreach (int agrade in uclass.grades)
                {
                    totalavg += agrade;
                    counter++;
                    estimated = (double)agrade * ((double)uclass.gradeweight / 100.00);
                    totalweight += uclass.gradeweight;
                    estimated2 += estimated;
                    Console.WriteLine(agrade);
                    Console.WriteLine(estimated);
                }
                globalestimated = estimated2;
                int grade = totalavg / counter;
                string sgrade = grade.ToString();

                Current.Text += "\n";

                Current.Text += "Class: " + uclass.classname + " Grade: " + sgrade;
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
                tbSGPA.Text = globalestimated.ToString();
            }

            if (totalgradeweight == 0.0)
            {
                semestergpa = 0.0;
            }
            else
            {
                semestergpa = totalgradeweight / totalcredits;
            }
            tbSGPA.Text = "Semester GPA: " + semestergpa.ToString();


        }
        private void enterField_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= enterField_GotFocus; // remove this handler (we only want to delete text on first focus)
        }

        private void DG1_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (DG1.SelectedItem != null)
            {
                (sender as DataGrid).CellEditEnding -= DG1_CellEditEnding;
                (sender as DataGrid).CommitEdit();
                bool isGoodVal = (sender as DataGrid).CommitEdit();
                if (isGoodVal)
                    (sender as DataGrid).Items.Refresh();
                else
                    return;
                (sender as DataGrid).CellEditEnding += DG1_CellEditEnding;
            }
            else return;

            GPACalculator gPAViewer = new GPACalculator();
            int totalcredits = 0;
            double totalgradeweight = 0;
            double globalestimated;
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
                        if (grade.MaxPoints == 0)
                        {
                            uclass.insert(0);
                        }
                        else
                        {
                            uclass.insert((int)(((double)grade.PointsEarned / (double)grade.MaxPoints) * 100));
                            uclass.maxpoints.Add(grade.MaxPoints);
                            uclass.totalpoints.Add(grade.PointsEarned);
                        }
                    }


                }
                if (!stop)
                {
                    GPAClass tempc = new GPAClass(grade.ClassName, grade.Hours, grade.GradeWeight);
                    if (grade.MaxPoints == 0)
                    {
                        tempc.insert(0);
                    }
                    else
                    {
                        tempc.insert((int)(((double)grade.PointsEarned / (double)grade.MaxPoints) * 100));

                        tempc.maxpoints.Add(grade.MaxPoints);
                        tempc.totalpoints.Add(grade.PointsEarned);
                    }
                    classes.Add(tempc);

                }
            }
            Current.Text = "";
            Current.Text = "Current Grades: ";
            foreach (GPAClass uclass in classes)
            {
                int totalavg = 0;
                int counter = 0;
                double estimated = 0.0;
                double estimated2 = 0.0;
                int totalweight = 0;
                int totalmax = 0;
                int totalpoints = 0;
                foreach (int agrade in uclass.grades)
                {
                    totalavg += agrade;
                    counter++;
                    estimated = (double)agrade * ((double)uclass.gradeweight / 100.00);
                    totalweight += uclass.gradeweight;
                    estimated2 += estimated;
                    Console.WriteLine(agrade);
                    Console.WriteLine(estimated);
                }
                foreach (int atp in uclass.totalpoints)
                {
                    totalpoints += atp;
                    Console.WriteLine("Total Points" + totalpoints);
                    counter++;

                    totalweight += uclass.gradeweight;

                }
                foreach (int amp in uclass.maxpoints)
                {
                    totalmax += amp;
                    counter++;

                    totalweight += uclass.gradeweight;

                }
                globalestimated = estimated2;
                double grade = Math.Round((double)totalpoints / (double)totalmax * 100,2);
                string sgrade = grade.ToString();

                Current.Text += "\n";

                Current.Text += "Class: " + uclass.classname + " Grade: " + sgrade;
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
                tbSGPA.Text = globalestimated.ToString();
            }

            if (totalgradeweight == 0.0)
            {
                semestergpa = 0.0;
            }
            else
            {
                semestergpa = totalgradeweight / totalcredits;
            }
            tbSGPA.Text = "Semester GPA: " + semestergpa.ToString();

        }

      
    }
}