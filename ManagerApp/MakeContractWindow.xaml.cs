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

namespace ManagerApp
{
    /// <summary>
    /// Логика взаимодействия для MakeContractWindow.xaml
    /// </summary>
    public partial class MakeContractWindow : Window
    {
        int managerID;
        string connString;
        public MakeContractWindow(int managerID, string connString)
        {
            InitializeComponent();
            this.connString = connString;
            this.managerID = managerID;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonMake_Click(object sender, RoutedEventArgs e)
        {
            int result = DBUtils.AddContract(TextBoxName.Text, TextBoxSurname.Text, TextBoxCourse.Text, managerID, connString);
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
    }
}
