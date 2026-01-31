using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class LoginPage : Form
    {
        private int intRow = 0;
        private int attemptCount = 1;
        public LoginPage()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void resetMe()
        {

            loginTextBox.Text = "";
            passwordTextBox.Text = "";

        }

        private void loadData(string login, string password)
        {
            CRUD.sql = "SELECT * FROM users where login::text LIKE @login::varchar AND password::text LIKE @password::varchar";


            string strLogin = string.Format("%{0}%", login);
            string strPassword = string.Format("%{0}%", password);

            CRUD.cmd = new NpgsqlCommand(CRUD.sql, CRUD.connection);
            CRUD.cmd.Parameters.Clear();
            CRUD.cmd.Parameters.AddWithValue("login", strLogin);
            CRUD.cmd.Parameters.AddWithValue("password", strPassword);

            DataTable dt = CRUD.PerformCRUD(CRUD.cmd);

            if (dt.Rows.Count > 0)
            {
                intRow = 1;
                CRUD.userLogin = dt.Rows[0][1].ToString();
                CRUD.userRole = dt.Rows[0][3].ToString();
            }
            else
            {
                intRow = 0;
            }

        }


        private void loginBtn_Click(object sender, EventArgs e)
        {
            if(attemptCount >= 2)
            {
                MessageBox.Show("You lose all your attempt for log in, restart app", "Log in", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                loginBtn.Enabled = false;
                loginBtn.Text = "Error";
            }

            if (string.IsNullOrEmpty(loginTextBox.Text.Trim()) || string.IsNullOrEmpty(passwordTextBox.Text.Trim()))
            {
                MessageBox.Show("Fill all empty field", "Log in", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            loadData(loginTextBox.Text.Trim(), passwordTextBox.Text.Trim());

            if(intRow > 0)
            {
                MessageBox.Show("You was log in", "Log in", MessageBoxButtons.OK, MessageBoxIcon.Information);

                resetMe();

                MainBlock mainBlock = new MainBlock();
                mainBlock.Show();
                this.Hide();
            }
            else
            {
                attemptCount += 1;
                MessageBox.Show("Login or password is incorrect", "Log in", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }



        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            HelloPage helloPage = new HelloPage();
            helloPage.Show();
            this.Hide();
        }

        private void loginLabel_Click(object sender, EventArgs e)
        {

        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }
    }
}
