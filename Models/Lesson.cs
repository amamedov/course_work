﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Dynamic;

namespace Models
{
    public class Lesson
    {
        public int ID { get; set; }
        public int TeacherID { get; set; }
        public int CourseID { get; set; }
        public int RoomID { get; set; }
        public DateTime DTStart { get; set; }
        public DateTime DTEnd { get; set; }
        public Teacher Teacher { get; set; }
        public Course Course { get; set; }
        public Room Room { get; set; }
        public ExpandoObject Attendance { get; set; }
        public bool VisibleForExtra { get; set; }
        public Lesson(int id, int teacherID, int courseID, int roomID, DateTime dtStart, DateTime dtEnd)
        {
            Attendance = new ExpandoObject();
            ID = id;
            TeacherID = teacherID;
            CourseID = courseID;
            RoomID = roomID;
            DTStart = dtStart;
            DTEnd = dtEnd;
            VisibleForExtra = false;
        }
        public int Duration
        {
            get
            {
                return (DTEnd - DTStart).Minutes + (DTEnd - DTStart).Hours*60;
            }
        }

        public string StartTime
        {
            get
            {
                return DTStart.ToShortTimeString();
            }
        }
        public string Date
        {
            get
            {
                return DTStart.ToShortDateString();
            }
        }
        public override string ToString()
        {
            return $"{Date} {DTStart.ToShortTimeString()} - {DTEnd.ToShortTimeString()} Address: {Room.Building.Address},{Room.Name}";
        }
        public string TeacherTimetable { get {return $"{Date} {DTStart.ToShortTimeString()} - {DTEnd.ToShortTimeString()} Address: {Room.Building.Address},{Room.Name}"; } }
    }
}
