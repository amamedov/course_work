﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class TypeOfCourse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
        public TypeOfCourse(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
