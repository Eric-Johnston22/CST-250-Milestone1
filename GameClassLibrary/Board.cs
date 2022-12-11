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

        // Determines which locations in the grid is a mine based on difficulty
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
                    // North
                    if (validateOutOfRange(i - 1, j))
                    {
                        if (grid[i - 1, j].live == true)
                        {
                            grid[i, j].liveNeighbors++;
                        }
                    }
                    // North West
                    if (validateOutOfRange(i - 1, j - 1))
                    {
                        if (grid[i - 1, j - 1].live == true)
                        {
                            grid[i, j].liveNeighbors++;
                        }
                    }
                    // North East
                    if (validateOutOfRange(i - 1, j + 1))
                    {
                        if (grid[i - 1, j + 1].live == true)
                        {
                            grid[i, j].liveNeighbors++;
                        }
                    }
                    // West
                    if (validateOutOfRange(i, j - 1))
                    {
                        if (grid[i, j - 1].live == true)
                        {
                            grid[i, j].liveNeighbors++;
                        }
                    }
                    // East
                    if (validateOutOfRange(i, j + 1))
                    {
                        if (grid[i, j + 1].live == true)
                        {
                            grid[i, j].liveNeighbors++;
                        }

                    }
                    // South West
                    if (validateOutOfRange(i + 1, j - 1))
                    {
                        if (grid[i + 1, j - 1].live == true)
                        {
                            grid[i, j].liveNeighbors++;
                        }
                    }
                    // South East
                    if (validateOutOfRange(i + 1, j + 1))
                    {
                        if (grid[i + 1, j + 1].live == true)
                        {
                            grid[i, j].liveNeighbors++;
                        }
                    }
                    // South
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

        /* Reveals all adjacent cells with no live neighbors
         * Only reveals cells North, South, East, and West
         */
        public void floodFill(int row, int column)
        {      
            if (grid[row, column].visited)
            {
                return;
            }

            if (grid[row, column].liveNeighbors > 0)
            {
                return;
            }

            grid[row, column].visited = true;

            // North
            if (validateOutOfRange(row - 1, column))
            {
                if (grid[row - 1, column].liveNeighbors == 0)
                {
                    floodFill(row - 1, column);
                }
                else if (!grid[row - 1, column].live)
                {
                    grid[row - 1, column].visited = true;
                }
            }
            // South
            if (validateOutOfRange(row + 1, column))
            {
                if (grid[row + 1, column].liveNeighbors == 0)
                {
                    floodFill(row + 1, column);
                }
                else if (!grid[row + 1, column].live)
                {
                    grid[row + 1, column].visited = true;
                }
            }
            // East
            if (validateOutOfRange(row, column + 1))
            {
                if (grid[row, column + 1].liveNeighbors == 0)
                {
                    floodFill(row, column + 1);
                }
                else if (!grid[row, column + 1].live)
                {
                    grid[row, column + 1].visited = true;
                }
            }
            // West
            if (validateOutOfRange(row, column - 1))
            {
                if (grid[row, column - 1].liveNeighbors == 0)
                {
                    floodFill(row, column - 1);
                }
                else if (!grid[row, column - 1].live)
                {
                    grid[row, column - 1].visited = true;
                }
            }
        }
    }
}
