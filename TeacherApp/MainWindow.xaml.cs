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
            ComboBoxCourse.ItemsSource = repository.Courses.Where(x => x.IsActive && repository.Lessons.Where(y => y.Teacher == teacher).Any(z => z.Course == x));
            ComboBoxCourse.SelectedIndex = 0;
            course = (Course)ComboBoxCourse.SelectedItem;
            ListBoxLessons.ItemsSource = repository.Lessons.Where(x => x.Course == course);
        }

        private void ComboBoxCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            course = (Course)ComboBoxCourse.SelectedItem;
            ListBoxLessons.ItemsSource = repository.Lessons.Where(x => x.Course == course);
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
