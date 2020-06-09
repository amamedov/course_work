using Core;
using ManagerApp;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Printing;
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

namespace cOURSEwoRK
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ManagerMainWindow : Window
    {
        int managerID = 1;
        public Repository repository { get; set; }
        string connString;

        public ManagerMainWindow(string connString, Repository repository, int managerID)
        {
            this.connString = connString;
            this.repository = new Repository(connString);
            InitializeComponent();
            this.DataContext = this;
            ListBoxCourses.ItemsSource = repository.Courses;
            ComboBoxSubjectFilter.ItemsSource = repository.Subjects;
            ComboBoxStudentFilter.ItemsSource = repository.Students;
            ComboBoxCourseFilter.ItemsSource = repository.Courses;
            ListBoxStudents.ItemsSource = repository.Students;
            ButtonMarkAsPaid.IsEnabled = false;
            ButtonTimetable.IsEnabled = false;

            //this.managerID = managerID;
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
                Close();
        }
        #region Contracts
        private void ButtonAddContract_Click(object sender, RoutedEventArgs e)
        {
            var contractWindow = new MakeContractWindow(repository, managerID);
            contractWindow.ShowDialog();
        }

        private void ListBoxContracts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ButtonMarkAsPaid.IsEnabled = true;
        }

        private void ButtonMarkAsPaid_Click(object sender, RoutedEventArgs e)
        {
            var selectedContract = (Contract)ListBoxContracts.SelectedItem;
            if (selectedContract.IsPaid)
            {
                MessageBox.Show("Contract is already paid");
            }
            else
            {
                DBUtils.PayForContract(selectedContract, connString);
                selectedContract.IsPaid = true;
                ListBoxContracts.Items.Refresh();
                MessageBox.Show("Payment is successful");
            }
        }

        private void ComboBoxStudentFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxStudentFilter.SelectedIndex != -1)
            {
                if (ComboBoxCourseFilter.SelectedIndex == -1)
                {
                    ListBoxContracts.Items.Filter = new Predicate<object>(x => (x as Contract).Student.ID == (ComboBoxStudentFilter.SelectedItem as Student).ID);
                }
                else
                {
                    ListBoxContracts.Items.Filter = new Predicate<object>(x =>
                                                    (x as Contract).Student.ID == (ComboBoxStudentFilter.SelectedItem as Student).ID
                                                     && (x as Contract).Course.ID == (ComboBoxCourseFilter.SelectedItem as Course).ID);
                }
            }
        }

        private void ClearButton_1_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxStudentFilter.SelectedIndex = -1;
            ComboBoxCourseFilter.SelectedIndex = -1;
            ListBoxContracts.Items.Filter = null;
        }

        private void ComboBoxCourseFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxCourseFilter.SelectedIndex != -1)
            {
                if (ComboBoxStudentFilter.SelectedIndex == -1)
                {
                    ListBoxContracts.Items.Filter = new Predicate<object>(x => (x as Contract).Course.ID == (ComboBoxCourseFilter.SelectedItem as Course).ID);
                }
                else
                {
                    ListBoxContracts.Items.Filter = new Predicate<object>(x =>
                                        (x as Contract).Student.ID == (ComboBoxStudentFilter.SelectedItem as Student).ID
                                        && (x as Contract).Course.ID == (ComboBoxCourseFilter.SelectedItem as Course).ID);
                }
            }
        }

        #endregion

        #region Courses
        private void ButtonAddCourse_Click(object sender, RoutedEventArgs e)
        {
            var courseWindow = new MakeCourse(managerID, connString, repository);
            courseWindow.ShowDialog();
            ComboBoxCourseFilter.ItemsSource = repository.Courses;
        }
        private void ButtonTimetable_Click(object sender, RoutedEventArgs e)
        {
            var timetableWindow = new TimetableWindow(repository, (Course)ListBoxCourses.SelectedItem);
            timetableWindow.ShowDialog();
        }

        private void ButtonAddSubject_Click(object sender, RoutedEventArgs e)
        {
            var subjectWindow = new SubjectWindow(connString);
            subjectWindow.ShowDialog();
            repository.UpdateSubjects();
            ComboBoxSubjectFilter.ItemsSource = repository.Subjects;
        }

        private void ComboBoxSubjectFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxSubjectFilter.SelectedItem != null)
            {
                ListBoxCourses.Items.Filter = new Predicate<object>(x => (x as Course).SubjectID == ((sender as ComboBox).SelectedItem as Subject).ID);
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ListBoxCourses.Items.Filter = null;
            ComboBoxSubjectFilter.SelectedIndex = -1;
        }

        private void ListBoxCourses_Selected(object sender, RoutedEventArgs e)
        {
            ButtonTimetable.IsEnabled = true;
        }

        private void ListBoxCourses_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var course = (Course)ListBoxCourses.SelectedItem;
            var courseWindow = new MakeCourse(managerID, connString, repository, course);
            courseWindow.ShowDialog();
            ListBoxCourses.Items.Refresh();
            ButtonTimetable.IsEnabled = false;
        }
        #endregion

        #region Students

        private void ButtonAddStudent_Click(object sender, RoutedEventArgs e)
        {
            var studentWindow = new AddStudent(repository);
            studentWindow.ShowDialog();
            ComboBoxStudentFilter.ItemsSource = repository.Students;
        }

        private void ListBoxStudents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            var studentWindow = new AddStudent(repository, (Student)ListBoxStudents.SelectedItem);
            studentWindow.ShowDialog();
            ListBoxStudents.Items.Refresh();
        }
        #endregion

    }

}
