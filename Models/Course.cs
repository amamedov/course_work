﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ManagerID { get; set; }
        public DateTime StartDate { get ; set; }
        public DateTime EndDate { get; set; }
        public int TypeID { get; set; }
        public bool FollowedByExam { get; set; }
        public bool HasRequirements { get; set; }
        public double Price { get; set; }
        public int SubjectID { get; set; }
        public List<Lesson> Lessons { get; set; }
        public bool IsActive { get { return EndDate >= DateTime.Now; } }
        public string ShortStart { get { return StartDate.ToShortDateString(); } }
        public string ShortEnd { get { return EndDate.ToShortDateString(); } }

        public Course(int id, int subjectID, string name, int managerID, DateTime startDate, DateTime endDate, int typeID, bool followedByExam, bool hasRequirements, double price)
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
            Lessons = new List<Lesson>();
        }
        public override string ToString()
        {
            return Name+"  "+StartDate.ToShortDateString()+"-"+EndDate.ToShortDateString();
        }
        public string GridView { get { return $"{Name} {StartDate.ToShortDateString()} - {EndDate.ToShortDateString()}"; }}
    }
}
