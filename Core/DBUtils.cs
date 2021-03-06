﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using Models;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using Microsoft.SqlServer.Management.Smo;

namespace Core
{
    public static class DBUtils
    {
        public static int ExecuteNonQuery(string queryString, string connString)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                return command.ExecuteNonQuery();
            }
        }
        #region create
        public static int AddContract(string name, string surname, int course, int managerID, string connString)
        {
            string query = "declare @StudentID int = (select top 1 ID from Student where name='" + name + "' and surname='" + surname + "');" +
                $"exec MakeContract @StudentID, @CourseId={course} ,  @ManagerID=" + managerID.ToString();
            return ExecuteNonQuery(query, connString);
        }
        public static int AddStudent(string name, string surname, DateTime dateTime, string gender, string connString)
        {
            var query = $"insert into Student values ('{name}', '{surname}', '{dateTime}', '{gender}')";
            return ExecuteNonQuery(query, connString);
        }

        public static int AddCourse(string name, DateTime startDate, DateTime endDate, double price, int managerID, bool followedByExam,
            bool hasRequirements, string type, string subject, string connString)
        {
            string query = $"declare @typeID int = (select top 1 id from TypeOfCourse where name='{type}');" +
                $"declare @subjectID int = (select top 1 id from Subject where name='{subject}');" +
                $"insert into Course values ('{name}', @subjectID, '{startDate}', '{endDate}', {price}, " +
                $"{managerID}, {(followedByExam ? 1 : 0)}, {(hasRequirements ? 1 : 0)}, @typeID)";
            return ExecuteNonQuery(query, connString);
        }
        public static int AddSubject(string name, string connString)
        {
            var query = $"insert into Subject values ('{name}')";
            return ExecuteNonQuery(query, connString);
        }
        public static int AddVideo(int length, string description, string connString, int lessonID)
        {
            var query = $"insert into Video values ({lessonID},{length},'{description}')";
            return ExecuteNonQuery(query, connString);
        }
        public static int AddLecture(string name, int number, string description, string connString, int lessonID)
        {
            var query = $"insert into Lecture values ({lessonID},'{name}',{number},'{description}')";
            return ExecuteNonQuery(query, connString);
        }
        public static int AddPrinted(string name, int number, string description, string connString, int lessonID)
        {
            var query = $"insert into PrintedMaterial values ({lessonID},'{name}',{number},'{description}')";
            return ExecuteNonQuery(query, connString);
        }
        public static int AddWebsite(string name, string url, string description, string connString, int lessonID)
        {
            var query = $"insert into WebSite values ({lessonID},'{name}','{url}','{description}')";
            return ExecuteNonQuery(query, connString);
        }
        public static int AddLesson(int teacherID, int courseID, int roomID, DateTime dtStart, DateTime dtEnd, string connString)
        {
            var query = $"insert into Lesson values ({teacherID},{courseID},{roomID}, '{dtStart}','{dtEnd}')";
            return ExecuteNonQuery(query, connString);
        }
        #endregion
        #region update
        public static int PayForContract(Contract contract, string connString)
        {
            string query = $"update Contract set IsPaid=1 where id={contract.ID}";
            return ExecuteNonQuery(query, connString);
        }
        public static int DeleteCourse(Course course, string connString)
        {
            string query = $"update Course set isActive=0 where ID={course.ID}";
            return ExecuteNonQuery(query, connString);
        }
        public static int UpdateCourse(Course course, string name, DateTime startDate, DateTime endDate, double price, int managerID, bool followedByExam,
            bool hasRequirements, string type, string subject, string connString)
        {
            string query = $"declare @typeID int = (select top 1 id from TypeOfCourse where name='{type}');" +
                $"declare @subjectID int = (select top 1 id from Subject where name='{subject}');" +
                $"update Course set name='{name}', subjectID=@subjectID, StartDate='{startDate}', EndDate='{endDate}', Price = {price}, " +
                $"ManagerID={managerID}, FollowedByExam={(followedByExam ? 1 : 0)}, HasRequirements={(hasRequirements ? 1 : 0)}, TypeOfCourseID=@typeID" +
                $" where ID={course.ID}";
            return ExecuteNonQuery(query, connString);
        }
        public static int UpdateLesson(int id, int teacherID, int roomID, DateTime dtStart, DateTime dtEnd, string connString)
        {
            var query = $"update Lesson " +
                $"set TeacherID = {teacherID}, RoomID = {roomID}, DTStart = '{dtStart}', DTEnd='{dtEnd}'" +
                $"where id = {id}";
            return ExecuteNonQuery(query, connString);
        }
        public static void UpdateAttendance(StudentAttendance studentAttendance, string connString)
        {
            foreach (var attendance in studentAttendance.Attendances)
            {
                var query = $"Delete from attendance where StudentId={studentAttendance.Student.ID} and LessonID={attendance.Lesson.ID}";
                ExecuteNonQuery(query, connString);
                if (attendance.Attended)
                {
                    query = $"Insert into Attendance values ({studentAttendance.Student.ID}, {attendance.Lesson.ID})";
                    ExecuteNonQuery(query, connString);
                }
            }
        }
        #endregion
        #region DataImport
        public static List<Contract> GetContracts(string connString)
        {
            List<Contract> contracts = new List<Contract>();

            var query = $"select * from Contract";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var contract = new Contract(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3),
                        reader.GetBoolean(4), reader.GetBoolean(6), reader.GetDateTime(7));
                    contracts.Add(contract);
                }

            }

            return contracts;
        }
        public static Contract GetLastContract(Repository repository)
        {
            var query = $"select top 1 * from Contract order by id desc";
            using (SqlConnection connection = new SqlConnection(repository.ConnString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Connection.Open();
                var reader = command.ExecuteReader();
                reader.Read();
                var contract = new Contract(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3),
                    reader.GetBoolean(4), reader.GetBoolean(6), reader.GetDateTime(7));
                contract.Course = repository.Courses.First(x => x.ID == contract.CourseID);
                contract.Student = repository.Students.First(x => x.ID == contract.StudentID);
                return contract;
            }
        }
        public static List<Lesson> GetLessons(string connString)
        {
            var lessons = new List<Lesson>();
            var query = "select * from Lesson";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var lesson = new Lesson(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3),
                        reader.GetDateTime(4), reader.GetDateTime(5));
                    lessons.Add(lesson);
                }
            }
            return lessons;
        }
        public static List<Building> GetBuildings(string connString)
        {
            List<Building> buildings = new List<Building>();

            var query = $"select * from Building";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var building = new Building(reader.GetInt32(0), reader.GetString(1));
                    buildings.Add(building);
                }

            }

            return buildings;
        }
        public static List<Room> GetRooms(string connString)
        {
            List<Room> rooms = new List<Room>();

            var query = $"select * from Room";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var room = new Room(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3));
                    rooms.Add(room);
                }

            }

            return rooms;
        }
        public static List<Student> GetStudents(string connString)
        {
            var students = new List<Student>();
            var query = $"select * from Student";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var student = new Student(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetString(4));
                    students.Add(student);
                }
                return students;
            }
        }
        public static Student GetLastStudents(Repository repository)
        {
            var query = $"select top 1 * from Student order by id desc";
            using (SqlConnection connection = new SqlConnection(repository.ConnString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Connection.Open();
                var reader = command.ExecuteReader();
                reader.Read();
                var student = new Student(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetString(4));
                return student;
            }
        }
        public static List<Manager> GetManagers(string connString)
        {
            var managers = new List<Manager>();
            var query = "select * from Employee as e join Manager as m on m.EmployeeID = e.ID";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var manager = new Manager(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetInt32(6));
                    managers.Add(manager);
                }
                return managers;
            }
        }
        public static List<Teacher> GetTeachers(string connString)
        {
            var teachers = new List<Teacher>();
            var query = "select * from Employee as e join Teacher as t on t.EmployeeID = e.ID";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var teacher = new Teacher(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetInt32(6));
                    teachers.Add(teacher);
                }
                return teachers;
            }
        }

        public static List<Course> GetCourses(string connString)
        {
            var courses = new List<Course>();

            var query = $"select * from Course";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var course = new Course(reader.GetInt32(0), reader.GetInt32(2), reader.GetString(1), reader.GetInt32(6), reader.GetDateTime(3), reader.GetDateTime(4),
                        reader.GetInt32(9), reader.GetBoolean(7), reader.GetBoolean(8), reader.GetDouble(5));
                    courses.Add(course);
                }
            }

            return courses;
        }
        public static Course GetLastCourse(Repository repository)
        {
            var query = $"select top 1 * from Course order by id desc";
            using (SqlConnection connection = new SqlConnection(repository.ConnString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Connection.Open();
                var reader = command.ExecuteReader();
                reader.Read();


                var course = new Course(reader.GetInt32(0), reader.GetInt32(2), reader.GetString(1), reader.GetInt32(6), reader.GetDateTime(3), reader.GetDateTime(4),
                    reader.GetInt32(9), reader.GetBoolean(7), reader.GetBoolean(8), reader.GetDouble(5));


                return course;
            }
        }
        public static List<Subject> GetSubjects(string connString)
        {
            var subjects = new List<Subject>();
            var query = "select * from Subject";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var subject = new Subject(reader.GetInt32(0), reader.GetString(1));
                    subjects.Add(subject);
                }
            }
            return subjects;
        }
        public static List<TypeOfCourse> GetTypeOfCourses(string connString)
        {
            var types = new List<TypeOfCourse>();
            var query = "select * from TypeOfCourse";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                var command = new SqlCommand(query, connection);
                command.Connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var type = new TypeOfCourse(reader.GetInt32(0), reader.GetString(1));
                    types.Add(type);
                }
            }
            return types;
        }
        public static int UpdateStudent(string name, string surname, DateTime doB, string gender, Student student, string connString)
        {
            var query = $"update Student set name='{name}', surname='{surname}', DateOfBirth = '{doB}', gender='{gender}' where id ={student.ID}";
            return ExecuteNonQuery(query, connString);
        }
        public static void GetAttendance(Lesson lesson, string connString)
        {
            var query = $"select * from Attendance where LessonID={lesson.ID}";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    (lesson.Attendance as IDictionary<string, object>).Add(reader.GetInt32(0).ToString(), true);
                }
            }
        }
        #endregion
    }
}
