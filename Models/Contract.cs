using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Contract
    {
        public int ID { get; }
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public int CourseID { get; }
        public Course Course { get; set; }
        public int ManagerID { get; }
        public bool IsActive { get; }
        public bool IsPaid { get; set; }
        public DateTime DateTimeMade { get; }
        public Contract(int id, int student, int course, int managerID, bool isActive, bool isPaid, DateTime dateTime)
        {
            this.ID = id;
            this.StudentID = student;
            this.CourseID = course;
            this.ManagerID = managerID;
            this.IsActive = isActive;
            this.IsPaid = isPaid;
            this.DateTimeMade = dateTime;
        }
        public string ShortDate { get { return DateTimeMade.ToShortDateString() + " " + DateTimeMade.ToShortTimeString(); } }
    }
}
