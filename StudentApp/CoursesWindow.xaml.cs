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

namespace StudentApp
{
    /// <summary>
    /// Логика взаимодействия для CoursesWindow.xaml
    /// </summary>
    public partial class CoursesWindow : Window
    {
        public CoursesWindow(Repository repository, Student student)
        {
            var unsignedCourses = new List<Course>();
            foreach (var item in repository.Courses)
            {
                if (repository.Contracts.Where(x=> x.Course==item).All(x=>x.Student!=student)&&!unsignedCourses.Contains(item))
                {
                    unsignedCourses.Add(item);
                }
            }
            InitializeComponent();
            ListBoxCourses.ItemsSource = unsignedCourses;
        }
    }
}
