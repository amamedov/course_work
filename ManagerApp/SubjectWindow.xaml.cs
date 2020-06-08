using Core;
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
    /// Логика взаимодействия для SubjectWindow.xaml
    /// </summary>
    public partial class SubjectWindow : Window
    {
        string connString;
        public SubjectWindow(string connString)
        {
            InitializeComponent();
            this.connString = connString;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DBUtils.AddSubject(TextBoxName.Text, connString) == 1)
                {
                    MessageBox.Show("Subject added");
                    Close();
                }
                else
                {
                    MessageBox.Show("That subject already exists");
                }
            }
            catch
            {
                MessageBox.Show("That subject already exists");
            }
        }
    }
}
