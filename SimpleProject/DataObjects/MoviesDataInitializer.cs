using SimpleProject.DataObjects;
using SimpleProject.Interfaces;
using System;
using System.Collections.Generic;

namespace SimpleProject.Helpers
{
    /// <summary>
    /// відповідає за створення початкових значень для сутності Фільм
    /// реалізує інтерфейс IDataInitializer, щоб ми потім могли використовувати
    /// його методи не прив'язуючись до первної реалізації
    /// </summary>
    public class MoviesDataInitializer : IDataInitializer<Movie>
    {
        /// <summary>
        /// створення початкових даних 
        /// </summary>
        /// <returns>колекцію об'єктів сутності Фільм з початковими значеннями властивостей</returns>
        public List<Movie> GetInitialEntitiesList()
        {
            List<Movie> entities = new List<Movie>
            {
                new Movie("Асока", "Ahsoka", new DateTime(2023, 8, 22), "poster_ahsoka.jpg"),
                new Movie("Синій жук", "Blue Beetle", new DateTime(2023, 8, 18), "poster_blue_beetle.jpg"),
                new Movie("Пуститися берега", "Breaking Bad", new DateTime(2008, 1, 20), "poster_breaking_bad.jpg"),
                new Movie("Континенталь", "The Continental", new DateTime(2023, 9, 22), "poster_continental.jpg"),
                new Movie("Творець", "The Creator", new DateTime(2023, 9, 29), "poster_creator.jpg"),
                new Movie("Темний лицар", "The Dark Knight", new DateTime(2008, 8, 14), "poster_dark_knight.jpg"),
                new Movie("Остання подорож Деметра", "The Last Voyage of the Demeter", new DateTime(2023, 8, 11), "poster_demeter.jpg"),
                new Movie("Флеш", "The Flash", new DateTime(2023, 6, 15), "poster_flash.jpg"),
                new Movie("Покоління Б", "Generation B", new DateTime(2017, 2, 8), "poster_generation_b.jpg"),
                new Movie("Гран Турізмо", "Gran Turismo", new DateTime(2023, 8, 25), "poster_gran_turismo.jpg"),
                new Movie("Міжзоряний", "Interstellar", new DateTime(2014, 11, 6), "poster_interstellar.jpg"),
                new Movie("Мільйон миль віддалі", "A Million Miles Away", new DateTime(2023, 9, 15), "poster_million_miles_away.jpg"),
                new Movie("Ніхто не допоможе вам", "No One Will Help You", new DateTime(2023, 9, 19), "poster_no_one.jpg"),
                new Movie("Оппенгеймер", "Oppenheimer", new DateTime(2023, 7, 21), "poster_oppenheimer.jpg"),
                new Movie("Сексуальна освіта", "Sex Education", new DateTime(2019, 1, 11), "poster_sex_education.jpg")
            };

            return entities;
        }
    }
}
