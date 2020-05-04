using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using Models;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace Core
{
    public static class DBUtils
    {
        //public static string connString = "Server=DESKTOP-1OJ7R9S\\SQLEXPRESS;Initial Catalog=Course Work_0;Integrated Security=True";
        public static int ExecuteNonQuery(string queryString, string connString)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public static int AddContract(string name, string surname, string course, int managerID, string connString)
        {
            string query = "declare @StudentID int = (select top 1 ID from Student where name='" + name + "' and surname='" + surname + "');" +
                "declare @CourseID int = (select top 1 ID from Course where name='" + course + "');" +
                "exec MakeContract @StudentID, @CourseID,  @ManagerID=" + managerID.ToString();
            return ExecuteNonQuery(query, connString);
        }


        public static List<Contract> GetContracts(string connString, int? managerID = null, int? studentID = null) //TODO: найти запросы с возвращаемыми строками
        {
            List<Contract> contracts = new List<Contract>();
            if (managerID != null)
            {
                var query = $"select * from Contract where ManagerID={managerID}";
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
            }
            else if (studentID != null)
            {
                var query = $"select * from Contract where StudentID={studentID}";
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
            }
            else
            {
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
            }
            return contracts;
        }

        public static int DeleteContract(Contract contract, string connString)
        {
            string query = "update Contract set IsActive=0 where id=" + contract.ID.ToString();
            return ExecuteNonQuery(query, connString);
        }

        public static int PayForContract(Contract contract, string connString)
        {
            string query = $"update Contract set IsPaid=1,IsActive=1 where id={contract.ID}";
            return ExecuteNonQuery(query, connString);
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

        public static List<Course> GetCourses(string connString, int? managerID = null, int? studentID = null, int? teacherID = null)
        {
            var courses = new List<Course>();
            if (managerID != null)
            {
                var query = $"select * from Course where ManagerID={managerID}";
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
            }
            return courses;
        }
        public static int AddCourse(string name, DateTime startDate, DateTime endDate, double price, int managerID, bool followedByExam,
            bool hasRequirements, string type, string subject, string connString)
        {
            string query = $"declare @typeID int = (select top 1 id from TypeOfCourse where name='{type}');" +
                $"declare @subjectID int = (select top 1 id from Subject where name='{subject}');" +
                $"insert into Course values ('{name}', @subjectID, '{startDate}', '{endDate}', {price}, " +
                $"{managerID}, {(followedByExam?1:0)}, {(hasRequirements?1:0)}, @typeID, 1)";
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
                $"ManagerID={managerID}, FollowedByExam={(followedByExam?1:0)}, HasRequirements={(hasRequirements?1:0)}, TypeOfCourseID=@typeID, IsActive = 1" +
                $"where ID={course.ID}";
            return ExecuteNonQuery(query, connString);
        }
        public static int AddSubject(string name, string connString)
        {
            var query = $"insert into Subject values ('{name}')";
            return ExecuteNonQuery(query, connString);
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
        public static int AddStudent(string name, string surname, DateTime dateTime, string gender, string connString)
        {
            var query = $"insert into Student values ('{name}', '{surname}', '{dateTime}', '{gender}')";
            return ExecuteNonQuery(query,connString);
        }

        public static int UpdateStudent(Student student, string connString)
        {
            var query = $"update Student set name='{student.Name}', surname='{student.Surname}', DateOfBirth = '{student.DoB}', gender='{student.Gender}' where id ={student.ID}";
            return ExecuteNonQuery(query, connString);
        }
    }
}
