using Core;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ManagerApp
{
    /// <summary>
    /// Логика взаимодействия для TimetableWindow.xaml
    /// </summary>
    public partial class TimetableWindow : Window
    {
        Repository repository;
        Course course;
        public string WindowName { get; set; }
        public TimetableWindow(Repository repository, Course course)
        {
            InitializeComponent();
            this.repository = repository;
            this.course = course;
            DataContext = this;
            WindowName = $"Timetable for {course.Name}";
            ListBoxLessons.ItemsSource = repository.Lessons.Where(x => x.Course.ID == course.ID).OrderBy(x=>x.DTStart).ToList();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var lessonWindow = new LessonWindow(repository, course);
            lessonWindow.ShowDialog();
            repository.UpdateLessons();
            ListBoxLessons.ItemsSource = repository.Lessons.Where(x => x.Course.ID == course.ID).OrderBy(x=>x.DTStart).ToList();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ListBoxLessons_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var lessonWindow = new LessonWindow(repository, course, (Lesson)ListBoxLessons.SelectedItem);
            lessonWindow.ShowDialog();
            repository.UpdateLessons();
            ListBoxLessons.ItemsSource = repository.Lessons.Where(x => x.Course.ID == course.ID).OrderBy(x => x.DTStart).ToList();
        }
    }
}
