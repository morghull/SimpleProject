using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProject.DataObjects
{
    public class Movie
    {
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public DateTime ReleaseDate { get; set; }
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
