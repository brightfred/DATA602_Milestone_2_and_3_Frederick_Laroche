using System;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DAT602_Game_Frederick_Laroche.Forms
{
    public partial class profile : Form
    {
        private readonly int playerId;

        public profile(int playerId)
        {
            InitializeComponent();
            this.playerId = playerId;

        }


        private void UpdateDataBtn_Click(object sender, EventArgs e)
        {
            string newUsername = UsernameInput.Text.Trim();
            string newPassword = PasswordInput.Text.Trim();

            // Call the UpdatePlayer method
            string resultMessage = UserDao.UpdatePlayer(playerId, newUsername, newPassword);

            MessageBox.Show(resultMessage);

            //clear the input fields after the update
            UsernameInput.Text = "";
            PasswordInput.Text = "";
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            LobbyForm lobbyForm = new LobbyForm(playerId);
            lobbyForm.Show();
        }
        private void DeletePlayerBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete your account?", "Confirm Delete",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                   
                    string result = UserDao.DeletePlayer(playerId);
                    MessageBox.Show(result);
                    this.Hide();
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting player: " + ex.Message);
                }
            }
        }
        private void TextBox1_TextChanged(object sender, EventArgs e) { }
        private void ProfileTitle_Click(object sender, EventArgs e) { }
        private void NewUsernameLabel_Click(object sender, EventArgs e) { }
        private void NewPasswordLabel_Click(object sender, EventArgs e) { }
        private void TextBox2_TextChanged(object sender, EventArgs e) { }

    }
}