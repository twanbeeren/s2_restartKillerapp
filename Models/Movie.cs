using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Models.Enumerations;

namespace Models
{
    public class Movie
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        [EnumDataType(typeof(Genre))]
        public Genre Genre { get; private set; }

        public int Duration { get; private set; }

        public DateTime ReleaseDate { get; private set; }

        [EnumDataType(typeof(AgeRestriction))]
        public AgeRestriction AgeRestriction { get; private set; }

        //public int Rating { get; set; }

        public Movie(int id, string name, Genre genre, int duration, DateTime releaseDate, AgeRestriction ageRestriction)
        {
            Id = id;
            Name = name;
            Genre = genre;
            Duration = duration;
            ReleaseDate = releaseDate;
            AgeRestriction = ageRestriction;
        }
        public Movie(string name, Genre genre, int duration, DateTime releaseDate, AgeRestriction ageRestriction)
        {
            Name = name;
            Genre = genre;
            Duration = duration;
            ReleaseDate = releaseDate;
            AgeRestriction = ageRestriction;
        }

    }
}
