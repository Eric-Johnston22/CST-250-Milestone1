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
    public partial class GameForm : Form
    {
        private int difficulty;

        public GameForm(int difficulty)
        {
            this.difficulty = difficulty;
            InitializeComponent();
            populateBoard();
        }

        private void populateBoard()
        {
            for (int i = 0; i < difficulty; i++)
            {
                for (int j = 0; j < difficulty; j++)
                {
                    Button newBtn = new Button();
                    newBtn.Location = new Point(25 * i, 25 * j);
                    newBtn.Size = new Size(25, 25);
                    Controls.Add(newBtn);

                    newBtn.Click += buttonClickEvent;
                }
            }

            this.Height = 30 * difficulty;
            this.Width = 27 * difficulty;
        }

        private void buttonClickEvent(object? sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.DarkCyan;
        }
    }
}
