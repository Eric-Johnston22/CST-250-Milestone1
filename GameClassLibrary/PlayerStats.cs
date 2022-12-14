using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    public class PlayerStats : IComparable<PlayerStats>
    {
        public string name { get; set; }
        public string difficulty { get; set; }
        public int timeElapsed { get; set; }
        public int score { get; set; }

        public PlayerStats()
        {

        }

        public PlayerStats(string? name, string? difficulty, int timeElapsed, int score)
        {
            this.name = name;
            this.difficulty = difficulty;
            this.timeElapsed = timeElapsed;
            this.score = score;
        }

        public string Display
        {
            get
            {
                return string.Format("Name: {0} Difficulty: {1} Time: {2} Score: {3}", name, difficulty, timeElapsed, score);
            }
        }

        public int CompareTo(PlayerStats? other)
        {
            return other.score.CompareTo(this.score);
        }
    }
}
