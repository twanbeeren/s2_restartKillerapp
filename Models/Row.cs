using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Row
    {
        public List<Chair> Chairs { get; private set; }
        public int MaxChairs { get; private set; }

        public Row(List<Chair> chairs)
        {
            Chairs = chairs;
            MaxChairs = 6;
        }
    }
}
