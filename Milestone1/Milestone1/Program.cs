using System;
using System.Linq;
using Milestone1Library;

namespace Milestone1
{
    class Program
    {
        static Board field = new Board(11);
        static void Main()
        {
            // Initialize mine field.
            printBoard(field);
        }

        private static void printBoard(Board field)
        {
            // Title block.
            Console.WriteLine("---------------");
            Console.WriteLine("| MINESWEEPER |");
            Console.WriteLine("---------------\n");

            // Column number labels at top of board.
            Console.Write("+");
            for (int i = 0; i <= field.Size; i++)
            {
                if (i < 10)
                    Console.Write($" {i} +");
                else
                    Console.Write($" {i}+");
            }
            Console.WriteLine();
            
            // Variable length horizontal cell border.
            string border = string.Concat(Enumerable.Repeat("+---", field.Size + 1));
            for (int i = 0; i <= field.Size; i++)
            {
                Console.Write(border);
                Console.WriteLine("+");
                for (int j = 0; j <= field.Size; j++)
                {
                    // Placeholder for bomb.
                    Console.Write($"| * ");
                }

                // Row number labels at right of board.
                Console.WriteLine($"| {i}");

            }
            Console.Write(border + "+");
            Console.WriteLine();
        }

    }
}
