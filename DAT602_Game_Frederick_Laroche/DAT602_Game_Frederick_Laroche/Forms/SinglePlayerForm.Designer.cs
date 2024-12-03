namespace DAT602_Game_Frederick_Laroche.Forms
{
    partial class SinglePlayerForm
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
            this.GameGrid = new System.Windows.Forms.TableLayoutPanel();
            this.PlayerStatsBox = new System.Windows.Forms.GroupBox();
            this.TimerValue = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.ScoreValue = new System.Windows.Forms.Label();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.HealthPointValue = new System.Windows.Forms.Label();
            this.HealthLabel = new System.Windows.Forms.Label();
            this.InventoryBox = new System.Windows.Forms.GroupBox();
            this.List = new System.Windows.Forms.ListBox();
            this.PlayerStatsBox.SuspendLayout();
            this.InventoryBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameGrid
            // 
            this.GameGrid.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GameGrid.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.GameGrid.ColumnCount = 10;
            this.GameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameGrid.Location = new System.Drawing.Point(701, 336);
            this.GameGrid.Name = "GameGrid";
            this.GameGrid.RowCount = 10;
            this.GameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameGrid.Size = new System.Drawing.Size(500, 500);
            this.GameGrid.TabIndex = 0;
            this.GameGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.GameGrid_Paint);
            // 
            // PlayerStatsBox
            // 
            this.PlayerStatsBox.Controls.Add(this.TimerValue);
            this.PlayerStatsBox.Controls.Add(this.TimeLabel);
            this.PlayerStatsBox.Controls.Add(this.ScoreValue);
            this.PlayerStatsBox.Controls.Add(this.ScoreLabel);
            this.PlayerStatsBox.Controls.Add(this.HealthPointValue);
            this.PlayerStatsBox.Controls.Add(this.HealthLabel);
            this.PlayerStatsBox.Location = new System.Drawing.Point(601, 120);
            this.PlayerStatsBox.Name = "PlayerStatsBox";
            this.PlayerStatsBox.Size = new System.Drawing.Size(663, 160);
            this.PlayerStatsBox.TabIndex = 1;
            this.PlayerStatsBox.TabStop = false;
            this.PlayerStatsBox.Text = "Stats";
            this.PlayerStatsBox.Enter += new System.EventHandler(this.PlayerStatsBox_Enter);
            // 
            // TimerValue
            // 
            this.TimerValue.AutoSize = true;
            this.TimerValue.Location = new System.Drawing.Point(548, 105);
            this.TimerValue.Name = "TimerValue";
            this.TimerValue.Size = new System.Drawing.Size(44, 32);
            this.TimerValue.TabIndex = 5;
            this.TimerValue.Text = "0s";
            this.TimerValue.Click += new System.EventHandler(this.TimerValue_Click);
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Location = new System.Drawing.Point(526, 59);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(85, 32);
            this.TimeLabel.TabIndex = 4;
            this.TimeLabel.Text = "Time:";
            this.TimeLabel.Click += new System.EventHandler(this.TimeLabel_Click);
            // 
            // ScoreValue
            // 
            this.ScoreValue.AutoSize = true;
            this.ScoreValue.Location = new System.Drawing.Point(301, 105);
            this.ScoreValue.Name = "ScoreValue";
            this.ScoreValue.Size = new System.Drawing.Size(30, 32);
            this.ScoreValue.TabIndex = 3;
            this.ScoreValue.Text = "0";
            this.ScoreValue.Click += new System.EventHandler(this.ScoreValue_Click);
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Location = new System.Drawing.Point(274, 59);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(96, 32);
            this.ScoreLabel.TabIndex = 2;
            this.ScoreLabel.Text = "Score:";
            this.ScoreLabel.Click += new System.EventHandler(this.ScoreLabel_Click);
            // 
            // HealthPointValue
            // 
            this.HealthPointValue.AutoSize = true;
            this.HealthPointValue.Location = new System.Drawing.Point(86, 105);
            this.HealthPointValue.Name = "HealthPointValue";
            this.HealthPointValue.Size = new System.Drawing.Size(30, 32);
            this.HealthPointValue.TabIndex = 1;
            this.HealthPointValue.Text = "3";
            this.HealthPointValue.Click += new System.EventHandler(this.HealthPointValue_Click);
            // 
            // HealthLabel
            // 
            this.HealthLabel.AutoSize = true;
            this.HealthLabel.Location = new System.Drawing.Point(6, 59);
            this.HealthLabel.Name = "HealthLabel";
            this.HealthLabel.Size = new System.Drawing.Size(184, 32);
            this.HealthLabel.TabIndex = 0;
            this.HealthLabel.Text = "Health Points";
            this.HealthLabel.Click += new System.EventHandler(this.HealthLabel_Click);
            // 
            // InventoryBox
            // 
            this.InventoryBox.Controls.Add(this.List);
            this.InventoryBox.Location = new System.Drawing.Point(548, 336);
            this.InventoryBox.Name = "InventoryBox";
            this.InventoryBox.Size = new System.Drawing.Size(147, 482);
            this.InventoryBox.TabIndex = 2;
            this.InventoryBox.TabStop = false;
            this.InventoryBox.Text = "Inventory";
            this.InventoryBox.Enter += new System.EventHandler(this.InventoryBox_Enter);
            // 
            // List
            // 
            this.List.BackColor = System.Drawing.Color.Gray;
            this.List.FormattingEnabled = true;
            this.List.ItemHeight = 31;
            this.List.Location = new System.Drawing.Point(6, 32);
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(141, 438);
            this.List.TabIndex = 0;
            this.List.SelectedIndexChanged += new System.EventHandler(this.List_SelectedIndexChanged);
            // 
            // SinglePlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1823, 908);
            this.Controls.Add(this.InventoryBox);
            this.Controls.Add(this.PlayerStatsBox);
            this.Controls.Add(this.GameGrid);
            this.Name = "SinglePlayerForm";
            this.Text = "SinglePlayerForm";
            this.Load += new System.EventHandler(this.SinglePlayerForm_Load);
            this.Controls.SetChildIndex(this.GameGrid, 0);
            this.Controls.SetChildIndex(this.PlayerStatsBox, 0);
            this.Controls.SetChildIndex(this.InventoryBox, 0);
            this.PlayerStatsBox.ResumeLayout(false);
            this.PlayerStatsBox.PerformLayout();
            this.InventoryBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel GameGrid;
        private System.Windows.Forms.GroupBox PlayerStatsBox;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Label ScoreValue;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Label HealthPointValue;
        private System.Windows.Forms.Label HealthLabel;
        private System.Windows.Forms.Label TimerValue;
        private System.Windows.Forms.GroupBox InventoryBox;
        private System.Windows.Forms.ListBox List;
    }
}