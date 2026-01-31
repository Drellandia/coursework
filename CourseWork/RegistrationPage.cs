using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class RegistrationPage : Form
    {
        private int check = 0;
        public RegistrationPage()
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
            repeatPasswordTextBox.Text = "";

        }

        private void execute(string mySQL, string param)
        {
            CRUD.cmd = new NpgsqlCommand(mySQL, CRUD.connection);
            addParameters(param);
            CRUD.PerformCRUD(CRUD.cmd);
        }

        private void addParameters(string str)
        {

            CRUD.cmd.Parameters.Clear();

            if (str == "Registrate")
            {
                CRUD.cmd.Parameters.AddWithValue("login", loginTextBox.Text.Trim().ToString());
                CRUD.cmd.Parameters.AddWithValue("password", passwordTextBox.Text.Trim().ToString());
                CRUD.cmd.Parameters.AddWithValue("role", "user");
            }

        }

        public static int SumOddAscii(string input)
        {
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (i % 2 != 0)
                {
                    sum += (int)input[i];
                }
            }
            if (sum == 50)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        private void registrateBtn_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(loginTextBox.Text.Trim()) || string.IsNullOrEmpty(passwordTextBox.Text.Trim()) || string.IsNullOrEmpty(repeatPasswordTextBox.Text.Trim()))
            {
                MessageBox.Show("Fill all empty field", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (passwordTextBox.Text.Trim() != repeatPasswordTextBox.Text.Trim())
            {
                MessageBox.Show("Passwords was not the same", "Redistration", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.check = SumOddAscii(passwordTextBox.Text.Trim());

            if(this.check == -1)
            {
                Console.WriteLine(this.check);
                MessageBox.Show("The sum of the odd symbol ASCI codes must be 50", "Redistration", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Console.WriteLine(this.check);

            CRUD.sql = "INSERT INTO users(login, password, role) VALUES(@login, @password, @role)";

            execute(CRUD.sql, "Registrate");

            CRUD.userLogin = loginTextBox.Text.Trim().ToString();
            CRUD.userRole = "user";

            MessageBox.Show("You was registrate", "Redistration", MessageBoxButtons.OK, MessageBoxIcon.Information);

            resetMe();

            MainBlock mainBlock = new MainBlock();
            mainBlock.Show();
            this.Hide();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            HelloPage helloPage = new HelloPage();
            helloPage.Show();
            this.Hide();
        }
    }
}
