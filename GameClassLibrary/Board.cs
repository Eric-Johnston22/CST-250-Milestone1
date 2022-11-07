using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    public class Board
    {
        public int size { get; set; }
        public Cell[,] grid { get; set; }
        public int difficulty { get; set; }

        // Board constructor. Creates 2d array grid for game board
        public Board(int size)
        {
            grid = new Cell[size, size];
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = new Cell();
                }
            }
        }

        // Determines which locations in the grid is a mine
        public void setupLiveNeighbors(int difficulty)
        {
            Random rand = new Random();

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    int randNumber = rand.Next(1, difficulty);
                    if(randNumber == 1)
                    {
                        grid[i, j].live = true;
                    }
                }
            }
        }

        // Determines how many neighboring grids have mines
        public void calculateLiveNeighbors()
        {
            Random rand = new Random();

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    int randNumber = rand.Next(0, 8);
                    if (grid[i, j].live == false)
                    {
                        grid[i, j].liveNeighbors = randNumber;
                    }
                    else if (grid[i, j].live == true)
                    {
                        grid[i, j].liveNeighbors = 9;
                    }
                }
            }
        }
    }
}
