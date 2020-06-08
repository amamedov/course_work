using Core;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Dynamic;
using System.Windows.Controls.Ribbon;
using System.Data;
using ClosedXML.Excel;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TeacherApp
{
    /// <summary>
    /// Логика взаимодействия для StudentListWindow.xaml
    /// </summary>

    public partial class StudentListWindow : System.Windows.Window
    {
        Repository repository;
        Course course;
        bool Unsaved;
        public StudentListWindow(Repository repository, Course course, List<Lesson> lessons)
        {
            InitializeComponent();
            Unsaved = false;
            this.repository = repository;
            this.course = course;
            var rows = new ObservableCollection<StudentAttendance>();
            foreach (var student in repository.Students.Where(x => repository.Contracts.Where(y => y.StudentID == x.ID).Any(z => z.CourseID == course.ID)))
            {
                var row = new StudentAttendance(student);
                rows.Add(row);
            }
            StudentList.Columns.Add(new DataGridTextColumn { Header = "Student", Binding = new Binding("Student.FullName"), FontSize = 16, IsReadOnly = true });
            int i = 0;
            foreach (var lesson in lessons)
            {
                var name = lesson.DTStart.ToShortDateString() + " " + lesson.DTStart.ToShortTimeString();
                foreach (var row in rows)
                {
                    row.Attendances.Add(new Attendance { Lesson = lesson, Attended = (lesson.Attendance as IDictionary<string, object>).Contains(new KeyValuePair<string, object>(row.Student.ID.ToString(), true)) });
                }
                StudentList.Columns.Add(new DataGridCheckBoxColumn { Header = name, Binding = new Binding($"Attendances[{i}].Attended") });
                i++;
            }
            StudentList.ItemsSource = rows;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonChangePath_Click(object sender, RoutedEventArgs e)
        {
            var pathWindow = new PathWindow(repository);
            pathWindow.ShowDialog();
        }

        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            ButtonSave.IsEnabled = false;
            StudentList.IsReadOnly = true;
            await Task.Run(() => ExportToXL(course));
            StudentList.IsReadOnly = false;
            ButtonSave.IsEnabled = true;
        }

        private void ExportToXL(Course course)
        {
            var dataTable = new DataTable($"{course.Name} {course.StartDate.ToShortDateString()} - {course.EndDate.ToShortDateString()}");
            dataTable.Columns.Add(new DataColumn("Student"));
            foreach (var item in (StudentList.Items[0] as StudentAttendance).Attendances)
            {
                dataTable.Columns.Add(item.Lesson.DTStart.ToShortDateString() + " " + item.Lesson.DTStart.ToShortTimeString());
            }
            foreach (var row in StudentList.ItemsSource)
            {
                var rowasD = (row as StudentAttendance);
                var drow = new object[dataTable.Columns.Count];
                drow[0] = rowasD.Student.FullName;
                for (int i = 1; i < dataTable.Columns.Count; i++)
                {
                    drow[i] = rowasD.Attendances[i - 1].Attended ? "P" : "A";
                }
                dataTable.Rows.Add(drow);
            }
            using (var workbook = new XLWorkbook())
            {
                workbook.AddWorksheet(dataTable);
                foreach (var worksheet in workbook.Worksheets)
                {
                    foreach (var column in worksheet.Columns())
                    {
                        column.AdjustToContents();
                    }
                }
                try
                {
                    workbook.SaveAs($"{repository.OutputPath}\\{course.Name}_{course.StartDate.Day}_{course.StartDate.Month}_{course.StartDate.Year}-{course.EndDate.Day}_{course.EndDate.Month}_{course.EndDate.Year}.xlsx");
                    MessageBox.Show($"Saved to '{repository.OutputPath}\\{course.Name}_{course.StartDate.Day}_{course.StartDate.Month}_{course.StartDate.Year}-{course.EndDate.Day}_{course.EndDate.Month}_{course.EndDate.Year}.xlsx'");
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }
        private async void ButtonSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            ButtonSaveChanges.IsEnabled = false;
            StudentList.IsReadOnly = true;
            foreach (var studentAttendance in StudentList.ItemsSource)
            {
                await Task.Run(() => DBUtils.UpdateAttendance(studentAttendance as StudentAttendance, repository.ConnString));
            }
            repository.UpdateAttendance();
            ButtonSaveChanges.IsEnabled = true;
            StudentList.IsReadOnly = false;
        }

        private void StudentList_CurrentCellChanged(object sender, EventArgs e)
        {
            Unsaved = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Unsaved) {
                var result = MessageBox.Show("Save changes?", "Unsaved changes", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes) ButtonSaveChanges_Click(sender, new RoutedEventArgs());
            }

        }
    }
}


