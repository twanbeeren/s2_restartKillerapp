using Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Chair
    {
        public int ChairId { get; private set; }
        public ChairType ChairType { get; private set; }
        public int Number { get; private set; }
        public int Row { get; private set; }
        public bool Taken { get; set; }
        

        public Chair(ChairType type, int chairId, int number, int row)
        {
            ChairType = type;
            ChairId = chairId;
            Number = number;
            Row = row;
        }
    }
}
