using System;
using System.Data;
using System.Windows.Forms;
namespace DAT602_Game_Frederick_Laroche.Forms
{
    public partial class LeaderBoardForm : Form
    {
        private readonly int currentPlayerId;

        public LeaderBoardForm(int playerId)
        {
            InitializeComponent();
            currentPlayerId = playerId;
            RefreshLeaderboard();
        }

        private void RefreshLeaderboard()
        {
            try
            {
                var leaderboardData = GameDao.GetLeaderBoard();
                LeaderBoard.Items.Clear();

                // I added a simple headers to make it easier to understand for the user
                // I divided the time in 60 to get minutes and remainder of seconds
                // Increment the rank
                LeaderBoard.Items.Add("Rank | Username | Game Type | Score | Time");
                LeaderBoard.Items.Add("----------------------------------------");

                if (leaderboardData != null)
                {
                    int rank = 1;
                    foreach (DataRow row in leaderboardData.Rows)
                    {
                        // Get the game completion time in second
                        int totalSeconds = Convert.ToInt32(row["finish_time"]);

                        // number of minutes
                        int minutes = totalSeconds / 60;

                        // remaining seconds after the division
                        int seconds = totalSeconds % 60;

                        // My formatted string 
                        string formatedString = $"#{rank} | {row["username"]} | {row["game_type"]} | {row["total_score"]} pts | {minutes}m {seconds}s";

                        LeaderBoard.Items.Add(formatedString);
                        rank++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing the leaderboard: {ex.Message}");
            }
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            RefreshLeaderboard();
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LobbyForm(currentPlayerId).Show();
        }

        private void LeaderBoard_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}