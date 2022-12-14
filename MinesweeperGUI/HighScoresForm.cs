using GameClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGUI
{
    public partial class HighScoresForm : Form
    {
        public PlayerStatsList playerStatsList = new PlayerStatsList();
        private PlayerStats player;
        private string difficulty { get; set; }

        public HighScoresForm(PlayerStats player, string difficulty)
        {
            this.player = player;
            this.difficulty = difficulty;
            InitializeComponent();
            listView1.FullRowSelect = true;
        }

        private void HighScoresForm_Load(object sender, EventArgs e)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\highscores.txt");

            List<string> outputLines = new List<string>();
            TextWriter writer = new StreamWriter(filePath, true);
            listView1.Clear();
            
            // Save player stats to text file
            writer.WriteLine(player.name + ", " + player.difficulty + ", " + player.timeElapsed + ", " + player.score);
            writer.Close();

            // Read text file and add players to listOfPlayers
            try
            {
                List<String> lines = File.ReadLines(filePath).ToList();
                for (int i = 0; i < lines.Count; i++)
                {
                    string[] entries = lines[i].Split(',');

                    PlayerStats newPlayer = new PlayerStats();

                    if (entries.Length != 4)
                    {
                        MessageBox.Show("Line # " + (i + 1) + "is does not have 4 items.");
                        return;
                    }
                    else
                    {
                        newPlayer.name = entries[0];
                        newPlayer.difficulty = entries[1];
                        newPlayer.timeElapsed = int.Parse(entries[2]);
                        newPlayer.score = int.Parse(entries[3]);
                    }
                    playerStatsList.listOfPlayers.Add(newPlayer);
                }

                var oPlayer = from player in playerStatsList.listOfPlayers
                                   where player.difficulty == " " + difficulty
                                   orderby player.score descending
                                   select player;

                // Store top 5 players
                var topFive = oPlayer.Take(5).ToList();
                listView1.Items.Clear();

                // Create listView columns programatically
                listView1.Columns.Add("Player", 80, HorizontalAlignment.Center);
                listView1.Columns.Add("Difficulty", 80, HorizontalAlignment.Center);
                listView1.Columns.Add("Time", 80, HorizontalAlignment.Center);
                listView1.Columns.Add("Score", 80, HorizontalAlignment.Center);

                foreach (var player in topFive)
                {

                    ListViewItem eachRow = new ListViewItem(player.name);
                    ListViewItem.ListViewSubItem difficulty = new ListViewItem.ListViewSubItem(eachRow, player.difficulty);
                    ListViewItem.ListViewSubItem timeElapsed = new ListViewItem.ListViewSubItem(eachRow, player.timeElapsed.ToString());
                    ListViewItem.ListViewSubItem score = new ListViewItem.ListViewSubItem(eachRow, player.score.ToString());
                    eachRow.SubItems.Add(player.difficulty.ToString());
                    eachRow.SubItems.Add(player.timeElapsed.ToString());
                    eachRow.SubItems.Add(player.score.ToString());

                    listView1.Items.Add(eachRow);
                }
            }
            catch(FileNotFoundException)
            {
                MessageBox.Show("File not found, check path.");
            }
        }
    }
}
