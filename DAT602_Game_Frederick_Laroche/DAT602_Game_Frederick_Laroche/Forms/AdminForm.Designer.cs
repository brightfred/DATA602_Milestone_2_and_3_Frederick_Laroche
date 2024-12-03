namespace DAT602_Game_Frederick_Laroche.Forms
{
    partial class AdminForm
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
            this.Playerlist = new System.Windows.Forms.ListBox();
            this.Gamelist = new System.Windows.Forms.ListBox();
            this.BanBtn = new System.Windows.Forms.Button();
            this.UnbanUnlockBtn = new System.Windows.Forms.Button();
            this.DeletePlayerBtn = new System.Windows.Forms.Button();
            this.KillGameBtn = new System.Windows.Forms.Button();
            this.RefreshBtn = new System.Windows.Forms.Button();
            this.BackBtn = new System.Windows.Forms.Button();
            this.GameListLabel = new System.Windows.Forms.Label();
            this.PlayerListLabel = new System.Windows.Forms.Label();
            this.AddPlayerBtn = new System.Windows.Forms.Button();
            this.UsernameInput = new System.Windows.Forms.TextBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.AddPlayerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Playerlist
            // 
            this.Playerlist.FormattingEnabled = true;
            this.Playerlist.ItemHeight = 31;
            this.Playerlist.Location = new System.Drawing.Point(904, 78);
            this.Playerlist.MultiColumn = true;
            this.Playerlist.Name = "Playerlist";
            this.Playerlist.ScrollAlwaysVisible = true;
            this.Playerlist.Size = new System.Drawing.Size(453, 407);
            this.Playerlist.TabIndex = 0;
            this.Playerlist.SelectedIndexChanged += new System.EventHandler(this.Playerlist_SelectedIndexChanged);
            // 
            // Gamelist
            // 
            this.Gamelist.FormattingEnabled = true;
            this.Gamelist.ItemHeight = 31;
            this.Gamelist.Location = new System.Drawing.Point(12, 78);
            this.Gamelist.MultiColumn = true;
            this.Gamelist.Name = "Gamelist";
            this.Gamelist.ScrollAlwaysVisible = true;
            this.Gamelist.Size = new System.Drawing.Size(530, 407);
            this.Gamelist.TabIndex = 1;
            this.Gamelist.SelectedIndexChanged += new System.EventHandler(this.Gamelist_SelectedIndexChanged);
            // 
            // BanBtn
            // 
            this.BanBtn.BackColor = System.Drawing.Color.White;
            this.BanBtn.Location = new System.Drawing.Point(904, 512);
            this.BanBtn.Name = "BanBtn";
            this.BanBtn.Size = new System.Drawing.Size(180, 80);
            this.BanBtn.TabIndex = 2;
            this.BanBtn.Text = "Ban";
            this.BanBtn.UseVisualStyleBackColor = false;
            this.BanBtn.Click += new System.EventHandler(this.BanBtn_Click);
            // 
            // UnbanUnlockBtn
            // 
            this.UnbanUnlockBtn.BackColor = System.Drawing.Color.White;
            this.UnbanUnlockBtn.Location = new System.Drawing.Point(1096, 512);
            this.UnbanUnlockBtn.Name = "UnbanUnlockBtn";
            this.UnbanUnlockBtn.Size = new System.Drawing.Size(261, 80);
            this.UnbanUnlockBtn.TabIndex = 3;
            this.UnbanUnlockBtn.Text = "Unlock/Unban";
            this.UnbanUnlockBtn.UseVisualStyleBackColor = false;
            this.UnbanUnlockBtn.Click += new System.EventHandler(this.UnbanUnlockBtn_Click);
            // 
            // DeletePlayerBtn
            // 
            this.DeletePlayerBtn.AutoSize = true;
            this.DeletePlayerBtn.BackColor = System.Drawing.Color.White;
            this.DeletePlayerBtn.Location = new System.Drawing.Point(1096, 598);
            this.DeletePlayerBtn.Name = "DeletePlayerBtn";
            this.DeletePlayerBtn.Size = new System.Drawing.Size(261, 80);
            this.DeletePlayerBtn.TabIndex = 4;
            this.DeletePlayerBtn.Text = "Delete Player";
            this.DeletePlayerBtn.UseVisualStyleBackColor = false;
            this.DeletePlayerBtn.Click += new System.EventHandler(this.DeletePlayerBtn_Click);
            // 
            // KillGameBtn
            // 
            this.KillGameBtn.BackColor = System.Drawing.Color.White;
            this.KillGameBtn.Location = new System.Drawing.Point(189, 522);
            this.KillGameBtn.Name = "KillGameBtn";
            this.KillGameBtn.Size = new System.Drawing.Size(180, 80);
            this.KillGameBtn.TabIndex = 5;
            this.KillGameBtn.Text = "Kill Game";
            this.KillGameBtn.UseVisualStyleBackColor = false;
            this.KillGameBtn.Click += new System.EventHandler(this.KillGameBtn_Click);
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.BackColor = System.Drawing.Color.White;
            this.RefreshBtn.Location = new System.Drawing.Point(634, 171);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(180, 80);
            this.RefreshBtn.TabIndex = 6;
            this.RefreshBtn.Text = "Refresh";
            this.RefreshBtn.UseVisualStyleBackColor = false;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.White;
            this.BackBtn.Location = new System.Drawing.Point(634, 305);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(180, 80);
            this.BackBtn.TabIndex = 7;
            this.BackBtn.Text = "Back";
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // GameListLabel
            // 
            this.GameListLabel.AutoSize = true;
            this.GameListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameListLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GameListLabel.Location = new System.Drawing.Point(112, 9);
            this.GameListLabel.Name = "GameListLabel";
            this.GameListLabel.Size = new System.Drawing.Size(311, 54);
            this.GameListLabel.TabIndex = 8;
            this.GameListLabel.Text = "List of Games";
            this.GameListLabel.Click += new System.EventHandler(this.GameListLabel_Click);
            // 
            // PlayerListLabel
            // 
            this.PlayerListLabel.AutoSize = true;
            this.PlayerListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerListLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PlayerListLabel.Location = new System.Drawing.Point(995, 9);
            this.PlayerListLabel.Name = "PlayerListLabel";
            this.PlayerListLabel.Size = new System.Drawing.Size(292, 54);
            this.PlayerListLabel.TabIndex = 9;
            this.PlayerListLabel.Text = "List of Player";
            this.PlayerListLabel.Click += new System.EventHandler(this.PlayerListLabel_Click);
            // 
            // AddPlayerBtn
            // 
            this.AddPlayerBtn.AutoSize = true;
            this.AddPlayerBtn.BackColor = System.Drawing.Color.White;
            this.AddPlayerBtn.Location = new System.Drawing.Point(634, 866);
            this.AddPlayerBtn.Name = "AddPlayerBtn";
            this.AddPlayerBtn.Size = new System.Drawing.Size(180, 80);
            this.AddPlayerBtn.TabIndex = 10;
            this.AddPlayerBtn.Text = "Add Player";
            this.AddPlayerBtn.UseVisualStyleBackColor = false;
            this.AddPlayerBtn.Click += new System.EventHandler(this.AddPlayerBtn_Click);
            // 
            // UsernameInput
            // 
            this.UsernameInput.Location = new System.Drawing.Point(596, 739);
            this.UsernameInput.Name = "UsernameInput";
            this.UsernameInput.Size = new System.Drawing.Size(247, 38);
            this.UsernameInput.TabIndex = 11;
            this.UsernameInput.TextChanged += new System.EventHandler(this.UsernameInput_TextChanged);
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(596, 803);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(247, 38);
            this.PasswordBox.TabIndex = 12;
            this.PasswordBox.TextChanged += new System.EventHandler(this.PasswordBox_TextChanged);
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(446, 745);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(144, 32);
            this.UsernameLabel.TabIndex = 13;
            this.UsernameLabel.Text = "Username";
            this.UsernameLabel.Click += new System.EventHandler(this.UsernameLabel_Click);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(446, 806);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(138, 32);
            this.PasswordLabel.TabIndex = 14;
            this.PasswordLabel.Text = "Password";
            this.PasswordLabel.Click += new System.EventHandler(this.PasswordLabel_Click);
            // 
            // AddPlayerLabel
            // 
            this.AddPlayerLabel.AutoSize = true;
            this.AddPlayerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddPlayerLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.AddPlayerLabel.Location = new System.Drawing.Point(532, 658);
            this.AddPlayerLabel.Name = "AddPlayerLabel";
            this.AddPlayerLabel.Size = new System.Drawing.Size(360, 54);
            this.AddPlayerLabel.TabIndex = 15;
            this.AddPlayerLabel.Text = "Create Account";
            this.AddPlayerLabel.Click += new System.EventHandler(this.AddPlayerLabel_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(1364, 1058);
            this.Controls.Add(this.AddPlayerLabel);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.UsernameInput);
            this.Controls.Add(this.AddPlayerBtn);
            this.Controls.Add(this.PlayerListLabel);
            this.Controls.Add(this.GameListLabel);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.RefreshBtn);
            this.Controls.Add(this.KillGameBtn);
            this.Controls.Add(this.DeletePlayerBtn);
            this.Controls.Add(this.UnbanUnlockBtn);
            this.Controls.Add(this.BanBtn);
            this.Controls.Add(this.Gamelist);
            this.Controls.Add(this.Playerlist);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Playerlist;
        private System.Windows.Forms.ListBox Gamelist;
        private System.Windows.Forms.Button BanBtn;
        private System.Windows.Forms.Button UnbanUnlockBtn;
        private System.Windows.Forms.Button DeletePlayerBtn;
        private System.Windows.Forms.Button KillGameBtn;
        private System.Windows.Forms.Button RefreshBtn;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.Label GameListLabel;
        private System.Windows.Forms.Label PlayerListLabel;
        private System.Windows.Forms.Button AddPlayerBtn;
        private System.Windows.Forms.TextBox UsernameInput;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label AddPlayerLabel;
    }
}