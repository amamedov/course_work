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
            ButtonChangeCourse.IsEnabled = false;
            ButtonDeleteCourse.IsEnabled = false;
            ButtonDeleteContract.IsEnabled = false;
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
            var contractWindow = new MakeContractWindow(managerID, connString);
            Hide();
            contractWindow.ShowDialog();
            Show();
            TextBlockContractInfo.Text = "Please refresh info";
        }

        private void ButtonDeleteContract_Click(object sender, RoutedEventArgs e)
        {
            Contract contract = (Contract)ListBoxContracts.SelectedItem;
            DBUtils.DeleteContract(contract, connString);
            MessageBox.Show("Contract deleted");
            TextBlockContractInfo.Text = "Please refresh info";
        }

        private void ListBoxContracts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ButtonDeleteContract.IsEnabled = true;
            ButtonMarkAsPaid.IsEnabled = true;
            if (ListBoxContracts.SelectedItems.Count > 1)
            {
                ListBoxContracts.SelectedItems.RemoveAt(0);
            }
            var selectedContract = (Contract)ListBoxContracts.SelectedItem;
            if (selectedContract != null)
                TextBlockContractInfo.Text = $"Student: {selectedContract.Student}  Course: {selectedContract.Course}\nPaid: {selectedContract.IsPaid}" +
                    $"  Active:{selectedContract.IsActive}\nCreated: {selectedContract.DateTimeMade}";
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
            ButtonDeleteContract.IsEnabled = false;
            ButtonMarkAsPaid.IsEnabled = false;
            TextBlockContractInfo.Text = "Select contract to view info";
        }
        private void ComboBoxStudentFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxStudentFilter.SelectedItem != null)
            {
                ListBoxContracts.ItemsSource = repository.Contracts;
                ListBoxContracts.ItemsSource = ComboBoxCourseFilter.SelectedItem == null ?
                    ListBoxContracts.ItemsSource.Cast<Contract>().ToList().Where(x => x.Student == (Student)ComboBoxStudentFilter.SelectedItem) :
                    ListBoxContracts.ItemsSource.Cast<Contract>().ToList().Where(x => x.Student == (Student)ComboBoxStudentFilter.SelectedItem && x.Course == (Course)ComboBoxCourseFilter.SelectedItem);
            }
        }

        private void ClearButton_1_Click(object sender, RoutedEventArgs e)
        {
            this.repository.UpdateContracts();
            ListBoxContracts.ItemsSource = repository.Contracts;
            ComboBoxStudentFilter.SelectedItem = null;
            ComboBoxCourseFilter.SelectedItem = null;
        }

        private void ComboBoxCourseFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxCourseFilter.SelectedItem != null)
            {
                ListBoxContracts.ItemsSource = repository.Contracts;
                ListBoxContracts.ItemsSource = ComboBoxStudentFilter.SelectedItem == null ?
                    ListBoxContracts.ItemsSource.Cast<Contract>().ToList().Where(x => x.Course == (Course)ComboBoxCourseFilter.SelectedItem) :
                    ListBoxContracts.ItemsSource.Cast<Contract>().ToList().Where(x => x.Course == (Course)ComboBoxCourseFilter.SelectedItem && x.Student == (Student)ComboBoxStudentFilter.SelectedItem);
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
            TextBlockCourseInfo.Text = "Please refresh info";
            repository.UpdateCourses();
            ComboBoxCourseFilter.ItemsSource = repository.Courses;
        }

        private void ButtonRefreshCourses_Click(object sender, RoutedEventArgs e)
        {
            UpdateListboxes();
            TextBlockCourseInfo.Text = "Choose course to view info";
            ButtonChangeCourse.IsEnabled = false;
            ButtonDeleteCourse.IsEnabled = false;
            ButtonTimetable.IsEnabled = false;
        }

        private void ListBoxCourses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ButtonChangeCourse.IsEnabled = true;
            ButtonDeleteCourse.IsEnabled = true;
            ButtonTimetable.IsEnabled = true;
            if (ListBoxContracts.SelectedItems.Count > 1)
            {
                ListBoxContracts.SelectedItems.RemoveAt(0);
            }
            var chosenCourse = (Course)ListBoxCourses.SelectedItem;
            if (chosenCourse != null)
                TextBlockCourseInfo.Text = $"Name: {chosenCourse.Name}; Dates: {chosenCourse.StartDate.ToShortDateString()}-{chosenCourse.EndDate.ToShortDateString()}; " +
                    $"Price:{chosenCourse.Price};  Exam: {chosenCourse.FollowedByExam}; Requirements: {chosenCourse.HasRequirements} ";
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
            TextBlockCourseInfo.Text = "Please refresh info";
        }

        private void ButtonChangeCourse_Click(object sender, RoutedEventArgs e)
        {
            var course = (Course)ListBoxCourses.SelectedItem;
            var courseWindow = new MakeCourse(managerID, connString,repository, course);
            Hide();
            courseWindow.ShowDialog();
            Show();
            TextBlockCourseInfo.Text = "Please refresh info";
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
            ButtonChangeStudent.IsEnabled = false;
            TextBlockStudentInfo.Text = "Choose student to view info";
        }

        private void ListBoxStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxStudents.SelectedItems.Count > 1)
                ListBoxStudents.SelectedItems.RemoveAt(0);
            ButtonChangeStudent.IsEnabled = true;
            var chosenStudent = (Student)ListBoxStudents.SelectedItem;
            if (chosenStudent != null)
                TextBlockStudentInfo.Text = $"Name: {chosenStudent.Name} {chosenStudent.Surname} Date of birth: {chosenStudent.DoB.ToShortDateString()} Gender:{chosenStudent.Gender}";
        }



        private void ButtonChangeStudent_Click(object sender, RoutedEventArgs e)
        {
            var studentWindow = new AddStudent(connString, (Student)ListBoxStudents.SelectedItem);
            studentWindow.ShowDialog();
        }

        private void ButtonAddStudent_Click(object sender, RoutedEventArgs e)
        {
            var studentWindow = new AddStudent(connString);
            studentWindow.ShowDialog();
            repository.UpdateStudents();
            ComboBoxStudentFilter.ItemsSource = repository.Students;
        }
        #endregion
        
    }
    
}
