using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class MovieHall
    {
        public int HallNumber { get; private set; }
        public List<Row> Rows { get; private set; }

        public int Capacity { get; private set; }

        public MovieHall(int hallNumber, List<Row> rows, int capacity)
        {
            HallNumber = hallNumber;
            Capacity = capacity;
            Rows = rows;

        }
    }
}
