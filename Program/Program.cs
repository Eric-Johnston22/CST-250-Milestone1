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
            Board board = new Board(12);

            // Setup grid, placeholder difficulty of 6
            board.setupLiveNeighbors(6);
            board.calculateLiveNeighbors();
            printBoard(board);
            gameLoop(board);
        }

        // Display game board to console. Pass board object as argument
        static public void printBoard(Board board)
        {
            for (int i = 0; i < board.grid.GetLength(0); i++)
            {
                for (int k = 0; k < board.size; k++)
                {
                    Console.Write("+---");
                }
                Console.Write("+");
                Console.WriteLine();
                for (int j = 0; j < board.grid.GetLength(1); j++)
                {
                    Console.Write("| ");
                    Console.Write("? ");
                    if (board.grid[i, j].visited == true)
                    {
                        Console.Write(board.grid[i, j].liveNeighbors + " ");
                    }
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("=================================================");
        }

        static public void printBoardDuringGame(Board board)
        {
            for (int i = 0; i < board.grid.GetLength(0); i++)
            {
                for (int k = 0; k < board.size; k++)
                {
                    Console.Write("+---");
                }
                Console.Write("+");
                Console.WriteLine();
                for (int j = 0; j < board.grid.GetLength(1); j++)
                {
                    if (board.grid[i, j].visited == true)
                    {
                        Console.Write("| ");
                        if (board.grid[i, j].liveNeighbors == 0)
                        {
                            Console.Write("  ");
                        }
                        else
                        {
                            Console.Write(board.grid[i, j].liveNeighbors + " ");

                        }
                    }
                    else
                    {
                        Console.Write("| ");
                        Console.Write("? ");
                    }

                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("=================================================");
        }

        static public void gameLoop(Board board)
        {
            bool gameOver = false;

            while(!gameOver)
            {
                Console.WriteLine("Enter a row: ");
                int row = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter a column: ");
                int col = int.Parse(Console.ReadLine());

                if (!board.grid[row, col].live == true)
                {
                    board.grid[row, col].visited = true;
                    printBoardDuringGame(board);
                }
                else
                {

                    Console.WriteLine("You hit a mine! Game over :(");
                    gameOver = true;
                }
            }
        }
    }
}