using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using Core;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Runtime.CompilerServices;
using Models;

namespace ManagerApp
{
    /// <summary>
    /// Логика взаимодействия для MakeContractWindow.xaml
    /// </summary>
    public partial class MakeContractWindow : Window
    {
        int managerID;
        Repository repository;
        public MakeContractWindow(Repository repository, int managerID)
        {
            InitializeComponent();
            this.repository = repository;
            this.managerID = managerID;
            ComboBoxCourse.ItemsSource = repository.Courses;
            ComboBoxStudent.ItemsSource = repository.Students;
            ComboBoxStudent.SelectedIndex = -1;
            ComboBoxCourse.SelectedIndex = -1;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonMake_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var student = ComboBoxStudent.SelectedItem as Student;
                DBUtils.AddContract(student.Name, student.Surname, (ComboBoxCourse.SelectedItem as Course).ID, managerID, repository.ConnString);
                MessageBox.Show("Contract added to the database");
                repository.Contracts.Add(DBUtils.GetLastContract(repository));
                Close();
            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);
            }

        }
    }
}
