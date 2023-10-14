using SimpleProject.Helpers;
using System;

namespace SimpleProject.DataObjects
{
    public class Patient
    {
        [Options("Ім'я", ColumnWidth = 100)]
        public string FirstName { get; set; }
        [Options("Прізвище", ColumnWidth = 100)]
        public string LastName { get; set; }
        [Options("Дата народження", ColumnWidth = 150)]
        public DateTime Birthday { get; set; }
        [Options("Номер палати", ColumnWidth = 120)]
        public int RoomNo { get; set; }
        [Options("Домашня адреса", ColumnWidth = 100, IsMultiline = true)]
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
