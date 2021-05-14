using System;
using System.Collections.Generic;
using System.Linq;
using Milestone2Library;

namespace Milestone2
{
    class Program
    {
        static Board field = new Board();

        static void Main()
        {
            intializeGame();

            while (!field.GameOver)
            {
                Console.WriteLine("Enter a Row Number");
                int row = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter a Column Number");
                int col = int.Parse(Console.ReadLine());

                // Mark cell as visited.
                field.FloodFill(row, col);

                // Total number of bomb-free cells.
                int openCells = field.CountOpenCells();

                // Total number of visited cells.
                int visitedCells = field.CountVisited();

                // Check bomb status of selected cell.
                if (field.Grid [row, col].Live)
                {
                    Console.Clear();
                    Console.WriteLine("\nBOOM! Game over.\n");
                    field.GameOver = true;
                }
                else if (visitedCells == openCells)
                {
                    printBoard(field);
                    Console.WriteLine("\nCONGRATS YOU WIN!\n");
                    field.GameOver = true;
                }
                else
                {
                    printBoard(field);
                }

            }
        }

        private static void intializeGame()
        {
            // Display title block.
            Console.WriteLine("---------------");
            Console.WriteLine("| MINESWEEPER |");
            Console.WriteLine("---------------\n");

            // Difficulty selection prompt
            Console.WriteLine("Choose your difficulty level:");
            Console.WriteLine("\n(e) Easy");
            Console.WriteLine("(m) Medium");
            Console.WriteLine("(h) Hard");

            string [] validResponse = { "e", "m", "h", "E", "M", "H" };
            string userInput = Console.ReadLine();

            // Validate user response and handle appropriately.
            if(!validResponse.Contains(userInput))
            {
                Console.WriteLine("\nInvalid selection made. Try again in 2 seconds.");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                Main(); 
            }
            else
            {
                // Assign appropriate difficulty level
                switch (userInput.ToLower())
                {
                    case "e":
                        field.Difficulty = 10;
                        break;
                    case "m":
                        field.Difficulty = 20;
                        break;
                    case "h":
                        field.Difficulty = 35;
                        break;
                    default:
                        break;
                }

                // Assign live bombs to random cells.
                field.SetUpLiveNeighbors();

                // Calculate number of live neighbors.
                field.CalculateLiveNumbers();

                // Initialize mine field.
                printBoard(field);
            }
        }

        private static void printBoard(Board field)
        {
            Console.Clear(); 

            // Column number labels at top of board.
            Console.Write("+");
            for (int i = 0; i < field.Size; i++)
            {
                if (i < field.Size - 1)
                    Console.Write($" {i} +");
                else
                    Console.Write($" {i}+");
            }

            Console.WriteLine();
            
            // Variable length horizontal cell border.
            string border = string.Concat(Enumerable.Repeat("+---", field.Size));
            for (int i = 0; i < field.Size; i++)
            {
                // Set default console color.
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(border);
                Console.WriteLine("+");
                for (int j = 0; j < field.Size; j++)
                {
                    Cell c = field.Grid [i, j];

                    if (c.Visited)
                    {
                        if (c.LiveNeighbors > 0)
                        {
                            // Display live neighbors in red.
                            Console.Write("| ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"{c.LiveNeighbors}");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" ");
                        }
                        else
                        {
                            // Display visited cells in yellow.
                            Console.Write("| ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("~");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" ");
                        }
                    }
                    else
                        Console.Write($"| ? ");
                }

                // Row number labels at right of board.
                Console.WriteLine($"| {i}");

            }
            Console.Write(border + "+");
            Console.WriteLine();
        }

    }
}
