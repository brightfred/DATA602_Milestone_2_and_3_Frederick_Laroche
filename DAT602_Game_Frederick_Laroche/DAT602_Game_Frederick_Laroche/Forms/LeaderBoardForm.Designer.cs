namespace DAT602_Game_Frederick_Laroche.Forms
{
    partial class LeaderBoardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RefreshBtn = new System.Windows.Forms.Button();
            this.LeaderBoard = new System.Windows.Forms.ListBox();
            this.BackBtn = new System.Windows.Forms.Button();
            this.LeaderBoardLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.BackColor = System.Drawing.Color.White;
            this.RefreshBtn.Location = new System.Drawing.Point(688, 655);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(180, 89);
            this.RefreshBtn.TabIndex = 0;
            this.RefreshBtn.Text = "Refresh";
            this.RefreshBtn.UseVisualStyleBackColor = false;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // LeaderBoard
            // 
            this.LeaderBoard.FormattingEnabled = true;
            this.LeaderBoard.ItemHeight = 31;
            this.LeaderBoard.Location = new System.Drawing.Point(232, 87);
            this.LeaderBoard.Name = "LeaderBoard";
            this.LeaderBoard.Size = new System.Drawing.Size(1122, 562);
            this.LeaderBoard.TabIndex = 1;
            this.LeaderBoard.SelectedIndexChanged += new System.EventHandler(this.LeaderBoard_SelectedIndexChanged);
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.White;
            this.BackBtn.Location = new System.Drawing.Point(71, 759);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(181, 87);
            this.BackBtn.TabIndex = 2;
            this.BackBtn.Text = "Back";
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // LeaderBoardLabel
            // 
            this.LeaderBoardLabel.AutoSize = true;
            this.LeaderBoardLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeaderBoardLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LeaderBoardLabel.Location = new System.Drawing.Point(626, 21);
            this.LeaderBoardLabel.Name = "LeaderBoardLabel";
            this.LeaderBoardLabel.Size = new System.Drawing.Size(339, 63);
            this.LeaderBoardLabel.TabIndex = 3;
            this.LeaderBoardLabel.Text = "LeaderBoard";
            
            // 
            // LeaderBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(1765, 877);
            this.Controls.Add(this.LeaderBoardLabel);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.LeaderBoard);
            this.Controls.Add(this.RefreshBtn);
            this.Name = "LeaderBoardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LeaderBoardForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RefreshBtn;
        private System.Windows.Forms.ListBox LeaderBoard;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.Label LeaderBoardLabel;
    }
}