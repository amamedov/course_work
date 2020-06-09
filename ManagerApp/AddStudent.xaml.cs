using Core;
using Models;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        Student student = null;
        Repository repository;
        public AddStudent(Repository repository,Student student=null)
        {
            InitializeComponent();
            this.repository = repository;
            var genders = new List<string>();
            genders.Add("Male");
            genders.Add("Female");
            ComboBoxGender.ItemsSource = genders;
            ComboBoxGender.SelectedIndex = -1;
            if (student != null)
            {
                this.student = student;
                TextBoxName.Text = student.Name;
                TextBoxSurname.Text = student.Surname;
                DatePickerDOB.SelectedDate = student.DoB;
                ComboBoxGender.SelectedItem = student.Gender;
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (DatePickerDOB.SelectedDate != null && TextBoxName.Text.Length > 0 && TextBoxSurname.Text.Length > 0 && ComboBoxGender.SelectedIndex !=-1)
            {


                if (((DateTime)DatePickerDOB.SelectedDate).Date < DateTime.Now.Date)
                {
                    try
                    {
                        if (student == null)
                            if (DBUtils.AddStudent(TextBoxName.Text, TextBoxSurname.Text, (DateTime)DatePickerDOB.SelectedDate, (string)ComboBoxGender.SelectedItem, repository.ConnString) == 1)
                            {
                                MessageBox.Show("Changes saved to database");
                                repository.Students.Add(DBUtils.GetLastStudents(repository));
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Fill all the fields correctly");
                            }
                        else
                        {
                            DBUtils.UpdateStudent(TextBoxName.Text, TextBoxSurname.Text, (DateTime)DatePickerDOB.SelectedDate, (string)ComboBoxGender.SelectedItem, student, repository.ConnString);
                            student.Name = TextBoxName.Text;
                            student.Surname = TextBoxSurname.Text;
                            student.DoB = (DateTime)DatePickerDOB.SelectedDate;
                            student.Gender = (string)ComboBoxGender.SelectedItem;
                            MessageBox.Show("Changes saved to database");
                            Close();
                        }


                    }
                    catch (Exception)
                    {
                        MessageBox.Show("This student`s account already exists.");
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect date of birth");
                }
            }
            else
            {
                MessageBox.Show("Fill all fields");
            }
        }
    }
}
