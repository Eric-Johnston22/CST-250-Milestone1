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
        private Board board;
        private Button[,] btnGrid;
        private Stopwatch watch = new Stopwatch();

        string BOMB_IMG = Path.Combine(Environment.CurrentDirectory, @"..\..\..\images\bomb.png");
        string FLAG_IMG = Path.Combine(Environment.CurrentDirectory, @"..\..\..\images\flag.png");

        public GameForm(int boardSize, int difficulty)
        {
            this.boardSize = boardSize;
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

                    if (board.grid[i, j].live)
                    {
                        string path = Path.Combine(Environment.CurrentDirectory, @"..\..\..\images\bomb.png");
                        newBtn.Image = Image.FromFile(path);
                    }
                    if (board.grid[i, j].liveNeighbors > 0)
                    {
                        //newBtn.Text = board.grid[i, j].liveNeighbors.ToString();
                    }
                    newBtn.Click += buttonClickEvent;
                }
            }

            this.Size = new Size(panel1.Size.Width + 50, panel1.Size.Height + 75);
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

        private void checkForWin()
        {
            int numOfCells = boardSize * boardSize;
            int numOfMines = 0;
            int numVisited = 0;

            for (int i = 0; i < board.size; i++)
            {
                for (int j = 0; j < board.size; j++)
                {
                    if (board.grid[i, j].live)
                    {
                        numOfMines++;
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
                for (int i = 0; i < boardSize; i ++)
                {
                    for (int j = 0; j < boardSize; j++)
                    {
                        btnGrid[i, j].Image = Image.FromFile(FLAG_IMG);
                    }
                }
                MessageBox.Show("You Win! " + label1.Text);
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
                    }
                }
            }
            
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "Time elapsed: " + watch.Elapsed.TotalSeconds.ToString("F0");
        }
    }
}
