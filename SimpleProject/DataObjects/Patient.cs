using SimpleProject.Helpers;
using System;

namespace SimpleProject.DataObjects
{
    //приклад створення класу для обєктів умовних "пацієнтів"
    //концепція така: є сутність Пацієнт, він має певні властивості(property)
    //кожній властивості сутності відповідає властивість класу
    //що надалі буде зберігати значення цих властивостей первного типу
    //за допомогою класу для кастомного анотацій для властивостей
    //ми визначаємо додаткові так звані "опції" для властивостей
    //це - заголовок, ширина стовпця для гріду відображення
    //та булеве значення - чи властивість класу містить довгий текст (чи потрібно розширяти поле вводу цього тексту)
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
        /// <summary>
        /// метод-конструктор без параметрів
        /// </summary>
        public Patient() { }
        /// <summary>
        /// метод-конструктор з початковими значеннями властивостей
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="birthday"></param>
        /// <param name="roomNo"></param>
        /// <param name="homeAdress"></param>
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
