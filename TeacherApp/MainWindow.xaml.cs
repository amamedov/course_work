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
using Core;
using Models;

namespace TeacherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Repository repository;
        Teacher teacher;
        Course course;
        public MainWindow(Repository repository, Teacher teacher)
        {
            InitializeComponent();
            this.repository = repository;
            this.teacher = teacher;
            ComboBoxCourse.ItemsSource = repository.Courses.Where(x => repository.Lessons.Where(y => y.Teacher == teacher).Any(z => z.Course == x));
            ComboBoxCourse.SelectedIndex = 0;
        }

        private void ComboBoxCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            course = (Course)ComboBoxCourse.SelectedItem;
            ListBoxLessons.ItemsSource = repository.Lessons.Where(x => x.Course == course&&x.TeacherID == teacher.ID && x.DTStart >= DateTime.Now);
            ListBoxPastLessons.ItemsSource = repository.Lessons.Where(x => x.Course == course && x.TeacherID == teacher.ID && x.DTStart < DateTime.Now);
            ButtonStudentList.IsEnabled = true;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
                Close();
        }

        private void ButtonStudentList_Click(object sender, RoutedEventArgs e)
        {
            var listWIndow = new StudentListWindow(repository, course, repository.Lessons.Where(x => x.Course == course).ToList());
            Hide();
            listWIndow.ShowDialog();
            Show();
        }

        private void Button_Extra_Click(object sender, RoutedEventArgs e)
        {
            var ew = new ExtraWindow(repository, ListBoxLessons.SelectedItem as Lesson);
            ew.Show();
        }

        private void ListBoxLessons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in (sender as ListBox).Items)
            {
                (item as Lesson).VisibleForExtra = false;
            }
            ((sender as ListBox).SelectedItem as Lesson).VisibleForExtra = true;
            ListBoxLessons.ItemsSource = repository.Lessons.Where(x => x.Course == course && x.TeacherID == teacher.ID && x.DTStart >= DateTime.Now);
        }
    }
}
