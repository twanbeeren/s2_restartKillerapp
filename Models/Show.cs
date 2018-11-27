﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Show
    {
        //Hoe weet mijn ticket klasse in welke zaal van de bioscoop de film word gedraaid? Apart een MovieHall meegeven?
        //Weet mijn Show in welke "Cinema" die draait of in welke "MovieHall"
        public int Id { get; private set; }
        public MovieHall MovieHall { get; private set; }
        public Movie Movie { get; private set; }
        public DateTime Date { get; private set; }
        public string Time { get; private set; }
        public int ShowDuration { get; private set; }
        public double Price { get; private set; }

        public Show(int id, MovieHall movieHall, Movie movie, DateTime date, double price)
        {
            Id = id;
            MovieHall = movieHall;
            Movie = movie;
            Date = date;
            Time = SetTime(date);
            ShowDuration = SetShowDuration(movie);
            Price = price;
        }
        public Show(MovieHall movieHall, Movie movie, DateTime date, double price)
        {
            MovieHall = movieHall;
            Movie = movie;
            Date = date;
            Time = SetTime(date);
            ShowDuration = SetShowDuration(movie);
            Price = price;
        }

        private string SetTime(DateTime date)
        {
            return Time = date.ToString("HH:mm");
        }
        private int SetShowDuration(Movie movie)
        {
            int breaktime = 15;
            ShowDuration = movie.Duration + breaktime;
            return ShowDuration;
        }
    }
}
