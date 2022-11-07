using System;
using System.Drawing;
using GameClassLibrary;

namespace Program
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Create 9x9 game board
            Board board = new Board(9);

            // Setup grid, placeholder difficulty of 6
            board.setupLiveNeighbors(6);
            board.calculateLiveNeighbors();
            printBoard(board);
        }

        // Display game board to console. Pass board object as argument
        static public void printBoard(Board board)
        {
            for (int i = 0; i < board.grid.GetLength(0); i++)
            {
                for (int j = 0; j < board.grid.GetLength(1); j++)
                {
                    // Print live neighbors from each grid
                    Console.Write(board.grid[i, j].liveNeighbors + " ");
                }
                Console.WriteLine();
            }
        }
    }
}