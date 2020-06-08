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
                int result = DBUtils.AddContract(TextBoxName.Text, TextBoxSurname.Text, (ComboBoxCourse.SelectedItem as Course).ID, managerID, repository.ConnString);
                if (result == 1)
                {
                    MessageBox.Show("Contract added to the database");
                    Close();
                }
                else
                {
                    MessageBox.Show("Something went wrong, contract has not been made, try again");
                    Close();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Student already has contract for this course");
            }

        }
    }
}
