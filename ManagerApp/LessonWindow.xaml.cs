using Core;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Логика взаимодействия для LessonWindow.xaml
    /// </summary>
    public partial class LessonWindow : Window
    {
        Repository repository;
        Course course;
        Lesson lesson = null;
        bool isUpdate = false;
        List<string> hours;
        List<string> minutes;

        public LessonWindow(Repository repository, Course course, Lesson lesson = null)
        {
            this.repository = repository;
            this.course = course;
            hours = new List<string>();
            for (int i = 0; i < 24; i++)
            {
                hours.Add(i.ToString().Length != 1 ? i.ToString() : $"0{i}");
            }
            minutes = new List<string>();
            for (int i = 0; i < 60; i++)
            {
                minutes.Add(i.ToString().Length != 1 ? i.ToString() : $"0{i}");
            }
            InitializeComponent();
            ComboBoxEndHour.ItemsSource = hours;
            ComboBoxEndHour.SelectedIndex = -1;
            ComboBoxStartHour.ItemsSource = hours;
            ComboBoxStartHour.SelectedIndex = -1;
            ComboBoxEndMinute.ItemsSource = minutes;
            ComboBoxEndMinute.SelectedIndex = -1;
            ComboBoxStartMinute.ItemsSource = minutes;
            ComboBoxStartMinute.SelectedIndex = -1;
            ComboBoxTeacher.ItemsSource = repository.Teachers;
            ComboBoxRoom.ItemsSource = repository.Rooms;
            if (lesson != null)
            {
                this.lesson = lesson;
                isUpdate = true;
                ComboBoxRoom.SelectedItem = ComboBoxRoom.Items.Cast<Room>().First(x => x.ID == lesson.RoomID);
                ComboBoxTeacher.SelectedItem = ComboBoxTeacher.Items.Cast<Teacher>().First(x => x.ID == lesson.TeacherID);
                DatePicker.SelectedDate = lesson.DTStart.Date;
                ComboBoxStartHour.SelectedItem = ComboBoxStartHour.Items.Cast<string>().First(x => int.Parse(x) == lesson.DTStart.Hour);
                ComboBoxStartMinute.SelectedItem = ComboBoxStartMinute.Items.Cast<string>().First(x => int.Parse(x) == lesson.DTStart.Minute);
                ComboBoxEndHour.SelectedItem = ComboBoxEndHour.Items.Cast<string>().First(x => int.Parse(x) == lesson.DTEnd.Hour);
                ComboBoxEndMinute.SelectedItem = ComboBoxEndMinute.Items.Cast<string>().First(x => int.Parse(x) == lesson.DTEnd.Minute);
            }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var teacherID = ((Teacher)ComboBoxTeacher.SelectedItem).ID;
                var roomID = ((Room)ComboBoxRoom.SelectedItem).ID;
                var courseID = course.ID;
                var dtStart = (DateTime)DatePicker.SelectedDate;
                var dtEnd = (DateTime)DatePicker.SelectedDate;
                dtEnd = dtEnd.AddHours(Convert.ToDouble(ComboBoxEndHour.SelectedItem));
                dtEnd = dtEnd.AddMinutes(Convert.ToDouble(ComboBoxEndMinute.SelectedItem));
                dtStart = dtStart.AddHours(Convert.ToDouble(ComboBoxStartHour.SelectedItem));
                dtStart = dtStart.AddMinutes(Convert.ToDouble(ComboBoxStartMinute.SelectedItem));
                if (dtEnd < course.EndDate || dtStart < course.StartDate)
                {
                    if (dtStart < dtEnd)
                    {
                        if (!isUpdate)
                        {
                            if (DBUtils.AddLesson(teacherID, courseID, roomID, dtStart, dtEnd, repository.ConnString) == 1)
                            {
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Enter correct information");
                            }
                        }
                        else
                        {
                            if (DBUtils.UpdateLesson(lesson.ID, teacherID, roomID, dtStart, dtEnd, repository.ConnString) == 1)
                            {
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Enter correct information");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Incorrect timespan");
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect date");
                }
            }
            catch
            {
                MessageBox.Show("Enter correct information");
            }
        }
    }
}
