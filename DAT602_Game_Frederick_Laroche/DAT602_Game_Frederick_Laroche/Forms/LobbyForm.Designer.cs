namespace DAT602_Game_Frederick_Laroche.Forms
{
    partial class LobbyForm
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
            this.SendMessageBtn = new System.Windows.Forms.Button();
            this.ChatHistory = new System.Windows.Forms.ListBox();
            this.OnlinePlayer = new System.Windows.Forms.ListBox();
            this.LogOutBtn = new System.Windows.Forms.Button();
            this.AdminDashBtn = new System.Windows.Forms.Button();
            this.StartSingleGameBtn = new System.Windows.Forms.Button();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.MultiPlayerGameBtn = new System.Windows.Forms.Button();
            this.PageTitle = new System.Windows.Forms.Label();
            this.StartGameLabel = new System.Windows.Forms.Label();
            this.LeaderboardBtn = new System.Windows.Forms.Button();
            this.ProfileBtn = new System.Windows.Forms.Button();
            this.OnlinePlayerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SendMessageBtn
            // 
            this.SendMessageBtn.BackColor = System.Drawing.Color.White;
            this.SendMessageBtn.Location = new System.Drawing.Point(821, 608);
            this.SendMessageBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SendMessageBtn.Name = "SendMessageBtn";
            this.SendMessageBtn.Size = new System.Drawing.Size(291, 69);
            this.SendMessageBtn.TabIndex = 0;
            this.SendMessageBtn.Text = "Send message";
            this.SendMessageBtn.UseVisualStyleBackColor = false;
            this.SendMessageBtn.Click += new System.EventHandler(this.SendMessageBtn_Click);
            // 
            // ChatHistory
            // 
            this.ChatHistory.BackColor = System.Drawing.Color.White;
            this.ChatHistory.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ChatHistory.FormattingEnabled = true;
            this.ChatHistory.ItemHeight = 31;
            this.ChatHistory.Location = new System.Drawing.Point(339, 83);
            this.ChatHistory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChatHistory.Name = "ChatHistory";
            this.ChatHistory.ScrollAlwaysVisible = true;
            this.ChatHistory.Size = new System.Drawing.Size(825, 407);
            this.ChatHistory.TabIndex = 1;
            this.ChatHistory.SelectedIndexChanged += new System.EventHandler(this.ChatHistory_SelectedIndexChanged);
            // 
            // OnlinePlayer
            // 
            this.OnlinePlayer.FormattingEnabled = true;
            this.OnlinePlayer.ItemHeight = 31;
            this.OnlinePlayer.Location = new System.Drawing.Point(11, 83);
            this.OnlinePlayer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OnlinePlayer.Name = "OnlinePlayer";
            this.OnlinePlayer.ScrollAlwaysVisible = true;
            this.OnlinePlayer.Size = new System.Drawing.Size(297, 407);
            this.OnlinePlayer.TabIndex = 2;
            this.OnlinePlayer.SelectedIndexChanged += new System.EventHandler(this.OnlinePlayer_SelectedIndexChanged);
            // 
            // LogOutBtn
            // 
            this.LogOutBtn.BackColor = System.Drawing.Color.White;
            this.LogOutBtn.Location = new System.Drawing.Point(12, 773);
            this.LogOutBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LogOutBtn.Name = "LogOutBtn";
            this.LogOutBtn.Size = new System.Drawing.Size(187, 52);
            this.LogOutBtn.TabIndex = 3;
            this.LogOutBtn.Text = "Log out";
            this.LogOutBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.LogOutBtn.UseVisualStyleBackColor = false;
            this.LogOutBtn.Click += new System.EventHandler(this.LogOutBtn_Click);
            // 
            // AdminDashBtn
            // 
            this.AdminDashBtn.BackColor = System.Drawing.Color.Red;
            this.AdminDashBtn.Location = new System.Drawing.Point(881, 11);
            this.AdminDashBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AdminDashBtn.Name = "AdminDashBtn";
            this.AdminDashBtn.Size = new System.Drawing.Size(283, 67);
            this.AdminDashBtn.TabIndex = 4;
            this.AdminDashBtn.Text = "Admin DashBoard";
            this.AdminDashBtn.UseVisualStyleBackColor = false;
            this.AdminDashBtn.Click += new System.EventHandler(this.AdminDashBtn_Click);
            // 
            // StartSingleGameBtn
            // 
            this.StartSingleGameBtn.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.StartSingleGameBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartSingleGameBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.StartSingleGameBtn.Location = new System.Drawing.Point(405, 632);
            this.StartSingleGameBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StartSingleGameBtn.Name = "StartSingleGameBtn";
            this.StartSingleGameBtn.Size = new System.Drawing.Size(283, 81);
            this.StartSingleGameBtn.TabIndex = 6;
            this.StartSingleGameBtn.Text = "Single Player Game";
            this.StartSingleGameBtn.UseVisualStyleBackColor = false;
            this.StartSingleGameBtn.Click += new System.EventHandler(this.StartSingleGameBtn_Click);
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Location = new System.Drawing.Point(776, 496);
            this.MessageTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MessageTextBox.Multiline = true;
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MessageTextBox.Size = new System.Drawing.Size(388, 104);
            this.MessageTextBox.TabIndex = 7;
            this.MessageTextBox.TextChanged += new System.EventHandler(this.MessageBox_TextChanged);
            // 
            // MultiPlayerGameBtn
            // 
            this.MultiPlayerGameBtn.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.MultiPlayerGameBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MultiPlayerGameBtn.Location = new System.Drawing.Point(405, 718);
            this.MultiPlayerGameBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MultiPlayerGameBtn.Name = "MultiPlayerGameBtn";
            this.MultiPlayerGameBtn.Size = new System.Drawing.Size(283, 81);
            this.MultiPlayerGameBtn.TabIndex = 8;
            this.MultiPlayerGameBtn.Text = "MultiPlayer Game";
            this.MultiPlayerGameBtn.UseVisualStyleBackColor = false;
            this.MultiPlayerGameBtn.Click += new System.EventHandler(this.MultiPlayerGameBtn_Click);
            // 
            // PageTitle
            // 
            this.PageTitle.AutoSize = true;
            this.PageTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PageTitle.Location = new System.Drawing.Point(442, 11);
            this.PageTitle.Name = "PageTitle";
            this.PageTitle.Size = new System.Drawing.Size(156, 54);
            this.PageTitle.TabIndex = 9;
            this.PageTitle.Text = "Lobby";
            this.PageTitle.Click += new System.EventHandler(this.PageTitle_Click);
            // 
            // StartGameLabel
            // 
            this.StartGameLabel.AutoSize = true;
            this.StartGameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartGameLabel.Location = new System.Drawing.Point(396, 564);
            this.StartGameLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.StartGameLabel.Name = "StartGameLabel";
            this.StartGameLabel.Size = new System.Drawing.Size(312, 54);
            this.StartGameLabel.TabIndex = 10;
            this.StartGameLabel.Text = "Start a Game";
            this.StartGameLabel.Click += new System.EventHandler(this.Label1_Click);
            // 
            // LeaderboardBtn
            // 
            this.LeaderboardBtn.BackColor = System.Drawing.Color.White;
            this.LeaderboardBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LeaderboardBtn.Location = new System.Drawing.Point(960, 767);
            this.LeaderboardBtn.Name = "LeaderboardBtn";
            this.LeaderboardBtn.Size = new System.Drawing.Size(204, 65);
            this.LeaderboardBtn.TabIndex = 11;
            this.LeaderboardBtn.Text = "Leaderboard";
            this.LeaderboardBtn.UseVisualStyleBackColor = false;
            this.LeaderboardBtn.Click += new System.EventHandler(this.LeaderboardBtn_Click);
            // 
            // ProfileBtn
            // 
            this.ProfileBtn.Location = new System.Drawing.Point(12, 704);
            this.ProfileBtn.Name = "ProfileBtn";
            this.ProfileBtn.Size = new System.Drawing.Size(187, 51);
            this.ProfileBtn.TabIndex = 12;
            this.ProfileBtn.Text = "Profile";
            this.ProfileBtn.UseVisualStyleBackColor = true;
            this.ProfileBtn.Click += new System.EventHandler(this.ProfileBtn_Click);
            // 
            // OnlinePlayerLabel
            // 
            this.OnlinePlayerLabel.AutoSize = true;
            this.OnlinePlayerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OnlinePlayerLabel.Location = new System.Drawing.Point(12, 32);
            this.OnlinePlayerLabel.Name = "OnlinePlayerLabel";
            this.OnlinePlayerLabel.Size = new System.Drawing.Size(293, 46);
            this.OnlinePlayerLabel.TabIndex = 13;
            this.OnlinePlayerLabel.Text = "Online Players";
            this.OnlinePlayerLabel.Click += new System.EventHandler(this.OnlinePlayerLabel_Click);
            // 
            // LobbyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(1184, 847);
            this.Controls.Add(this.OnlinePlayerLabel);
            this.Controls.Add(this.ProfileBtn);
            this.Controls.Add(this.LeaderboardBtn);
            this.Controls.Add(this.StartGameLabel);
            this.Controls.Add(this.PageTitle);
            this.Controls.Add(this.MultiPlayerGameBtn);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.StartSingleGameBtn);
            this.Controls.Add(this.AdminDashBtn);
            this.Controls.Add(this.LogOutBtn);
            this.Controls.Add(this.OnlinePlayer);
            this.Controls.Add(this.ChatHistory);
            this.Controls.Add(this.SendMessageBtn);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LobbyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LobbyForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SendMessageBtn;
        private System.Windows.Forms.ListBox ChatHistory;
        private System.Windows.Forms.ListBox OnlinePlayer;
        private System.Windows.Forms.Button LogOutBtn;
        private System.Windows.Forms.Button AdminDashBtn;
        private System.Windows.Forms.Button StartSingleGameBtn;
        private System.Windows.Forms.TextBox MessageTextBox;
        private System.Windows.Forms.Button MultiPlayerGameBtn;
        private System.Windows.Forms.Label PageTitle;
        private System.Windows.Forms.Label StartGameLabel;
        private System.Windows.Forms.Button LeaderboardBtn;
        private System.Windows.Forms.Button ProfileBtn;
        private System.Windows.Forms.Label OnlinePlayerLabel;
    }
}