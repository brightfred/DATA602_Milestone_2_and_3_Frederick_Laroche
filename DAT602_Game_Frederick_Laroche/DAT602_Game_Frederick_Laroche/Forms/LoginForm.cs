using System;
using System.Diagnostics;
using System.Windows.Forms;
using DAT602_Game_Frederick_Laroche.Forms;

namespace DAT602_Game_Frederick_Laroche
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UsernameInput.Text) || string.IsNullOrEmpty(PasswordInput.Text))
            {
                LoginMsg.Text = "Please enter both username and password";
                return;
            }

            try
            {
                var result = UserDao.Login(UsernameInput.Text, PasswordInput.Text);
                LoginMsg.Text = result.Message;

                if (result.Message == "Login successful" && result.PlayerId.HasValue)
                {
                    CheckAdminStatus(result.PlayerId.Value);
                }
                else if (result.Message.Contains("Username not found"))
                {
                    if (MessageBox.Show("Creating a new account?", "User Not Found",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.Hide();
                        new RegistrationForm().Show();
                    }
                }
                else if (result.Message.Contains("locked out"))
                {
                    MessageBox.Show("Your account is locked out.");
                }
            }
            catch (Exception ex)
            {
                LoginMsg.Text = "Error: " + ex.Message;
            }
        }

        private void CheckAdminStatus(int playerID)
        {
            try
            {
                var adminCheck = UserDao.CheckAdminStatus(playerID);
                if (adminCheck)
                {
                    this.Hide();
                    AdminForm adminForm = new AdminForm(playerID);
                    adminForm.Show();
                }
                else
                {
                    this.Hide();
                    LobbyForm lobbyForm = new LobbyForm(playerID);
                    lobbyForm.Show();
                }
            }
            catch (Exception ex)
            {
                LoginMsg.Text = "Error checking admin status: " + ex.Message;
            }
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RegistrationForm().Show();
        }



        // Auto Generated
        private void PictureBox1_Click(object sender, EventArgs e) { }
        private void Label1_Click(object sender, EventArgs e) { }
        private void Label2_Click(object sender, EventArgs e) { }
        private void UsernameInput_TextChanged(object sender, EventArgs e) { }
        private void PasswordInput_TextChanged(object sender, EventArgs e) { }
    }
}