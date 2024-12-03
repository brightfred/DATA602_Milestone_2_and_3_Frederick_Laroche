namespace DAT602_Game_Frederick_Laroche.Forms
{
    partial class BaseGameForm
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
            this.components = new System.ComponentModel.Container();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.QuitGameBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GameTimer
            // 
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // QuitGameBtn
            // 
            this.QuitGameBtn.AutoSize = true;
            this.QuitGameBtn.BackColor = System.Drawing.Color.White;
            this.QuitGameBtn.Location = new System.Drawing.Point(1622, 797);
            this.QuitGameBtn.Name = "QuitGameBtn";
            this.QuitGameBtn.Size = new System.Drawing.Size(182, 75);
            this.QuitGameBtn.TabIndex = 0;
            this.QuitGameBtn.Text = "Quit Game";
            this.QuitGameBtn.UseVisualStyleBackColor = false;
            this.QuitGameBtn.Click += new System.EventHandler(this.QuitGameBtn_Click);
            // 
            // BaseGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(1816, 884);
            this.Controls.Add(this.QuitGameBtn);
            this.Name = "BaseGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BaseGameForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Button QuitGameBtn;
    }
}