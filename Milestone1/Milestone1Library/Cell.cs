using System;

namespace Milestone1Library
{
    public class Cell
    {
        public int RowNumber { get; set; } = -1;
        public int ColumnNumber { get; set; } = -1;
        public int LiveNeighbors { get; set; }
        public bool Visited { get; set; }
        public bool Live { get; set; }

        public Cell(int x, int y)
        {
            RowNumber = x;
            ColumnNumber = y;
        }
    }
}
