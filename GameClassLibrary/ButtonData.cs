using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    public class ButtonData
    {
        public int row { get; set; }
        public int column { get; set; }

        public ButtonData(int row, int column)
        {
            this.row = row;
            this.column = column;
        }
    }
}
