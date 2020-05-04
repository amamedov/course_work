using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public bool IsComputerClass { get; set; }
        public bool HasWhiteBoard { get; set; }
        public int BuildingID { get; set; }
        public Building Building { get; set; }
        public Room(int id, string name, int capacity, bool computer, bool whiteboard, int buildingid)
        {
            ID = id;
            Name = name;
            Capacity = capacity;
            IsComputerClass = computer;
            HasWhiteBoard = whiteboard;
            BuildingID = buildingid;
        }
        public override string ToString()
        {
            return $"{Building.Address},{Name}";
        }
    }
}
