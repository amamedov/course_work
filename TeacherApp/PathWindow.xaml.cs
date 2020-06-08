using Core;
using Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TeacherApp
{
    /// <summary>
    /// Логика взаимодействия для PathWindow.xaml
    /// </summary>
    public partial class PathWindow : Window
    {
        Repository repository;
        public PathWindow(Repository repository)
        {
            InitializeComponent();
            PathBox.Text = repository.OutputPath??"Choose file";
            this.repository = repository;
        }

        private void ButtonSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (PathBox.Text == "Choose file")
            {
                System.Windows.Forms.MessageBox.Show("Path can`t be empty");
            }
            else
            {
                repository.OutputPath = PathBox.Text;
                Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                var result = fbd.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    PathBox.Text = fbd.SelectedPath;
                }
            }
        }
    }
}

