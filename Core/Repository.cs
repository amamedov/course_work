using Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Core
{
    public class Repository
    {
        public string OutputPath { get; set; }
        public List<Contract> Contracts { get; set; }
        public List<Student> Students { get; set; }
        public List<Course> Courses { get; set; }
        public List<Manager> Managers { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<TypeOfCourse> TypeOfCourses { get; set; }
        public string ConnString { get; set; }
        public List<Building> Buildings { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Lesson> Lessons { get; set; }
        public Repository(string connString)
        {
           
            ConnString = connString;
            PrepareData();
        }
        public void PrepareData()
        {
            Students = DBUtils.GetStudents(ConnString).OrderBy(x => x.Name).ThenBy(x => x.Surname).ToList();
            Managers = DBUtils.GetManagers(ConnString);
            Teachers = DBUtils.GetTeachers(ConnString).OrderBy(x => x.Name).ThenBy(x => x.Surname).ToList();
            Courses = DBUtils.GetCourses(ConnString).OrderBy(x => x.Name).ThenBy(x => x.StartDate).ToList();
            Contracts = DBUtils.GetContracts(ConnString);
            Subjects = DBUtils.GetSubjects(ConnString);
            TypeOfCourses = DBUtils.GetTypeOfCourses(ConnString);
            Buildings = DBUtils.GetBuildings(ConnString);
            Rooms = DBUtils.GetRooms(ConnString);
            Lessons = DBUtils.GetLessons(ConnString);
            foreach (var room in Rooms)
            {
                room.Building = Buildings.First(x => x.ID == room.BuildingID);
            }
            foreach (var lesson in Lessons)
            {
                lesson.Course = Courses.First(x => x.ID == lesson.CourseID);
                lesson.Teacher = Teachers.First(x => x.ID == lesson.TeacherID);
                lesson.Room = Rooms.First(x => x.ID == lesson.RoomID);
                UpdateAttendance();
            }
            foreach (var contract in Contracts)
            {
                contract.Course = Courses.First(x => x.ID == contract.CourseID);
                contract.Student = Students.First(x => x.ID == contract.StudentID);
            }
        }

       public void UpdateAttendance()
        {
            foreach (var lesson in Lessons)
            {
                lesson.Attendance = new ExpandoObject();
                DBUtils.FillAttendance(lesson, ConnString);
            }
        }
        public void UpdateContracts()
        {
            Contracts = DBUtils.GetContracts(ConnString);
            foreach (var contract in Contracts)
            {
                contract.Student = Students.First(x => x.ID == contract.StudentID);
                contract.Course = Courses.First(x => x.ID == contract.CourseID);
            }
        }
        public void UpdateCourses()
        {
            Courses = DBUtils.GetCourses(ConnString).OrderBy(x => x.Name).ThenBy(x => x.StartDate).ToList();
        }
        public void UpdateStudents()
        {
            Students = DBUtils.GetStudents(ConnString).OrderBy(x => x.Name).ThenBy(x => x.Surname).ToList();
        }

        public void UpdateManagers()
        {
            Managers = DBUtils.GetManagers(ConnString);
        }
        public void UpdateTeachers()
        {
            Teachers = DBUtils.GetTeachers(ConnString).OrderBy(x => x.Name).ThenBy(x => x.Surname).ToList();
        }
        public void UpdateSubjects()
        {
            Subjects = DBUtils.GetSubjects(ConnString);
        }
        public void UpdateLessons()
        {
            Lessons = DBUtils.GetLessons(ConnString);
            foreach (var lesson in Lessons)
            {
                lesson.Course = Courses.First(x => x.ID == lesson.CourseID);
                lesson.Teacher = Teachers.First(x => x.ID == lesson.TeacherID);
                lesson.Room = Rooms.First(x => x.ID == lesson.RoomID);
            }
        }
    }
}
