using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class StudentAttendance
    {
        public Student Student { get; set; }
        public List<Attendance> Attendances { get; set; }
        public StudentAttendance(Student student)
        {
            Student = student;
            Attendances = new List<Attendance>();
        }
    }
}
