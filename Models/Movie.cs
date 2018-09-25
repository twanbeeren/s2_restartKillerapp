using System;
using System.Collections.Generic;
using System.Text;
using Models.Enumerations;

namespace Models
{
    public class Movie
    {
        public string Name { get; private set; }
        public Genre Genre { get; private set; }
        public int Duration { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public AgeRestriction AgeRestriction { get; private set; }
        public int Rating { get; set; }

        public Movie(string name, Genre genre, int duration, DateTime releaseDate, AgeRestriction ageRestriction, int rating)
        {
            Name = name;
            Genre = genre;
            Duration = duration;
            ReleaseDate = releaseDate;
            AgeRestriction = ageRestriction;
            Rating = rating;
        }

    }
}
