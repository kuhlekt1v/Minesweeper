using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone1Library
{
    public class Board
    {
        public int Size { get; set; }
        public Cell[,] Grid { get; set; }

        public decimal Difficulty { get; set; }

        public Board(int size)
        {
            // Initialize board size.
            Size = size;

            // Create new 2D array of type Cell.
            Grid = new Cell [Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Grid [i, j] = new Cell(i, j);
                }
            }
        }
    }
}
