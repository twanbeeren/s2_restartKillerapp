using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Show
    {
        //Hoe weet mijn ticket klasse in welke zaal de film word gedraaid?
        public Cinema Cinema { get; private set; }
        public Movie Movie { get; private set; }
        public DateTime Date { get; private set; }
        public int Showtime { get; private set; }

        public Show(Cinema cinema, Movie movie, DateTime date)
        {
            Cinema = cinema;
            Movie = movie;
            Date = date;
            Showtime = SetShowtime(movie);
        }

        private int SetShowtime(Movie movie)
        {
            int breaktime = 15;
            Showtime = movie.Duration + breaktime;
            return Showtime;
        }
    }
}
