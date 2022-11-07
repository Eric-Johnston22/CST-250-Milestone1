using System;
using System.Drawing;
using GameClassLibrary;

namespace Program
{
    class Program
    {
        public static void Main(string[] args)
        { 
            printBoard();
        }

        static public void printBoard()
        {
            Board board = new Board(9);

            board.setupLiveNeighbors(6);
            board.calculateLiveNeighbors();
            for (int i = 0; i < board.grid.GetLength(0); i++)
            {
                for (int j = 0; j < board.grid.GetLength(1); j++)
                {
                    
                    Console.Write(board.grid[i, j].liveNeighbors + " ");
                }
                Console.WriteLine();
            }
        }
    }
}