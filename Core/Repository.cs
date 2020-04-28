using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public class Repository
    {
        public List<Contract> Contracts { get; set; }
        public List<Student> Students { get; set; }
        public List<Course> Courses { get; set; }
        public string ConnString { get; set; }
        public Repository(string connString)
        {
            ConnString = connString;
            Students = DBUtils.GetStudents(connString);
        }

        public void UpdateContracts(int? managerID=2,int? studentID=null)
        {
            if (managerID != null){
                Contracts = DBUtils.GetContracts(ConnString, managerID:managerID);
                foreach (var contract in Contracts)
                {
                    contract.Student = Students.First(x => x.ID == contract.StudentID);
                    contract.Course = Courses.First(x => x.ID == contract.CourseID);
                }
            }
        }
        public void UpdateCourses(int? managerID=null, int? studentID=null, int? teacherID = null)
        {
            if (managerID != null)
            {
                Courses = DBUtils.GetCourses(ConnString, managerID: managerID);
            }
        }
        public void UpdateStudents()
        {
            Students = DBUtils.GetStudents(ConnString);
        }
    }
}
