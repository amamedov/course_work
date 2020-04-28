using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Models
{
    public class Subject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Subject(int id, string name)
        {
            ID = id;
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
