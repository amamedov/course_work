using Core;
using Microsoft.Windows.Themes;
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

namespace StudentApp
{
    /// <summary>
    /// Логика взаимодействия для CoursesWindow.xaml
    /// </summary>
    public partial class CoursesWindow : Window
    {
        List<Course> unsignedCourses;
        public CoursesWindow(Repository repository, Student student)
        {
            unsignedCourses = new List<Course>();
            foreach (var item in repository.Courses)
            {
                if (repository.Contracts.Where(x => x.Course == item).All(x => x.Student != student) && !unsignedCourses.Contains(item))
                {
                    unsignedCourses.Add(item);
                }
            }
            InitializeComponent();
            ListBoxCourses.ItemsSource = unsignedCourses;
            ComboBoxSubject.ItemsSource = repository.Subjects;
            ComboBoxType.ItemsSource = repository.TypeOfCourses;

        }

        private void ComboBoxSubject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxSubject.SelectedItem!=null)
            {

            
            if (ComboBoxType.SelectedItem == null)
            {
                ListBoxCourses.ItemsSource = unsignedCourses.Where(x => x.SubjectID == (ComboBoxSubject.SelectedItem as Subject).ID);
            }
            else
                ListBoxCourses.ItemsSource = unsignedCourses.Where(x => x.SubjectID == (ComboBoxSubject.SelectedItem as Subject).ID && x.TypeID == (ComboBoxType.SelectedItem as TypeOfCourse).ID);
        } }

        private void ComboBoxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxType.SelectedItem != null)
            {


                if (ComboBoxSubject.SelectedItem == null)
                {
                    ListBoxCourses.ItemsSource = unsignedCourses.Where(x => x.TypeID == (ComboBoxType.SelectedItem as TypeOfCourse).ID);
                }
                else
                    ListBoxCourses.ItemsSource = unsignedCourses.Where(x => x.SubjectID == (ComboBoxSubject.SelectedItem as Subject).ID && x.TypeID == (ComboBoxType.SelectedItem as TypeOfCourse).ID);
            }
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxSubject.SelectedItem = null;
            ComboBoxType.SelectedItem = null;
            ListBoxCourses.ItemsSource = unsignedCourses;
        }
    }
}
