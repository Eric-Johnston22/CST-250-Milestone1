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
            this.size = size;
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

        public bool validateOutOfRange(int row, int column)
        {
            return row < size && column < size && row >= 0 && column >= 0;
        }

        // Determines how many neighboring grids have mines
        public void calculateLiveNeighbors()
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (validateOutOfRange(i - 1, j))
                    {
                        if (grid[i - 1, j].live == true)
                        {
                            grid[i, j].liveNeighbors++;
                        }
                    }
                    if (validateOutOfRange(i - 1, j - 1))
                    {
                        if (grid[i - 1, j - 1].live == true)
                        {
                            grid[i, j].liveNeighbors++;
                        }
                    }
                    if (validateOutOfRange(i - 1, j + 1))
                    {
                        if (grid[i - 1, j + 1].live == true)
                        {
                            grid[i, j].liveNeighbors++;
                        }
                    }
                    if (validateOutOfRange(i, j - 1))
                    {
                        if (grid[i, j - 1].live == true)
                        {
                            grid[i, j].liveNeighbors++;
                        }
                    }

                    if (validateOutOfRange(i, j + 1))
                    {
                        if (grid[i, j + 1].live == true)
                        {
                            grid[i, j].liveNeighbors++;
                        }

                    }
                    
                    if (validateOutOfRange(i + 1, j - 1))
                    {
                        if (grid[i + 1, j - 1].live == true)
                        {
                            grid[i, j].liveNeighbors++;
                        }
                    }

                    if (validateOutOfRange(i + 1, j + 1))
                    {
                        if (grid[i + 1, j + 1].live == true)
                        {
                            grid[i, j].liveNeighbors++;
                        }
                    }

                    if (validateOutOfRange(i + 1, j))
                    {
                        if (grid[i + 1, j].live == true)
                        {
                            grid[i, j].liveNeighbors++;
                        }
                    }
                }
            }
        }
    }
}
