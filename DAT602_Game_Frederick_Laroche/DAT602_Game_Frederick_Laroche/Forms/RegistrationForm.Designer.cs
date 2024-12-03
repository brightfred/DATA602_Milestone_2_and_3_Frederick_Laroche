namespace DAT602_Game_Frederick_Laroche
{
    partial class RegistrationForm
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
            this.RegisterBackBtn = new System.Windows.Forms.Button();
            this.RegisterBtn = new System.Windows.Forms.Button();
            this.RegisterUsername = new System.Windows.Forms.TextBox();
            this.RegisterPassword = new System.Windows.Forms.TextBox();
            this.UsernameRegisterLabel = new System.Windows.Forms.Label();
            this.PasswordRegisterLabel = new System.Windows.Forms.Label();
            this.RegisterMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RegisterBackBtn
            // 
            this.RegisterBackBtn.Location = new System.Drawing.Point(457, 455);
            this.RegisterBackBtn.Name = "RegisterBackBtn";
            this.RegisterBackBtn.Size = new System.Drawing.Size(109, 78);
            this.RegisterBackBtn.TabIndex = 0;
            this.RegisterBackBtn.Text = "Back";
            this.RegisterBackBtn.UseVisualStyleBackColor = true;
            this.RegisterBackBtn.Click += new System.EventHandler(this.RegisterBackBtn_Click);
            // 
            // RegisterBtn
            // 
            this.RegisterBtn.Location = new System.Drawing.Point(617, 460);
            this.RegisterBtn.Name = "RegisterBtn";
            this.RegisterBtn.Size = new System.Drawing.Size(164, 69);
            this.RegisterBtn.TabIndex = 1;
            this.RegisterBtn.Text = "Register";
            this.RegisterBtn.UseVisualStyleBackColor = true;
            this.RegisterBtn.Click += new System.EventHandler(this.RegisterBtn_Click);
            // 
            // RegisterUsername
            // 
            this.RegisterUsername.Location = new System.Drawing.Point(601, 295);
            this.RegisterUsername.Name = "RegisterUsername";
            this.RegisterUsername.Size = new System.Drawing.Size(323, 38);
            this.RegisterUsername.TabIndex = 2;
            this.RegisterUsername.TextChanged += new System.EventHandler(this.RegisterUsername_TextChanged);
            // 
            // RegisterPassword
            // 
            this.RegisterPassword.Location = new System.Drawing.Point(595, 372);
            this.RegisterPassword.Name = "RegisterPassword";
            this.RegisterPassword.PasswordChar = '*';
            this.RegisterPassword.Size = new System.Drawing.Size(329, 38);
            this.RegisterPassword.TabIndex = 3;
            this.RegisterPassword.UseSystemPasswordChar = true;
            this.RegisterPassword.TextChanged += new System.EventHandler(this.RegisterPassword_TextChanged);
            // 
            // UsernameRegisterLabel
            // 
            this.UsernameRegisterLabel.AutoSize = true;
            this.UsernameRegisterLabel.Location = new System.Drawing.Point(451, 298);
            this.UsernameRegisterLabel.Name = "UsernameRegisterLabel";
            this.UsernameRegisterLabel.Size = new System.Drawing.Size(144, 32);
            this.UsernameRegisterLabel.TabIndex = 4;
            this.UsernameRegisterLabel.Text = "Username";
            this.UsernameRegisterLabel.Click += new System.EventHandler(this.UsernameRegisterLabel_Click);
            // 
            // PasswordRegisterLabel
            // 
            this.PasswordRegisterLabel.AutoSize = true;
            this.PasswordRegisterLabel.Location = new System.Drawing.Point(451, 372);
            this.PasswordRegisterLabel.Name = "PasswordRegisterLabel";
            this.PasswordRegisterLabel.Size = new System.Drawing.Size(138, 32);
            this.PasswordRegisterLabel.TabIndex = 5;
            this.PasswordRegisterLabel.Text = "Password";
            this.PasswordRegisterLabel.Click += new System.EventHandler(this.PasswordRegisterLabel_Click);
            // 
            // RegisterMsg
            // 
            this.RegisterMsg.AutoSize = true;
            this.RegisterMsg.Location = new System.Drawing.Point(568, 165);
            this.RegisterMsg.Name = "RegisterMsg";
            this.RegisterMsg.Size = new System.Drawing.Size(0, 32);
            this.RegisterMsg.TabIndex = 6;
            this.RegisterMsg.Click += new System.EventHandler(this.Label3_Click);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(1298, 819);
            this.Controls.Add(this.RegisterMsg);
            this.Controls.Add(this.PasswordRegisterLabel);
            this.Controls.Add(this.UsernameRegisterLabel);
            this.Controls.Add(this.RegisterPassword);
            this.Controls.Add(this.RegisterUsername);
            this.Controls.Add(this.RegisterBtn);
            this.Controls.Add(this.RegisterBackBtn);
            this.Name = "RegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegistrationForm";
            this.Load += new System.EventHandler(this.RegistrationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RegisterBackBtn;
        private System.Windows.Forms.Button RegisterBtn;
        private System.Windows.Forms.TextBox RegisterUsername;
        private System.Windows.Forms.TextBox RegisterPassword;
        private System.Windows.Forms.Label UsernameRegisterLabel;
        private System.Windows.Forms.Label PasswordRegisterLabel;
        private System.Windows.Forms.Label RegisterMsg;
    }
}