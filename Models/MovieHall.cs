using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class MovieHall
    {
        private Cinema cinema;

        public int Id { get; private set; }
        public int HallNumber { get; private set; }
        public List<Row> Rows { get; private set; }

        public Cinema Cinema { get; private set; }
        public int Capacity { get; private set; }

        public MovieHall()
        {

        }
        public MovieHall(int id, Cinema cinema, int hallNumber, List<Row> rows, int capacity)
        {
            Id = id;
            Cinema = cinema;
            HallNumber = hallNumber;
            Capacity = capacity;
            Rows = rows;
        }
        public MovieHall(Cinema cinema, int hallNumber, List<Row> rows, int capacity)
        {
            Cinema = cinema;
            HallNumber = hallNumber;
            Capacity = capacity;
            Rows = rows;
        }

        public MovieHall(int id, Cinema cinema, int hallNumber, int capacity)
        {
            Id = id;
            Cinema = cinema;
            HallNumber = hallNumber;
            Capacity = capacity;
        }
    }
}
