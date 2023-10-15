using SimpleProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProject.DataObjects
{
    //приклад створення класу для обєктів умовних "фільмів"
    //концепція така: є сутність Фільм, він має певні властивості(property)
    //кожній властивості сутності відповідає властивість класу
    //що надалі буде зберігати значення цих властивостей первного типу
    //за допомогою класу для кастомного анотацій для властивостей
    //ми визначаємо додаткові так звані "опції" для властивостей
    //це - заголовок, ширина стовпця для гріду відображення
    //та булеве значення - чи властивість класу містить довгий текст (чи потрібно розширяти поле вводу цього тексту)
    public class Movie
    {
        [Options("Назва", ColumnWidth = 150)]
        public string Name { get; set; }
        [Options("Назва мовою оригіналу", ColumnWidth = 180)]
        public string OriginalName { get; set; }
        [Options("Дата релізу", ColumnWidth = 100)]
        public DateTime ReleaseDate { get; set; }
        [Options("Ім'я файлу постеру", ColumnWidth = 200)]
        public string PosterImageName { get; set; }
        /// <summary>
        /// метод конструктор без параметрів
        /// </summary>
        public Movie() { }
        /// <summary>
        /// метод-конструктор з початковими значеннями властивостей
        /// </summary>
        /// <param name="name"></param>
        /// <param name="originalName"></param>
        /// <param name="releaseDate"></param>
        /// <param name="posterImageName"></param>
        public Movie(string name, string originalName, DateTime releaseDate, string posterImageName)
        {
            Name = name;
            OriginalName = originalName;
            ReleaseDate = releaseDate;
            PosterImageName = posterImageName;
        }
    }
}
