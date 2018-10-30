using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
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

        public string ReleaseDate { get; private set; }

        [EnumDataType(typeof(AgeRestriction))]
        public AgeRestriction AgeRestriction { get; private set; }

        //public int Rating { get; set; }

        public Movie()
        {

        }
        public Movie(int id, string name, Genre genre, DateTime releaseDate, AgeRestriction ageRestriction, int duration)
        {
            Id = id;
            Name = name;
            Genre = genre;
            ReleaseDate = SetDate(releaseDate);
            AgeRestriction = ageRestriction;
            Duration = duration;
        }
        public Movie(string name, Genre genre, DateTime releaseDate, AgeRestriction ageRestriction, int duration)
        {
            Name = name;
            Genre = genre;
            ReleaseDate = SetDate(releaseDate);
            AgeRestriction = ageRestriction;
            Duration = duration;
        }

        private string SetDate(DateTime dateTime)
        {
            string date = dateTime.ToString("dddd, dd MMMM yyyy");
            return date;
        }

    }
}
