namespace MinesweeperGUI
{
    partial class DifficultyForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioHard = new System.Windows.Forms.RadioButton();
            this.radioModerate = new System.Windows.Forms.RadioButton();
            this.radioEasy = new System.Windows.Forms.RadioButton();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioHard);
            this.groupBox1.Controls.Add(this.radioModerate);
            this.groupBox1.Controls.Add(this.radioEasy);
            this.groupBox1.Location = new System.Drawing.Point(82, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 156);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Difficulty";
            // 
            // radioHard
            // 
            this.radioHard.AutoSize = true;
            this.radioHard.Location = new System.Drawing.Point(58, 119);
            this.radioHard.Name = "radioHard";
            this.radioHard.Size = new System.Drawing.Size(51, 19);
            this.radioHard.TabIndex = 2;
            this.radioHard.TabStop = true;
            this.radioHard.Text = "Hard";
            this.radioHard.UseVisualStyleBackColor = true;
            // 
            // radioModerate
            // 
            this.radioModerate.AutoSize = true;
            this.radioModerate.Location = new System.Drawing.Point(58, 78);
            this.radioModerate.Name = "radioModerate";
            this.radioModerate.Size = new System.Drawing.Size(76, 19);
            this.radioModerate.TabIndex = 1;
            this.radioModerate.TabStop = true;
            this.radioModerate.Text = "Moderate";
            this.radioModerate.UseVisualStyleBackColor = true;
            // 
            // radioEasy
            // 
            this.radioEasy.AutoSize = true;
            this.radioEasy.Location = new System.Drawing.Point(58, 36);
            this.radioEasy.Name = "radioEasy";
            this.radioEasy.Size = new System.Drawing.Size(48, 19);
            this.radioEasy.TabIndex = 0;
            this.radioEasy.TabStop = true;
            this.radioEasy.Text = "Easy";
            this.radioEasy.UseVisualStyleBackColor = true;
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(140, 242);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(107, 34);
            this.buttonPlay.TabIndex = 1;
            this.buttonPlay.Text = "Play Game";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(176, 201);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 3;
            // 
            // DifficultyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 308);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.groupBox1);
            this.Name = "DifficultyForm";
            this.Text = "Select Level";
            this.Load += new System.EventHandler(this.DifficultyForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton radioHard;
        private RadioButton radioModerate;
        private RadioButton radioEasy;
        private Button buttonPlay;
        private Label label1;
        private TextBox textBox1;
    }
}