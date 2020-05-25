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
        public PathWindow(Repository repository, Course course)
        {
            InitializeComponent();
            this.repository = repository;
            PathBox.Text = repository.OutputPath;
        }

        private void ButtonSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (PathBox.Text == null)
            {
                MessageBox.Show("Path can`t be empty");
            }
            else
            {
                if (Directory.Exists(System.IO.Path.GetDirectoryName(PathBox.Text))){
                    repository.OutputPath = PathBox.Text;
                    Close();
                }
                else
                {
                    MessageBox.Show("Invalid path");
                }
            }
        }

        private void ButtonCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, PathBox.Text as object);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PathBox.Text= Clipboard.GetText();
        }

        private void PathBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (PathBox.SelectionLength == 0)
                {
                    PathBox.SelectAll();
                }
            }
        } 
    }

