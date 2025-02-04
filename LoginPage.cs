using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginAuthPB
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }

        private void LoginTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            string userInputKey = LoginTextBox.Text;

            if (!string.IsNullOrEmpty(userInputKey))
            {
                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        string remoteKeyList = await webClient.DownloadStringTaskAsync("https://pastebin.com/raw/sJwXW5w9");

                        if (remoteKeyList.Contains(userInputKey))
                        {
                            // If the key is correct
                            this.Hide();

                            HomePage executer = new HomePage();
                            await Task.Delay(0);
                            executer.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid key", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (WebException ex)
                {
                    MessageBox.Show($"Connection error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You haven't entered a key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
