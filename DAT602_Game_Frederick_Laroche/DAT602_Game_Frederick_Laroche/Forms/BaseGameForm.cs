using System;
using System.Windows.Forms;

namespace DAT602_Game_Frederick_Laroche.Forms
{
    // My base form that single player and mutliplayer forms will use
    public partial class BaseGameForm : Form
    {
        protected int currentPlayerID;    // Which player is using the form
        protected int elapsedSeconds = 0; // How long the game has been running
        protected int gameId;             // Which game is being played

        // Constructor for designer
        public BaseGameForm()
        {
            InitializeComponent();
            SetupTimer();
        }

        // Constructor for/with player ID
        public BaseGameForm(int playerID) : this()
        {
            currentPlayerID = playerID;
        }

        // Sets up how the timer works
        private void SetupTimer()
        {
            GameTimer.Interval = 2000; // One tick per 2 second (not perfect but works somehow)
            GameTimer.Tick += GameTimer_Tick;
        }

        // What happens every second
        protected virtual void GameTimer_Tick(object sender, EventArgs e)
        {
            elapsedSeconds++;
        }

        // Gets the time in min and seconds format
        protected string GetFormattedTime()
        {
            int minutes = elapsedSeconds / 60;
            int seconds = elapsedSeconds % 60;
            return minutes + ":" + seconds;
        }

        // Start counting time
        protected void StartGameTimer()
        {
            elapsedSeconds = 0;
            GameTimer.Start();
        }

        // Stop counting time
        protected void StopGameTimer()
        {
            GameTimer.Stop();
        }

        // For updating the game board
        protected virtual void RefreshGameBoard()
        {
            // My child forms will use this
        }

        // Quit button click
        private void QuitGameBtn_Click(object sender, EventArgs e)
        {
            try
            {
                StopGameTimer();
                this.Hide();
                new LobbyForm(currentPlayerID).Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error quitting game: " + ex.Message);
            }
        }

        // Makes sure timer stops when form closes
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                StopGameTimer();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error closing form: " + ex.Message);
            }
            base.OnFormClosing(e);
        }

        // Auto Generated
        private void BaseGameForm_Load(object sender, EventArgs e) { }
   
        private void HealthIcon_Click(object sender, EventArgs e) { }
        private void ScoreIcon_Click(object sender, EventArgs e) { }
        private void TimerIcon_Click(object sender, EventArgs e) { }
        private void HealthLabel_Click(object sender, EventArgs e) { }
        private void ScoreLabel_Click(object sender, EventArgs e) { }
        private void TimeLabel_Click(object sender, EventArgs e) { }
        private void HealthPointValue_Click(object sender, EventArgs e) { }
        private void ScoreValue_Click(object sender, EventArgs e) { }
        private void TimerValue_Click(object sender, EventArgs e) { }
    }
}
