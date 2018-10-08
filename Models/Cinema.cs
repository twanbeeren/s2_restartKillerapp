using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Cinema
    {
        public string Name { get; set; }
        public List<MovieHall> MovieHalls { get; private set; }
        public string Company { get; private set; }
        public string Place { get; private set; }

        public Cinema(string company, string place)
        {
            Company = company;
            Place = place;
            MakeName(company, place);
        }
        public Cinema(List<MovieHall> Halls, string company, string place)
        {
            MovieHalls = Halls;
            Company = company;
            Place = place;
            MakeName(company, place);
        }

        private void MakeName(string company, string place)
        {
            Name = company + " " + place;
        }
    }
}
