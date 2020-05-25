using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DoB { get; set; }
        public string Gender { get; set; }

        public string FullName { get { return Name + " " + Surname; } set { Name = FullName.Split(' ')[0]; Surname = FullName.Split(' ')[1];  } }

        public Student(int id, string name, string surname, DateTime doB, string gender)
        {
            ID = id;
            Name = name;
            Surname = surname;
            DoB = doB;
            Gender = gender;
        }

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }
}
