namespace MinesweeperGUI
{
    public partial class DifficultyForm : Form
    {
        private int difficulty;
        public DifficultyForm()
        {
            InitializeComponent();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (radioEasy.Checked)
            {
                difficulty = 9;
            }
            if (radioModerate.Checked)
            {
                difficulty = 12;
            }
            if (radioHard.Checked)
            {
                difficulty = 15;
            }
            else if (!radioEasy.Checked && !radioModerate.Checked && !radioHard.Checked)
            {
                MessageBox.Show("You must make a selection");
            }

            GameForm gameForm = new GameForm(difficulty);
            this.Hide();
            gameForm.Show();
        }
    }
}