using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Cinema
    {
        public List<MovieHall> MovieHalls { get; private set; }
        public string Name { get; private set; }
        public string Place { get; private set; }
        public Cinema(List<MovieHall> Halls, string name, string place)
        {
            MovieHalls = Halls;
            Name = name;
            Place = place;
        }

    }
}
