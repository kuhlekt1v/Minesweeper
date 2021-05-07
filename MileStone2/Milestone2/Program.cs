using System;
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
                        field.Difficulty = 25;
                        break;
                    case "m":
                        field.Difficulty = 50;
                        break;
                    case "h":
                        field.Difficulty = 75;
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
                Console.Write(border);
                Console.WriteLine("+");
                for (int j = 0; j < field.Size; j++)
                {
                    Cell c = field.Grid [i, j];

                    if(c.Live == true)
                        Console.Write($"| * ");
                    else
                        Console.Write($"| {c.LiveNeighbors} ");
                }

                // Row number labels at right of board.
                Console.WriteLine($"| {i}");

            }
            Console.Write(border + "+");
            Console.WriteLine();
        }
    }
}
