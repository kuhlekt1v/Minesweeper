using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone1Library
{
    public class Board
    {
        public int Size { get; set; } = 11;
        public Cell[,] Grid { get; set; }

        public int Difficulty { get; set; }

        public Board(int size = 11, int difficulty = 25)
        {
            // Initialize board size.
            Size = size;

            // Initialize difficulty.
            Difficulty = difficulty;

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

        public void SetUpLiveNeighbors()
        {
            // Initialize variable for # of bombs placed.
            int occupiedSpots = 0;
            double percent = Difficulty * .01;

            // Calculate bombs to place base on percentage of board size.
            int liveSpots = Convert.ToInt32(Size * Size * percent);
            Random random = new Random();

            /* Place bombs until all # of spots available is filled.
               Works well up to 80% filled, and then extremely slow 
               because of the need to calculate random spaces.
            */

            while (occupiedSpots < liveSpots)
            {
                int randRow = random.Next(Size - 1);
                int randCol = random.Next(Size - 1);

                if (Grid [randRow, randCol].Live == false)
                {
                    // Mark current cell as live.
                    Grid [randRow, randCol].Live = true;
                    occupiedSpots++;
                }
            }    
        }

    }
}
