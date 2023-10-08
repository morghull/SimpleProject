using SimpleProject.Helpers;
using System;

namespace SimpleProject.DataObjects
{
    public class Patient
    {
        [Title("Ім'я")]
        public string FirstName { get; set; }
        [Title("Прізвище")]
        public string LastName { get; set; }
        [Title("Дата народження")]
        public DateTime Birthday { get; set; }
        [Title("Номер палати")]
        public int RoomNo { get; set; }
        [Title("Домашня адреса")]
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
