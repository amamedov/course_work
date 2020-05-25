using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Core;
using Models;

namespace Login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Repository repository;
        string connString;
        public MainWindow(string connString)
        {
            InitializeComponent();
            repository = new Repository(connString);
            this.connString = connString;
            TextBoxName.Focus();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            var name = TextBoxName.Text;
            var surname = TextBoxSurname.Password;

            if (repository.Teachers.Any(x => x.Name == name && x.Surname == surname))
            {
                var teacherApp = new TeacherApp.MainWindow(repository, repository.Teachers.First(x => x.Name == name && x.Surname == surname));
                Hide();
                teacherApp.Show();
                TextBoxName.Text = "";
                TextBoxSurname.Password = "";
                Close();
            }
            else
            {
                if (repository.Managers.Any(x => x.Name == name && x.Surname == surname))
                {
                    var managerApp = new cOURSEwoRK.ManagerMainWindow(connString, repository, repository.Managers.First(x => x.Name == name && x.Surname == surname).ID);

                    managerApp.Show();
                    TextBoxName.Text = "";
                    TextBoxSurname.Password = "";
                    Close();
                }
                else
                {
                    if (repository.Students.Any(x => x.Name == name && x.Surname == surname))
                    {
                        var studentApp = new StudentApp.MainWindow(repository, repository.Students.First(x => x.Name == name && x.Surname == surname));
                        studentApp.Show();
                        TextBoxName.Text = "";
                        TextBoxSurname.Password = "";
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Wrong credentials");
                    }
                }
            }
        }

        private void TextBoxSurname_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as PasswordBox).SelectAll();
        }

        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            var sWindow = new SettingsWindow(repository);
            sWindow.ShowDialog();
        }
    }
}
