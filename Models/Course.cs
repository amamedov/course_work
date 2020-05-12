using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ManagerID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TypeID { get; set; }
        public bool FollowedByExam { get; set; }
        public bool HasRequirements { get; set; }
        public double Price { get; set; }
        public int SubjectID { get; set; }
        public List<Lesson> Lessons { get; set; }
        public bool IsActive { get; set; }
        public string ToListBox { get { return $"Name: {Name}  Duration: {StartDate.ToShortDateString()} - {EndDate.ToShortDateString()} Price: {Price}"; } }

        public Course(int id, int subjectID, string name, int managerID, DateTime startDate, DateTime endDate, int typeID, bool followedByExam, bool hasRequirements, double price, bool isActive)
        {
            ID = id;
            Name = name;
            SubjectID = subjectID;
            ManagerID = managerID;
            StartDate = startDate;
            EndDate = endDate;
            TypeID = typeID;
            FollowedByExam = followedByExam;
            HasRequirements = hasRequirements;
            Price = price;
            IsActive = isActive;
            Lessons = new List<Lesson>();
        }
        public override string ToString()
        {
            return Name;
        }
        public string ForStudent { get { return $"{StartDate.ToShortDateString()} - {EndDate.ToShortDateString()}   {Name}  Price:{Price}"; }}
    }
}
