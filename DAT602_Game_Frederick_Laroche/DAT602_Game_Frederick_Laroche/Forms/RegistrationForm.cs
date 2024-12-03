using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DAT602_Game_Frederick_Laroche
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(RegisterUsername.Text) || string.IsNullOrEmpty(RegisterPassword.Text))
            {
                RegisterMsg.Text = "Please enter both username and password";
                return;
            }

            try
            {
                var dataset = MySqlHelper.ExecuteDataset(AdminDao.MySqlConnection,
                    "call Register('" + RegisterUsername.Text + "', '" + RegisterPassword.Text + "')");

                string message = dataset.Tables[0].Rows[0]["Message"].ToString();
                RegisterMsg.Text = message;

                if (message == "Registration successful")
                {
                    MessageBox.Show("Registration successful! Please login.");
                    this.Hide();
                    new LoginForm().Show();
                }
            }
            catch (Exception ex)
            {
                RegisterMsg.Text = "Error: " + ex.Message;
            }
        }

        private void RegisterBackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

        // Auto Generatd
        private void Label3_Click(object sender, EventArgs e) { }
        private void RegisterUsername_TextChanged(object sender, EventArgs e) { }
        private void RegisterPassword_TextChanged(object sender, EventArgs e) { }
        private void PasswordRegisterLabel_Click(object sender, EventArgs e) { }
        private void UsernameRegisterLabel_Click(object sender, EventArgs e) { }
        private void RegistrationForm_Load(object sender, EventArgs e) { }
        

        
    }
}