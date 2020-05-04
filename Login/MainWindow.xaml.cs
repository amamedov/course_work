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
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            var name = TextBoxName.Text;
            var surname = TextBoxSurname.Text;
            if (name=="super" && surname=="super")
            {
                //Owner App
            }
            else
            {
                if (repository.Students.Any(x => x.Name==name && x.Surname == surname))
                {
                    //Student App
                }
                else
                {
                    if (repository.Managers.Any(x => x.Name == name && x.Surname==surname))
                    {

                        var startInfo = new ProcessStartInfo();
                        startInfo.FileName = "../../../../ManagerApp/bin/Debug/netcoreapp3.1/ManagerApp.exe";
                        startInfo.WindowStyle = ProcessWindowStyle.Normal;
                        startInfo.Arguments = $"\"{connString}\"";
                        startInfo.ErrorDialog = true;
                        startInfo.CreateNoWindow = false;
                        startInfo.RedirectStandardOutput = true;
                        startInfo.UseShellExecute = false;
                        using (var process = Process.Start(startInfo).StandardOutput)
                        {

                            Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong credentials");
                    }
                }
            }
        }
    }
}
