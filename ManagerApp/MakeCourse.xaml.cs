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
    /// Логика взаимодействия для MakeCourse.xaml
    /// </summary>
    public partial class MakeCourse : Window
    {
        int managerID;
        Course course;
        string connString;
        public MakeCourse(int managerID, string connString, Course course = null)
        {
            InitializeComponent();
            this.connString = connString;
            this.managerID = managerID;
            ComboBoxSubject.ItemsSource = DBUtils.GetSubjects(connString);
            ComboBoxTypeOfCourse.ItemsSource = DBUtils.GetTypeOfCourses(connString);
            if (course != null)
            {
                TextBoxName.Text = course.Name;
                TextBoxPrice.Text = course.Price.ToString();
                ComboBoxSubject.SelectedItem = ComboBoxSubject.Items.Cast<Subject>().ToList().First(x => x.ID == course.SubjectID);
                ComboBoxTypeOfCourse.SelectedItem = ComboBoxTypeOfCourse.Items.Cast<TypeOfCourse>().ToList().First(x => x.ID == course.TypeID);
                StartDatePicker.SelectedDate = course.StartDate;
                EndDatePicker.SelectedDate = course.EndDate;
                CheckBoxExam.IsChecked = course.FollowedByExam;
                CheckBoxRequirements.IsChecked = course.HasRequirements;
            }
            this.course = course;

        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonSubmit_Click(object sender, RoutedEventArgs e)
        {
            bool followedByExam = CheckBoxExam.IsChecked == true ? true : false;
            bool hasRequirements = CheckBoxRequirements.IsChecked == true ? true : false;
            try
            {
                if (course is null)
                {
                    if (DBUtils.AddCourse(TextBoxName.Text, (DateTime)StartDatePicker.SelectedDate, (DateTime)EndDatePicker.SelectedDate, double.Parse(TextBoxPrice.Text),
                        managerID, followedByExam, hasRequirements, ((TypeOfCourse)ComboBoxTypeOfCourse.SelectedItem).Name, ((Subject)ComboBoxSubject.SelectedItem).Name,connString) == 1)
                    {
                        MessageBox.Show("Course has been added to database");
                        Close();
                    }
                }
                else
                {
                    if (DBUtils.UpdateCourse(course, TextBoxName.Text, (DateTime)StartDatePicker.SelectedDate, (DateTime)EndDatePicker.SelectedDate, double.Parse(TextBoxPrice.Text),
                        managerID, followedByExam, hasRequirements, ((TypeOfCourse)ComboBoxTypeOfCourse.SelectedItem).Name, ((Subject)ComboBoxSubject.SelectedItem).Name, connString) == 1)
                    {
                        MessageBox.Show("Changes saved");
                        Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Fill in all the fields correctly");
            }
        }
    }
}
