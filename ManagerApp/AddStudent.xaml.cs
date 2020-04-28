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
        string connString;
        public AddStudent(string connString,Student student=null)
        {
            InitializeComponent();
            this.connString = connString;
            var genders = new List<string>();
            genders.Add("Male");
            genders.Add("Female");
            ComboBoxGender.ItemsSource = genders;
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
            try
            {
                if(student == null)
                if (DBUtils.AddStudent(TextBoxName.Text, TextBoxSurname.Text, (DateTime)DatePickerDOB.SelectedDate, (string)ComboBoxGender.SelectedItem, connString) == 1)
                {
                    MessageBox.Show("Changes saved to database");
                    Close();
                }
                else
                {
                    MessageBox.Show("Fill all the fields correctly");
                }
                else
                {
                    student.Name = TextBoxName.Text;
                    student.Surname = TextBoxSurname.Text;
                    student.DoB =(DateTime) DatePickerDOB.SelectedDate;
                    student.Gender =(string) ComboBoxGender.SelectedItem;
                    DBUtils.UpdateStudent(student, connString);
                    MessageBox.Show("Changes saved to database");
                    Close();
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Fill all the fields correctly");
            }
        }
    }
}
