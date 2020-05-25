using Core;
using Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Repository repository;
        Student student;
        List<Course> courses;
        public MainWindow(Repository repository, Student student)
        {
            this.repository = repository;
            this.student = student;
            InitializeComponent();
            textBlockWelcome.Text = $"Welcome back, {student.Name} {student.Surname}";
            this.Title = $"{student.Name} {student.Surname}";
            courses = new List<Course>();
            foreach (var item in repository.Contracts)
            {
                if (item.Student == student && !courses.Contains(item.Course))
                    courses.Add(item.Course);
            }
            ListBoxCourses.ItemsSource = courses.Where(x=>x.IsActive);
        }

        private void ListBoxCourses_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var timetableWindow = new TimetableWindow(repository, (Course)ListBoxCourses.SelectedItem);
            timetableWindow.ShowDialog();
        }

        private void CheckBoxPastCourses_Checked(object sender, RoutedEventArgs e)
        {
            ListBoxCourses.ItemsSource = courses;
        }

        private void CheckBoxPastCourses_Unchecked(object sender, RoutedEventArgs e)
        {
            ListBoxCourses.ItemsSource = courses.Where(x => x.IsActive);
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
                Close();
        }

        private void ButtonSearchCourse_Click(object sender, RoutedEventArgs e)
        {
            var courseWindow = new CoursesWindow(repository, student);
            courseWindow.ShowDialog();
        }
    }
}
