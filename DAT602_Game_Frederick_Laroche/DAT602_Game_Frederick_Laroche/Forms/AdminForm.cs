using System;
using System.Data;
using System.Windows.Forms;

namespace DAT602_Game_Frederick_Laroche.Forms
{
    public partial class AdminForm : Form
    {
        private DataTable playerTable;
        private DataTable gameTable;
        private readonly int currentPlayerID;

        //constructor 
        public AdminForm(int playerID)
        {
            InitializeComponent();
            currentPlayerID = playerID;
            RefreshLists();
        }

        private void RefreshLists()
        {
            try
            {
                // Get all players
                playerTable = AdminDao.GetAllPlayers();
                Playerlist.Items.Clear();
                foreach (DataRow player in playerTable.Rows)
                {
                    string playerInfo = $"Player {player["player_id"]} - {player["username"]} [{player["status"]}]";
                    Playerlist.Items.Add(playerInfo);
                }

                // Get running games
                gameTable = AdminDao.GetActiveGames();
                Gamelist.Items.Clear();
                foreach (DataRow game in gameTable.Rows)
                {
                    string gameInfo = $"Game {game["game_id"]} - {game["game_type"]} - Player: {game["player_id"]}";
                    Gamelist.Items.Add(gameInfo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing lists: " + ex.Message);
            }
        }

        // Ban player
        private void BanBtn_Click(object sender, EventArgs e)
        {
            if (Playerlist.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a player first");
                return;
            }

            try
            {
                int playerId = Convert.ToInt32(playerTable.Rows[Playerlist.SelectedIndex]["player_id"]);
                string result = AdminDao.UpdatePlayerStatus(playerId, "banned");
                MessageBox.Show(result);
                RefreshLists();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error banning player: " + ex.Message);
            }
        }

        // Unlock and unban player
        private void UnbanUnlockBtn_Click(object sender, EventArgs e)
        {
            if (Playerlist.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a player first");
                return;
            }

            try
            {
                int playerId = Convert.ToInt32(playerTable.Rows[Playerlist.SelectedIndex]["player_id"]);
                string result = AdminDao.UpdatePlayerStatus(playerId, "offline");
                MessageBox.Show(result);
                RefreshLists();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error unlocking or unbanning player: " + ex.Message);
            }
        }

        // Delete player account
        private void DeletePlayerBtn_Click(object sender, EventArgs e)
        {
            if (Playerlist.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a player first");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this player?", "Confirm Delete",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int playerId = Convert.ToInt32(playerTable.Rows[Playerlist.SelectedIndex]["player_id"]);
                    string result = UserDao.DeletePlayer(playerId);
                    MessageBox.Show(result);
                    RefreshLists();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting player: " + ex.Message);
                }
            }
        }

        // Terminate a running game
        private void KillGameBtn_Click(object sender, EventArgs e)
        {
            if (Gamelist.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a game first");
                return;
            }

            try
            {
                int gameId = Convert.ToInt32(gameTable.Rows[Gamelist.SelectedIndex]["game_id"]);
                string result = AdminDao.StopGame(gameId);
                MessageBox.Show(result);
                RefreshLists();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error stopping game: " + ex.Message);
            }
        }

        // Add new player(use register)
        private void AddPlayerBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string username = UsernameInput.Text.Trim();
                string password = PasswordBox.Text;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Username and password are required!");
                    return;
                }

                string result = UserDao.Register(username, password);
                MessageBox.Show(result);

                // Clear the input fields after successful registration
                UsernameInput.Clear();
                PasswordBox.Clear();

                RefreshLists();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding player: " + ex.Message);
            }
        }

        // Refresh the list
        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            RefreshLists();
        }

        // Go back to lobby btn
        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            LobbyForm lobbyForm = new LobbyForm(currentPlayerID);
            lobbyForm.Show();
        }

        // Auto Generated 
        private void Gamelist_SelectedIndexChanged(object sender, EventArgs e) { }
        private void Playerlist_SelectedIndexChanged(object sender, EventArgs e) { }
        private void GameListLabel_Click(object sender, EventArgs e) { }
        private void PlayerListLabel_Click(object sender, EventArgs e) { }
        private void AdminForm_Load(object sender, EventArgs e) { }
        private void UsernameInput_TextChanged(object sender, EventArgs e) { }
        private void PasswordBox_TextChanged(object sender, EventArgs e) { }
        private void UsernameLabel_Click(object sender, EventArgs e) { }
        private void PasswordLabel_Click(object sender, EventArgs e) { }
        private void AddPlayerLabel_Click(object sender, EventArgs e) { }
    }
}