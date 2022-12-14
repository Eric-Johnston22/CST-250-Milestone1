using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    public class PlayerStatsList
    {
        public List<PlayerStats> listOfPlayers { get; set; }

        public PlayerStatsList()
        {
            listOfPlayers = new List<PlayerStats>();
        }
    }
}
