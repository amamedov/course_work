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
        Repository repository;
        public MakeCourse(int managerID, string connString, Repository repository, Course course = null)
        {
            InitializeComponent();
            this.repository = repository;
            this.connString = connString;
            this.managerID = managerID;
            ComboBoxSubject.ItemsSource = repository.Subjects;
            ComboBoxTypeOfCourse.ItemsSource = repository.TypeOfCourses;
            if (course != null)
            {
                head.Text = "Update course info";
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
            if (StartDatePicker.SelectedDate <= EndDatePicker.SelectedDate)
            {
                if (double.TryParse(TextBoxPrice.Text, out double a))
                {
                    bool followedByExam = CheckBoxExam.IsChecked == true ? true : false;
                    bool hasRequirements = CheckBoxRequirements.IsChecked == true ? true : false;
                    if (course is null)
                    {
                        try
                        {
                            if (DBUtils.AddCourse(TextBoxName.Text, (DateTime)StartDatePicker.SelectedDate, (DateTime)EndDatePicker.SelectedDate, double.Parse(TextBoxPrice.Text),
                                managerID, followedByExam, hasRequirements, ((TypeOfCourse)ComboBoxTypeOfCourse.SelectedItem).Name, ((Subject)ComboBoxSubject.SelectedItem).Name, connString) == 1)
                            {
                                MessageBox.Show("Course has been added to database");
                                repository.Courses.Add(DBUtils.GetLastCourse(repository));
                                Close();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Such course already exists");
                        }
                    }
                    else
                    {
                        try
                        {
                            if (DBUtils.UpdateCourse(course, TextBoxName.Text, (DateTime)StartDatePicker.SelectedDate, (DateTime)EndDatePicker.SelectedDate, double.Parse(TextBoxPrice.Text),
                           managerID, followedByExam, hasRequirements, ((TypeOfCourse)ComboBoxTypeOfCourse.SelectedItem).Name, ((Subject)ComboBoxSubject.SelectedItem).Name, connString) == 1)
                            {
                                course.Name = TextBoxName.Text;
                                course.StartDate = (DateTime)StartDatePicker.SelectedDate;
                                course.EndDate = (DateTime)EndDatePicker.SelectedDate;
                                course.Price = double.Parse(TextBoxPrice.Text);
                                course.FollowedByExam = followedByExam;
                                course.HasRequirements = hasRequirements;
                                course.TypeID = ((TypeOfCourse)ComboBoxTypeOfCourse.SelectedItem).ID;
                                course.SubjectID = ((Subject)ComboBoxSubject.SelectedItem).ID;
                                MessageBox.Show("Changes saved");
                                Close();
                            }
                        }
                        catch (Exception x)
                        {
                            MessageBox.Show(x.Message);
                            MessageBox.Show("Such course already exists");
                        }

                    }

                }
                else
                {
                    MessageBox.Show("Invalid price value");
                }
            }
            else
            {
                MessageBox.Show("Pick correct dates");
            }
        }
    }
}
