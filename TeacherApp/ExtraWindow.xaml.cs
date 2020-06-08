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

namespace TeacherApp
{
    /// <summary>
    /// Логика взаимодействия для ExtraWindow.xaml
    /// </summary>
    public partial class ExtraWindow : Window
    {
        Repository Repository;
        Lesson Lesson;
        public ExtraWindow(Repository repository, Lesson lesson)
        {
            InitializeComponent();
            Lesson = lesson;
            Repository = repository;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Video.Visibility == Visibility.Visible)
            {
                if (int.TryParse(VideoLength.Text, out int length))
                {
                    DBUtils.AddVideo(length, VideoDescr.Text.Length ==0? "":VideoDescr.Text, Repository.ConnString, Lesson.ID);
                    Close();
                }
                else
                {
                    MessageBox.Show("Incorrect video length");
                }
            }
            if (Website.Visibility == Visibility.Visible)
            {
                if (WebsiteName.Text.Length>0&&WebsiteURL.Text.Length>0)
                {
                    DBUtils.AddWebsite(WebsiteName.Text, WebsiteURL.Text, WebsiteDescr.Text.Length == 0 ? "" :WebsiteDescr.Text, Repository.ConnString, Lesson.ID);
                    Close();
                }
                else
                {
                    MessageBox.Show("Fill information correctly");
                }
            }
            if (Printed.Visibility == Visibility.Visible)
            {
                if (PrintedName.Text.Length > 0 && int.TryParse(PrintedPages.Text, out int number))
                {
                    DBUtils.AddPrinted(PrintedName.Text, number, PrintedDescr.Text.Length == 0 ? "" :PrintedDescr.Text, Repository.ConnString, Lesson.ID);
                    Close();
                }
                else
                {
                    MessageBox.Show("Fill information correctly");
                }
            }
            if (Lecture.Visibility == Visibility.Visible)
            {
                if (LectureName.Text.Length > 0 && int.TryParse(LectureSlides.Text, out int number))
                {
                    DBUtils.AddLecture(LectureName.Text, number, LectureDescr.Text.Length == 0 ? "" :LectureDescr.Text, Repository.ConnString, Lesson.ID);
                    Close();
                }
                else
                {
                    MessageBox.Show("Fill information correctly");
                }
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Video.Visibility = Visibility.Hidden;
            Website.Visibility = Visibility.Hidden;
            Lecture.Visibility = Visibility.Hidden;
            Printed.Visibility = Visibility.Hidden;
            var radbtn = sender as RadioButton;
            var grid = this.FindName(radbtn.Content.ToString().Split(' ')[0]) as Grid;
            grid.Visibility = Visibility.Visible;
        }
    }
}
