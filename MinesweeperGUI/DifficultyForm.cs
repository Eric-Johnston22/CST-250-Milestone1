namespace MinesweeperGUI
{
    public partial class DifficultyForm : Form
    {
        private int difficulty;
        private int boardSize;
        private string playerName;
        public DifficultyForm()
        {
            InitializeComponent();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (radioEasy.Checked)
            {
                boardSize = 9;
                difficulty = 12;
            }
            if (radioModerate.Checked)
            {
                boardSize = 12;
                difficulty = 9;
            }
            if (radioHard.Checked)
            {
                boardSize = 15;
                difficulty = 7;
            }
            else if (!radioEasy.Checked && !radioModerate.Checked && !radioHard.Checked)
            {
                MessageBox.Show("You must make a selection");
            }

            if (textBox1.Text == null || textBox1.Text == "")
            {
                MessageBox.Show("You must enter your name");
            }
            else
            {
                playerName = textBox1.Text;
                GameForm gameForm = new GameForm(boardSize, difficulty, playerName);
                this.Hide();
                gameForm.Show();
            }

        }

        private void DifficultyForm_Load(object sender, EventArgs e)
        {

        }
    }
}