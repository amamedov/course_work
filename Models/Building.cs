using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Building
    {
        public int ID { get; set; }
        public string Address { get; set; }
        public Building(int id, string address)
        {
            ID = id;
            Address = address;
        }
    }
}
