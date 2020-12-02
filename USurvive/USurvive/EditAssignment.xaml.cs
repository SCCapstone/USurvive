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

namespace USurvive
{
    /// <summary>
    /// Interaction logic for EditAssignment.xaml
    /// </summary>
    public partial class EditAssignment : Window
    {
        public EditAssignment()
        {
            InitializeComponent();
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            String name = tbClassName.Text;
            String date = tbDate.Text;
            String dueDate = tbDueDate.Text;
            String grade = tbGrade.Text;
            String autoIncrementDays = tbAutoIncrementDays.Text;


    

        }

// private void CancelClick (object sender, RoutedEventArgs e)
        
    }

}

