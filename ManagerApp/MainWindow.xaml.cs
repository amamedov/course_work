using Core;
using ManagerApp;
using Models;
using System;
using System.Collections.Generic;
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
        Repository repository;
        string connString;

        private void UpdateListboxes()
        {
            this.repository.UpdateCourses();
            this.repository.UpdateContracts();
            ListBoxContracts.ItemsSource = repository.Contracts;
            ListBoxCourses.ItemsSource = repository.Courses;
        }
        public ManagerMainWindow(string connString, Repository repository, int managerID)
        {
            InitializeComponent();
            this.connString = connString;
            this.repository = new Repository(connString);
            ListBoxContracts.ItemsSource = repository.Contracts;
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Some useful info");
        }
        #region Contracts
        private void ButtonAddContract_Click(object sender, RoutedEventArgs e)
        {
            var contractWindow = new MakeContractWindow(repository, managerID);
            Hide();
            contractWindow.ShowDialog();
            Show();
        }

        private void ButtonDeleteContract_Click(object sender, RoutedEventArgs e)
        {
            Contract contract = (Contract)ListBoxContracts.SelectedItem;
            DBUtils.DeleteContract(contract, connString);
            MessageBox.Show("Contract deleted");
        }

        private void ListBoxContracts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ButtonMarkAsPaid.IsEnabled = true;
            if (ListBoxContracts.SelectedItems.Count > 1)
            {
                ListBoxContracts.SelectedItems.RemoveAt(0);
            }
            var selectedContract = (Contract)ListBoxContracts.SelectedItem;
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
                MessageBox.Show("Payment is successful");
            }
        }

        private void ButtonRefreshContracts_Click(object sender, RoutedEventArgs e)
        {
            repository.UpdateContracts();
            ListBoxContracts.ItemsSource = repository.Contracts;
            ButtonMarkAsPaid.IsEnabled = false;
        }
        private void ComboBoxStudentFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxStudentFilter.SelectedIndex != -1)
            {
                if (ComboBoxCourseFilter.SelectedIndex == -1)
                {
                    ListBoxContracts.ItemsSource = repository.Contracts.Where(x => x.Student.ID == (ComboBoxStudentFilter.SelectedItem as Student).ID);
                }
                else
                {
                    ListBoxContracts.ItemsSource = repository.Contracts.Where(x => x.Student.ID == (ComboBoxStudentFilter.SelectedItem as Student).ID && x.Course.ID == (ComboBoxCourseFilter.SelectedItem as Course).ID);
                }
            }
        }

        private void ClearButton_1_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxStudentFilter.SelectedIndex = -1;
            ComboBoxCourseFilter.SelectedIndex = -1;
            ListBoxContracts.ItemsSource = repository.Contracts;
        }

        private void ComboBoxCourseFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxCourseFilter.SelectedIndex != -1)
            {
                if (ComboBoxStudentFilter.SelectedIndex == -1)
                {
                    ListBoxContracts.ItemsSource = repository.Contracts.Where(x => x.Course.ID == (ComboBoxCourseFilter.SelectedItem as Course).ID);
                }
                else
                {
                    ListBoxContracts.ItemsSource = repository.Contracts.Where(x => x.Student.ID == (ComboBoxStudentFilter.SelectedItem as Student).ID && x.Course.ID == (ComboBoxCourseFilter.SelectedItem as Course).ID);
                }
            }
        }
        
        #endregion

        #region Courses
        private void ButtonAddCourse_Click(object sender, RoutedEventArgs e)
        {
            var courseWindow = new MakeCourse(managerID, connString, repository);
            Hide();
            courseWindow.ShowDialog();
            Show();
            repository.UpdateCourses();
            ComboBoxCourseFilter.ItemsSource = repository.Courses;
        }

        private void ButtonRefreshCourses_Click(object sender, RoutedEventArgs e)
        {
            UpdateListboxes();
            ButtonTimetable.IsEnabled = false;
            ButtonAddSubject.IsEnabled = true;
            ButtonAddCourse.IsEnabled = true;
        }
        private void ButtonTimetable_Click(object sender, RoutedEventArgs e)
        {
            var timetableWindow = new TimetableWindow(repository, (Course)ListBoxCourses.SelectedItem);
            Hide();
            timetableWindow.ShowDialog();
            Show();
        }
        private void ButtonDeleteCourse_Click(object sender, RoutedEventArgs e)
        {
            Course course = (Course)ListBoxCourses.SelectedItem;
            DBUtils.DeleteCourse(course, connString);
            MessageBox.Show("course deleted");
        }


        private void ButtonAddSubject_Click(object sender, RoutedEventArgs e)
        {
            var subjectWindow = new SubjectWindow(connString);
            Hide();
            subjectWindow.ShowDialog();
            Show();
            repository.UpdateSubjects();
            ComboBoxSubjectFilter.ItemsSource = repository.Subjects;
        }

        private void ComboBoxSubjectFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxSubjectFilter.SelectedItem != null)
            {
                ListBoxCourses.ItemsSource = repository.Courses;
                ListBoxCourses.ItemsSource = ListBoxCourses.ItemsSource.Cast<Course>().ToList().Where(x => x.SubjectID == ((Subject)ComboBoxSubjectFilter.SelectedItem).ID);
            }
        }


        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            this.repository.UpdateCourses();
            ListBoxCourses.ItemsSource = repository.Courses;
            ComboBoxSubjectFilter.SelectedItem = null;
        }
        #endregion

        #region Students
        private void ButtonRefreshStudents_Click(object sender, RoutedEventArgs e)
        {
            repository.UpdateStudents();
            ListBoxStudents.ItemsSource = repository.Students;
            ListBoxStudents.SelectedItem = null;
        }

        private void ButtonAddStudent_Click(object sender, RoutedEventArgs e)
        {
            var studentWindow = new AddStudent(connString);
            studentWindow.ShowDialog();
            repository.UpdateStudents();
            ComboBoxStudentFilter.ItemsSource = repository.Students;
        }
        #endregion

        private void ListBoxCourses_Selected(object sender, RoutedEventArgs e)
        {
            ButtonTimetable.IsEnabled = true;
            var chosenCourse = (Course)ListBoxCourses.SelectedItem;
        }

        private void ListBoxCourses_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var course = (Course)ListBoxCourses.SelectedItem;
            var courseWindow = new MakeCourse(managerID, connString, repository, course);
            Hide();
            courseWindow.ShowDialog();
            Show();
            ButtonAddCourse.IsEnabled = false;
            ButtonTimetable.IsEnabled = false;
            ButtonAddSubject.IsEnabled = false;
        }

        private void ListBoxStudents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            var studentWindow = new AddStudent(connString, (Student)ListBoxStudents.SelectedItem);
            studentWindow.ShowDialog();
        }
    }

}
