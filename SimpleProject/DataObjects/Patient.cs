using SimpleProject.Helpers;
using System;

namespace SimpleProject.DataObjects
{
    public class Patient
    {
        [Options("Ім'я")]
        public string FirstName { get; set; }
        [Options("Прізвище")]
        public string LastName { get; set; }
        [Options("Дата народження")]
        public DateTime Birthday { get; set; }
        [Options("Номер палати")]
        public int RoomNo { get; set; }
        [Options("Домашня адреса", IsMultiline = true)]
        public string HomeAdress { get; set; }
        public Patient() { }
        public Patient(string firstName, string lastName, DateTime birthday, int roomNo, string homeAdress)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            RoomNo = roomNo;
            HomeAdress = homeAdress;
        }
    }
}
