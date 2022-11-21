using System;
using System.Drawing;
using GameClassLibrary;

namespace Program
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Create 12x12 game board
            Board board = new Board(12);

            // Setup grid, placeholder difficulty of 6
            board.setupLiveNeighbors(10);
            board.calculateLiveNeighbors();
            printBoard(board);
            gameLoop(board);
        }

        // Display game board to console. Pass board object as argument
        static public void printBoard(Board board)
        {
            Console.ForegroundColor = ConsoleColor.White;
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
                    //Console.Write(board.grid[i, j].liveNeighbors + " ");
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

        // Prints board again after user makes selects a cell
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
                        // If no live neighbors exist, print '~' symbol
                        if (board.grid[i, j].liveNeighbors == 0)
                        {
                            Console.Write("~ ");
                        }
                        // If live neighbors exit, display how many and color code the output
                        else
                        {
                            if (board.grid[i, j].liveNeighbors == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(board.grid[i, j].liveNeighbors + " ");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            if (board.grid[i, j].liveNeighbors == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(board.grid[i, j].liveNeighbors + " ");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            if (board.grid[i, j].liveNeighbors == 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(board.grid[i, j].liveNeighbors + " ");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            if (board.grid[i, j].liveNeighbors == 4)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write(board.grid[i, j].liveNeighbors + " ");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            if (board.grid[i, j].liveNeighbors == 5)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(board.grid[i, j].liveNeighbors + " ");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            if (board.grid[i, j].liveNeighbors == 6)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write(board.grid[i, j].liveNeighbors + " ");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            if (board.grid[i, j].liveNeighbors > 6)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(board.grid[i, j].liveNeighbors + " ");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
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

        // Game loop, ends when user selects a cell with a mine
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
                    board.floodFill(row, col);
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