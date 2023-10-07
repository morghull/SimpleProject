using System;

namespace SimpleProject.DataObjects
{
    public class Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public int RoomNo { get; set; }
        public string HomeAdress { get; set; }
        public Entity() { }

        public Entity(string firstName, string lastName, DateTime birthday, int roomNo, string homeAdress)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            RoomNo = roomNo;
            HomeAdress = homeAdress;
        }
    }
}
