using SimpleProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProject.DataObjects
{
    public class Movie
    {
        [Title("Назва")]
        public string Name { get; set; }
        [Title("Назва мовою оригіналу")]
        public string OriginalName { get; set; }
        [Title("Дата релізу")]
        public DateTime ReleaseDate { get; set; }
        [Title("Ім'я файлу постеру")]
        public string PosterImageName { get; set; }
        public Movie() { }
        public Movie(string name, string originalName, DateTime releaseDate, string posterImageName)
        {
            Name = name;
            OriginalName = originalName;
            ReleaseDate = releaseDate;
            PosterImageName = posterImageName;
        }
    }
}
