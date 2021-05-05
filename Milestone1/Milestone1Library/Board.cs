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
        public Cell [,] Grid { get; set; }

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

        // Mark cells containing live bombs.
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




        // Display number of bombs adjacent to each cell.
        public void CalculateLiveNumbers()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Cell currentCell = Grid [i, j];
                    // Check all adjacent cells for bombs if cell is not live.
                    if (!currentCell.Live)
                    {
                     
                        // Top row edge case.
                        if(currentCell.RowNumber == 0 && currentCell.ColumnNumber < Size - 1)
                        {
                            if (Grid [i + 1, j].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid [i + 1, j + 1].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid [i, j + 1].Live)
                                Grid [i, j].LiveNeighbors++;
                        }

                        if (currentCell.RowNumber == 0 && currentCell.ColumnNumber > 0)
                        {
                            if (Grid [i + 1, j].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid [i + 1, j + 1].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid [i, j + 1].Live)
                                Grid [i, j].LiveNeighbors++;
                        }

                        // Bottom row edge case.
                        if (currentCell.RowNumber == Size - 1)
                        {
                            if (Grid [i - 1, j].Live)
                                Grid [i, j].LiveNeighbors++;
                        }

                        // First column edge case.
                        if(currentCell.ColumnNumber == 0)
                        {
                            if (Grid [i, j + 1].Live)
                                Grid [i, j].LiveNeighbors++;
                        }

                        // Last column edge case.
                        if (currentCell.ColumnNumber == Size - 1)
                        {
                            if (Grid [i, j - 1].Live)
                                Grid [i, j].LiveNeighbors++;
                        }

                        // All cells not on perimeter of board.    
                        if (currentCell.RowNumber > 0 && currentCell.RowNumber < Size - 1 
                            && currentCell.ColumnNumber > 0 && currentCell.ColumnNumber < Size - 1)
                        {
                            // Row above.
                            if (Grid [i + 1, j - 1].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid [i + 1, j].Live)
                                Grid [i, j].LiveNeighbors++;

                            // Current row.
                            if (Grid [i, j + 1].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid [i, j - 1].Live)
                                Grid [i, j].LiveNeighbors++;

                            // Row below.
                            if (Grid [i - 1, j + 1].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid [i - 1, j - 1].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid [i - 1, j].Live)
                                Grid [i, j].LiveNeighbors++;
                        }

                    }

                }
            }

        }
    }
}
