using GameClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGUI
{
    public partial class GameForm : Form
    {
        private int boardSize;
        private string playerName;
        private Board board;
        private Button[,] btnGrid;
        private Stopwatch watch = new Stopwatch();

        string BOMB_IMG = Path.Combine(Environment.CurrentDirectory, @"..\..\..\images\bomb.png");
        string FLAG_IMG = Path.Combine(Environment.CurrentDirectory, @"..\..\..\images\flag.png");

        public GameForm(int boardSize, int difficulty, string playerName)
        {
            this.boardSize = boardSize;
            this.playerName = playerName;
            board = new Board(boardSize);
            btnGrid = new Button[boardSize, boardSize];
            InitializeComponent();
            board.setupLiveNeighbors(difficulty);
            board.calculateLiveNeighbors();
            populateBoard();
            watch.Start();
            timer1.Enabled = true;
        }

        private void populateBoard()
        {
            panel1.Width = boardSize * 25;
            panel1.Height = boardSize * 25;
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    Button newBtn = new Button
                    {
                        Size = new Size(25, 25),
                        Location = new Point(25 * i, 25 * j),
                        BackColor = Color.DarkGray,
                        ForeColor = Color.DarkGray,

                        Tag = new ButtonData(i, j)
                    };

                    btnGrid[i, j] = newBtn;
                    panel1.Controls.Add(newBtn);

                    // Show all bombs on grid for testing purposes
                    //if (board.grid[i, j].live)
                    //{
                    //    newBtn.Image = Image.FromFile(BOMB_IMG);
                    //}

                    newBtn.Click += buttonClickEvent;
                    newBtn.MouseUp += buttonRightClickEvent;
                }
            }
            // Set the size of the GameForm
            this.Size = new Size(panel1.Size.Width + 45, panel1.Size.Height + 85);
        }

        private void printBoardDuringGame(Board board, int row, int column)
        {
            for (int i = 0; i < board.size; i++)
            {
                for (int j = 0; j < board.size; j++)
                {
                    Cell cell = board.grid[i, j];
                    updateButton(cell, i, j);
                }
            }
        }

        private void updateButton(Cell cell, int row, int column)
        {
            if (cell.visited)
            {
                if (cell.liveNeighbors > 0)
                {
                    btnGrid[row, column].Text = cell.liveNeighbors.ToString();
                    btnGrid[row, column].BackColor = Color.LightGray;
                    btnGrid[row, column].ForeColor = Color.Black;
                }
                else
                {
                    btnGrid[row, column].BackColor = Color.LightGray;
                }
            }
        }

        // Calculates player score based on time taken to complete game
        public int calculateScore(int time, int difficulty)
        {
            int pointBase = 1000;
            if (difficulty == 9)
            {
                if (time <= 30)
                {
                    return (int)Math.Round((pointBase - time) * .65);
                }
                else if (time > 30)
                {
                    return (int)Math.Round((pointBase - (time * 2)) * .65);
                }
                else if (time >= 90)
                {
                    return (int)Math.Round((pointBase - (time * 3)) * .65);
                }
                else if (time >= 240)
                {
                    return (int)Math.Round((pointBase - (time * 4)) * .65);
                }
                else
                {
                    return (int)Math.Round((pointBase - (time * 5)) * .65);
                }
            }
            else if (difficulty == 12)
            {
                if (time <= 30)
                {
                    return (int)Math.Round((pointBase - time) * .7);
                }
                else if (time > 30)
                {
                    return (int)Math.Round((pointBase - (time * 2)) * .7);
                }
                else if (time >= 90)
                {
                    return (int)Math.Round((pointBase - (time * 3)) * .7);
                }
                else if (time >= 240)
                {
                    return (int)Math.Round((pointBase - (time * 4)) * .7);
                }
                else
                {
                    return (int)Math.Round((pointBase - (time * 5)) * .7);
                }
            }
            else if (difficulty == 15)
            {
                if (time <= 30)
                {
                    return (int)Math.Round((pointBase - time) * .75);
                }
                else if (time > 30)
                {
                    return (int)Math.Round((pointBase - (time * 2)) * .75);
                }
                else if (time >= 90)
                {
                    return (int)Math.Round((pointBase - (time * 3)) * .75);
                }
                else if (time >= 240)
                {
                    return (int)Math.Round((pointBase - (time * 4)) * .75);
                }
                else
                {
                    return (int)Math.Round((pointBase - (time * 5)) * .75);
                }
            }
            else
            {
                return 0;
            }
        }

        private void checkForWin()
        {
            int numOfCells = boardSize * boardSize;
            int numVisited = 0;
            int gameTime = int.Parse(watch.Elapsed.TotalSeconds.ToString("F0"));

            for (int i = 0; i < board.size; i++)
            {
                for (int j = 0; j < board.size; j++)
                {
                    // If a cell is live, subract from numOfCells
                    if (board.grid[i, j].live)
                    {
                        numOfCells--;
                    }
                    if (board.grid[i, j].visited)
                    {
                        numVisited++;
                    }
                }
            }
            if (numVisited == numOfCells)
            {
                watch.Stop();
                timer1.Enabled = false;
                for (int i = 0; i < boardSize; i++)
                {
                    for (int j = 0; j < boardSize; j++)
                    {
                        btnGrid[i, j].Image = Image.FromFile(FLAG_IMG);
                        btnGrid[i, j].Text = "";
                    }
                }

                // Set difficulty as a string for high score form
                string difficulty = "";

                if (boardSize == 9)
                {
                    difficulty = "Easy";
                }
                else if (boardSize == 12)
                {
                    difficulty = "Moderate";
                }
                else if (boardSize == 15)
                {
                    difficulty = "Hard";
                }

                PlayerStats player = new PlayerStats(playerName, difficulty, gameTime, calculateScore(gameTime, boardSize));

                HighScoresForm highScoresForm = new HighScoresForm(player, difficulty);

                DialogResult result = MessageBox.Show("You Win! " + label1.Text + "\n\nShow high scores?", "Confirmation", MessageBoxButtons.YesNo);
                
                if (result == DialogResult.Yes)
                {
                    this.Hide();
                    highScoresForm.Show();
                }
                else if (result == DialogResult.No)
                {
                    Application.Exit();
                }
            }
        }

        public void buttonRightClickEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var btnData = (sender as Button).Tag as ButtonData;

                Cell currentCell = board.grid[btnData.row, btnData.column];
                currentCell.row = btnData.row;
                currentCell.column = btnData.column;

                btnGrid[currentCell.row, currentCell.column].Image = Image.FromFile(FLAG_IMG);
            }
        }

        private void buttonClickEvent(object? sender, EventArgs e)
        {
            var btnData = (sender as Button).Tag as ButtonData;

            Cell currentCell = board.grid[btnData.row, btnData.column];
            currentCell.row = btnData.row;
            currentCell.column = btnData.column;

            if (!currentCell.live)
            {
                board.floodFill(currentCell.row, currentCell.column);
                currentCell.visited = true;
                printBoardDuringGame(board, currentCell.row, currentCell.column);
                checkForWin();
            }
            else
            {
                for (int i = 0; i < board.size; i++)
                {
                    for (int j = 0; j < board.size; j++)
                    {
                        btnGrid[i, j].Image = Image.FromFile(BOMB_IMG);
                        btnGrid[i, j].Text = "";
                    }
                }
                watch.Stop();
                timer1.Enabled = false;

                // Display game over, exit application
                DialogResult result = MessageBox.Show("Game Over");
                if (result == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "Time elapsed: " + watch.Elapsed.TotalSeconds.ToString("F0");
        }
    }
}
