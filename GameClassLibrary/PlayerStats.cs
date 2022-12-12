using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    public class PlayerStats : IComparable<PlayerStats>
    {
        public int highScore { get; set; }


        public int CompareTo(PlayerStats? other)
        {
            throw new NotImplementedException();
        }
    }
}
