using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    public class Cell
    {
        public int row { get; set; }
        public int column { get; set; }
        public bool visited { get; set; }
        public bool live { get; set; }
        public int liveNeighbors { get; set; }

        public Cell()
        {
            row = -1;
            column = -1;
            visited = false;
            live = false;
            liveNeighbors = 0;
        }
    }
}
