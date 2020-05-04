using System;
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
        public Teacher(int id, string name, string surname, DateTime dateTime)
        {
            ID = id;
            Name = name;
            Surname = surname;
            DoB = dateTime;
        }
    }
}
