﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Teacher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DoB { get; set; }
        public int PositionID { get; set; }
        public string Fullname
        {
            get
            {
                return $"{Name} {Surname}";
            }
        }
        public Teacher(int id, string name, string surname, DateTime dateTime, int positionID)
        {
            ID = id;
            Name = name;
            Surname = surname;
            DoB = dateTime;
            PositionID = positionID;
        }
        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }
}
