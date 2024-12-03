namespace DAT602_Game_Frederick_Laroche.Forms
{
    partial class profile
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
            this.BackBtn = new System.Windows.Forms.Button();
            this.UsernameInput = new System.Windows.Forms.TextBox();
            this.ProfileTitle = new System.Windows.Forms.Label();
            this.NewUsernameLabel = new System.Windows.Forms.Label();
            this.UpdateDataBtn = new System.Windows.Forms.Button();
            this.PasswordInput = new System.Windows.Forms.TextBox();
            this.NewPasswordLabel = new System.Windows.Forms.Label();
            this.DeletePlayerBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BackBtn
            // 
            this.BackBtn.Location = new System.Drawing.Point(21, 850);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(168, 67);
            this.BackBtn.TabIndex = 0;
            this.BackBtn.Text = "Back";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // UsernameInput
            // 
            this.UsernameInput.Location = new System.Drawing.Point(652, 402);
            this.UsernameInput.Name = "UsernameInput";
            this.UsernameInput.Size = new System.Drawing.Size(400, 38);
            this.UsernameInput.TabIndex = 1;
            this.UsernameInput.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // ProfileTitle
            // 
            this.ProfileTitle.AutoSize = true;
            this.ProfileTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileTitle.Location = new System.Drawing.Point(752, 84);
            this.ProfileTitle.Name = "ProfileTitle";
            this.ProfileTitle.Size = new System.Drawing.Size(162, 54);
            this.ProfileTitle.TabIndex = 2;
            this.ProfileTitle.Text = "Profile";
            this.ProfileTitle.Click += new System.EventHandler(this.ProfileTitle_Click);
            // 
            // NewUsernameLabel
            // 
            this.NewUsernameLabel.AutoSize = true;
            this.NewUsernameLabel.Location = new System.Drawing.Point(338, 402);
            this.NewUsernameLabel.Name = "NewUsernameLabel";
            this.NewUsernameLabel.Size = new System.Drawing.Size(274, 32);
            this.NewUsernameLabel.TabIndex = 3;
            this.NewUsernameLabel.Text = "Enter new username";
            this.NewUsernameLabel.Click += new System.EventHandler(this.NewUsernameLabel_Click);
            // 
            // UpdateDataBtn
            // 
            this.UpdateDataBtn.Location = new System.Drawing.Point(667, 567);
            this.UpdateDataBtn.Name = "UpdateDataBtn";
            this.UpdateDataBtn.Size = new System.Drawing.Size(350, 53);
            this.UpdateDataBtn.TabIndex = 4;
            this.UpdateDataBtn.Text = "Update data";
            this.UpdateDataBtn.UseVisualStyleBackColor = true;
            this.UpdateDataBtn.Click += new System.EventHandler(this.UpdateDataBtn_Click);
            // 
            // PasswordInput
            // 
            this.PasswordInput.Location = new System.Drawing.Point(652, 469);
            this.PasswordInput.Name = "PasswordInput";
            this.PasswordInput.Size = new System.Drawing.Size(400, 38);
            this.PasswordInput.TabIndex = 5;
            this.PasswordInput.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // NewPasswordLabel
            // 
            this.NewPasswordLabel.AutoSize = true;
            this.NewPasswordLabel.Location = new System.Drawing.Point(338, 469);
            this.NewPasswordLabel.Name = "NewPasswordLabel";
            this.NewPasswordLabel.Size = new System.Drawing.Size(269, 32);
            this.NewPasswordLabel.TabIndex = 6;
            this.NewPasswordLabel.Text = "Enter new password";
            this.NewPasswordLabel.Click += new System.EventHandler(this.NewPasswordLabel_Click);
            // 
            // DeletePlayerBtn
            // 
            this.DeletePlayerBtn.Location = new System.Drawing.Point(1399, 850);
            this.DeletePlayerBtn.Name = "DeletePlayerBtn";
            this.DeletePlayerBtn.Size = new System.Drawing.Size(244, 67);
            this.DeletePlayerBtn.TabIndex = 7;
            this.DeletePlayerBtn.Text = "Delete Account";
            this.DeletePlayerBtn.UseVisualStyleBackColor = true;
            this.DeletePlayerBtn.Click += new System.EventHandler(this.DeletePlayerBtn_Click);
            // 
            // profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(1664, 929);
            this.Controls.Add(this.DeletePlayerBtn);
            this.Controls.Add(this.NewPasswordLabel);
            this.Controls.Add(this.PasswordInput);
            this.Controls.Add(this.UpdateDataBtn);
            this.Controls.Add(this.NewUsernameLabel);
            this.Controls.Add(this.ProfileTitle);
            this.Controls.Add(this.UsernameInput);
            this.Controls.Add(this.BackBtn);
            this.Name = "profile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "profile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.TextBox UsernameInput;
        private System.Windows.Forms.Label ProfileTitle;
        private System.Windows.Forms.Label NewUsernameLabel;
        private System.Windows.Forms.Button UpdateDataBtn;
        private System.Windows.Forms.TextBox PasswordInput;
        private System.Windows.Forms.Label NewPasswordLabel;
        private System.Windows.Forms.Button DeletePlayerBtn;
    }
}