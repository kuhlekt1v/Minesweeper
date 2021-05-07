using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone2Library
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
                        
                        // Cell [0, 0].
                        if(i == 0 && j == 0)
                        {
                            if (Grid [i, 1].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid [1, 1].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid [1, j].Live)
                                Grid [i, j].LiveNeighbors++;
                        }

                        // Cell [0, Size - 1].
                        if(i == 0 && j == Size - 1)
                        {
                            if( Grid [0, Size - 2].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid [1, Size - 2].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid [1, Size - 1].Live)
                                Grid [i, j].LiveNeighbors++;
                        }
                        
                        // Cell [Size - 1, 0].
                        if(i == Size - 1 && j == 0)
                        {
                            if (Grid [Size - 2, 0].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid [Size - 2, 1].Live)
                                Grid [i, j].LiveNeighbors++;
                            if(Grid [Size - 1, 1].Live)
                                Grid [i, j].LiveNeighbors++;
                        }   

                        // Cell [Size - 1, Size - 1].
                        if(i == Size - 1 && j == Size -1)
                        {
                            if (Grid [Size - 2, Size - 2].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid [Size - 2, Size - 1].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid [Size - 1, Size - 2].Live)
                                Grid [i, j].LiveNeighbors++;
                        }

                        // Center cells.
                        if(i > 0 && i < Size - 1 && j > 0 && j < Size - 1)
                        {
                            // Row above.
                            if (Grid [i + 1, j - 1].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid [i + 1, j].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid [i + 1, j + 1].Live)
                                Grid [i, j].LiveNeighbors++;

                            // Current row.
                            if (Grid [i, j - 1].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid [i, j + 1].Live)
                                Grid [i, j].LiveNeighbors++;

                            // Row below.
                            if (Grid[i - 1, j - 1].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid [i - 1, j].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid [i - 1, j + 1].Live)
                                Grid [i, j].LiveNeighbors++;
                        }

                        // Top row > col 0 and < col Size - 1.
                        if (i == 0 && j > 0 && j < Size - 1)
                        {
                            if(Grid[i, j - 1].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid[i, j + 1].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid[i + 1, j].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid[i + 1, j - 1].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid[i + 1, j + 1].Live)
                                Grid [i, j].LiveNeighbors++;
                        }

                        // Bottom row > col 0 and < col Size - 1.
                        if(i == Size - 1 && j > 0 && j < Size - 1)
                        {
                            if (Grid [i, j - 1].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid [i, j + 1].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid [i - 1, j].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid [i - 1, j - 1].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid [i - 1, j + 1].Live)
                                Grid [i, j].LiveNeighbors++;
                        }

                        // First column > row 0 and < row Size - 1.
                        if(j == 0 && i > 0 && i < Size - 1)
                        {
                            if(Grid[i - 1, j].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid[i + 1, j].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid[i, j + 1].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid[i - 1, j + 1].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid[i + 1, j + 1].Live)
                                Grid [i, j].LiveNeighbors++;
                        }

                        // Last column > row 0 and < row Size - 1.
                        if (j == Size - 1 && i > 0 && i < Size - 1)
                        {
                            if (Grid [i - 1, j].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid [i + 1, j].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid [i, j - 1].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid [i - 1, j - 1].Live)
                                Grid [i, j].LiveNeighbors++;
                            if (Grid [i + 1, j - 1].Live)
                                Grid [i, j].LiveNeighbors++;
                        }
                    }

                }
            }

        }
    }
}
