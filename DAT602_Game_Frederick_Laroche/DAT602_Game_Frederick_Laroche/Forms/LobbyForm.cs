using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DAT602_Game_Frederick_Laroche.Forms
{
    public partial class LobbyForm : Form
    {
        private readonly Timer chatRefreshTimer;
        private readonly int currentPlayerID;

        // Main constructor for lobby form
        // Needs player ID
        // Sets up chat timer and loads all info
        public LobbyForm(int playerID)
        {
            InitializeComponent();
            currentPlayerID = playerID;
            StartSingleGameBtn.Enabled = true;

            // Update chat every 5 seconds
            chatRefreshTimer = new Timer
            {
                Interval = 5000
            };
            chatRefreshTimer.Tick += RefreshChat;
            chatRefreshTimer.Start();

            // Get everything ready when form opens
            RefreshOnlinePlayers();
            RefreshChat(null, null);
            CheckAdminAccess();
        }

        // Gets chat messages from database and shows them
        //
        private void RefreshChat(object sender, EventArgs e)
        {
            try
            {
                var messages = AdminDao.GetChatMessages();
                ChatHistory.Items.Clear();
                foreach (var row in System.Data.DataTableExtensions.AsEnumerable(messages))
                {
                    ChatHistory.Items.Add($"[{row["timestamp"]}] {row["username"]}: {row["message"]}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading chat: " + ex.Message);
            }
        }

        // Shows list of players that are online
        private void RefreshOnlinePlayers()
        {
            try
            {
                var onlinePlayers = AdminDao.GetOnlinePlayers();
                OnlinePlayer.Items.Clear();
                foreach (var row in System.Data.DataTableExtensions.AsEnumerable(onlinePlayers))
                {
                    OnlinePlayer.Items.Add(row["username"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading players: " + ex.Message);
            }
        }
        // Adds new message to chat when Send button clicked
        private void SendMessageBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MessageTextBox.Text))
                return;

            try
            {
                string result = AdminDao.SendChatMessage(currentPlayerID, MessageTextBox.Text);
                MessageTextBox.Clear();
                RefreshChat(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending message: " + ex.Message);
            }
        }

        // Starts a new single player game
        // Stops chat timer and shows game form
        private void StartSingleGameBtn_Click(object sender, EventArgs e)
        {
            try
            {
                chatRefreshTimer.Stop(); // Stop chat updates while in game
                this.Hide();
                SinglePlayerForm singlePlayerForm = new SinglePlayerForm(currentPlayerID);
                singlePlayerForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error starting game: " + ex.Message);
                chatRefreshTimer.Start(); // Restart chat if game fails to start
            }
        }

        // Not working yet, will add multiplayer later
        private void MultiPlayerGameBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (OnlinePlayer.SelectedItem == null)
                {
                    MessageBox.Show("Please select a player to invite to multiplayer game");
                    return;
                }

                string selectedPlayer = OnlinePlayer.SelectedItem.ToString();
                MessageBox.Show($"Multiplayer game will be implemented soon!\nSelected player: {selectedPlayer}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error starting multiplayer game: " + ex.Message);
            }
        }

        // Updates online players list when refresh clicked
        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            RefreshOnlinePlayers();
        }

        // Handles logout button
        // Stops chat timer and goes back to login
        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            chatRefreshTimer.Stop();
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        // Opens admin dashboard if player is admin
        private void AdminDashBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm adminForm = new AdminForm(currentPlayerID);
            adminForm.Show();
        }

        // Checks if current player is admin
        // Shows/hides admin button based on result
        private void CheckAdminAccess()
        {
            try
            {
                var dataset = MySqlHelper.ExecuteDataset(AdminDao.MySqlConnection,
                    "call CheckAdminStatus(@playerId)",
                    new MySqlParameter("@playerId", currentPlayerID));

                AdminDashBtn.Visible = Convert.ToBoolean(dataset.Tables[0].Rows[0]["is_admin"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking admin status: " + ex.Message);
            }
        }

        // Shows leaderboard form
        private void LeaderboardBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            LeaderBoardForm leaderBoardForm = new LeaderBoardForm(currentPlayerID);
            leaderBoardForm.Show();
        }

        // Shows profile form
        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            profile profileForm = new profile(currentPlayerID);
            profileForm.Show();
        }

        // Auto Gnerated
        private void OnlinePlayerLabel_Click(object sender, EventArgs e) { }
        private void OnlinePlayer_SelectedIndexChanged(object sender, EventArgs e) { }
        private void ChatHistory_SelectedIndexChanged(object sender, EventArgs e) { }
        private void MessageBox_TextChanged(object sender, EventArgs e) { }
        private void PageTitle_Click(object sender, EventArgs e) { }
        private void Label1_Click(object sender, EventArgs e) { }
    }
}