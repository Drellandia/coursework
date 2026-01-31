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
    public partial class Customer : Form
    {
        private string id = "";
        private int intRow = 0;

public Customer()
        {
            InitializeComponent();
            this.Text = "Customer, work user: " + CRUD.userLogin;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            MainBlock mainBlock = new MainBlock();
            mainBlock.Show();
            this.Hide();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addParameters(string str)
        {

            bool temp = false;

            if (endCooperationComboBox.SelectedItem.ToString() == "False")
            {
                temp = false;
            }
            else
            {
                temp = true;
            }

            CRUD.cmd.Parameters.Clear();

            if (str == "Update" && !string.IsNullOrEmpty(this.id))
            {
                CRUD.cmd.Parameters.AddWithValue("name", nameTextBox.Text.Trim().ToString());
                CRUD.cmd.Parameters.AddWithValue("surname", surnameTextBox.Text.Trim().ToString());
                CRUD.cmd.Parameters.AddWithValue("fathername", fathernameTextBox.Text.Trim().ToString());
                CRUD.cmd.Parameters.AddWithValue("address", addressTextBox.Text.Trim().ToString());
                CRUD.cmd.Parameters.AddWithValue("phoneNumber", phoneNumberTextBox.Text.Trim().ToString());
                CRUD.cmd.Parameters.AddWithValue("passport", Convert.ToInt32(passportTextBox.Text.Trim()));
                CRUD.cmd.Parameters.AddWithValue("endCooperation", temp);
                CRUD.cmd.Parameters.AddWithValue("extraditionID", Convert.ToInt32(extraditionIDTextBox.Text.Trim()));
                CRUD.cmd.Parameters.AddWithValue("id", this.id);
            }

            if (str == "Create")
            {
                CRUD.cmd.Parameters.AddWithValue("name", nameTextBox.Text.Trim().ToString());
                CRUD.cmd.Parameters.AddWithValue("surname", surnameTextBox.Text.Trim().ToString());
                CRUD.cmd.Parameters.AddWithValue("fathername", fathernameTextBox.Text.Trim().ToString());
                CRUD.cmd.Parameters.AddWithValue("address", addressTextBox.Text.Trim().ToString());
                CRUD.cmd.Parameters.AddWithValue("phoneNumber", phoneNumberTextBox.Text.Trim().ToString());
                CRUD.cmd.Parameters.AddWithValue("passport", Convert.ToInt32(passportTextBox.Text.Trim()));
                CRUD.cmd.Parameters.AddWithValue("endCooperation", temp);
                CRUD.cmd.Parameters.AddWithValue("extraditionID", Convert.ToInt32(extraditionIDTextBox.Text.Trim()));
            }

            if (str == "Delete" && !string.IsNullOrEmpty(this.id))
            {
                CRUD.cmd.Parameters.AddWithValue("id", this.id);
            }

        }
        private void loadData(string keyword)
        {
            CRUD.sql = "SELECT id, name, surname, fathername, address, phonenumber, passport, endcooperation, extradition_id FROM customer WHERE name LIKE @keyword::varchar OR surname LIKE @keyword::varchar OR fathername LIKE @keyword::varchar OR address LIKE @keyword::varchar OR phonenumber LIKE @keyword::varchar OR passport::text LIKE @keyword::varchar OR endcooperation::text LIKE @keyword::varchar OR extradition_id::text LIKE @keyword::varchar";


            string strKeyword = string.Format("%{0}%", keyword);

            CRUD.cmd = new NpgsqlCommand(CRUD.sql, CRUD.connection);
            CRUD.cmd.Parameters.Clear();
            CRUD.cmd.Parameters.AddWithValue("keyword", strKeyword);

            DataTable dt = CRUD.PerformCRUD(CRUD.cmd);

            if (dt.Rows.Count > 0)
            {
                intRow = Convert.ToInt32(dt.Rows.Count.ToString());
            }
            else
            {
                intRow = 0;
            }

            DataGridView dgv1 = dataGridView1;

            dgv1.MultiSelect = false;
            dgv1.AutoGenerateColumns = true;
            dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv1.DataSource = dt;

            dgv1.Columns[0].HeaderText = "ID";
            dgv1.Columns[1].HeaderText = "Name";
            dgv1.Columns[2].HeaderText = "Suraname";
            dgv1.Columns[3].HeaderText = "Fathername";
            dgv1.Columns[4].HeaderText = "Address";
            dgv1.Columns[5].HeaderText = "Phone number";
            dgv1.Columns[6].HeaderText = "Passport";
            dgv1.Columns[7].HeaderText = "End cooperation";
            dgv1.Columns[8].HeaderText = "Extradition ID";

        }

        private void execute(string mySQL, string param)
        {
            CRUD.cmd = new NpgsqlCommand(mySQL, CRUD.connection);
            addParameters(param);
            CRUD.PerformCRUD(CRUD.cmd);
        }

        private void resetMe()
        {
            this.id = string.Empty;

            surnameTextBox.Text = "";
            nameTextBox.Text = "";
            extraditionIDTextBox.Text = "";
            addressTextBox.Text = "";
            phoneNumberTextBox.Text = "";
            passportTextBox.Text = "";
            fathernameTextBox.Text = "";

            if (endCooperationComboBox.Items.Count > 0)
            {
                endCooperationComboBox.SelectedIndex = 0;
            }

            updateBtn.Text = "Update";
            deleteBtn.Text = "Delete";

            searchTextBox.Clear();

            if (searchTextBox.CanSelect)
            {
                searchTextBox.Select();
            }

        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchTextBox.Text.Trim()))
            {
                loadData("");
            }
            else
            {
                loadData(searchTextBox.Text.Trim());
            }

            resetMe();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameTextBox.Text.Trim()) || string.IsNullOrEmpty(surnameTextBox.Text.Trim()) || string.IsNullOrEmpty(fathernameTextBox.Text.Trim()) || string.IsNullOrEmpty(addressTextBox.Text.Trim()) || string.IsNullOrEmpty(phoneNumberTextBox.Text.Trim()) || string.IsNullOrEmpty(passportTextBox.Text.Trim()) || string.IsNullOrEmpty(extraditionIDTextBox.Text.Trim()))
            {
                MessageBox.Show("Fill all empty field or to correct incorrect value", "Create data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            CRUD.sql = "INSERT INTO customer(name, surname, fathername, address, phonenumber, passport, endcooperation, extradition_id) VALUES(@name, @surname, @fathername, @address, @phoneNumber, @passport, @endCooperation, @extraditionID)";

            execute(CRUD.sql, "Create");

            MessageBox.Show("New object in table correspondents was create!", "Create data", MessageBoxButtons.OK, MessageBoxIcon.Information);

            loadData("");

            resetMe();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                return;
            }

            if (string.IsNullOrEmpty(this.id))
            {
                MessageBox.Show("Select any item for update", "Update data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(nameTextBox.Text.Trim()) || string.IsNullOrEmpty(surnameTextBox.Text.Trim()) || string.IsNullOrEmpty(fathernameTextBox.Text.Trim()) || string.IsNullOrEmpty(addressTextBox.Text.Trim()) || string.IsNullOrEmpty(phoneNumberTextBox.Text.Trim()) || string.IsNullOrEmpty(passportTextBox.Text.Trim()) || string.IsNullOrEmpty(extraditionIDTextBox.Text.Trim()))
            {
                MessageBox.Show("Plese fill empty field or correct incorrect value", "Update data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            CRUD.sql = "UPDATE customer SET name = @name, surname = @surname, fathername = @fathername, address = @address, phonenumber = @phoneNumber, passport = @passport, endcooperation = @endCooperation, extradition_id = @extraditionID WHERE id = @id::integer";

            execute(CRUD.sql, "Update");

            MessageBox.Show("Object in table correspondents was update!", "Update data", MessageBoxButtons.OK, MessageBoxIcon.Information);

            loadData("");

            resetMe();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                return;
            }

            if (string.IsNullOrEmpty(this.id))
            {
                MessageBox.Show("Select any item for delete", "Delete data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show("Are you sure? Delete this item?", "Delete Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                CRUD.sql = "DELETE from customer WHERE id = @id::integer";

                execute(CRUD.sql, "Delete");

                resetMe();

                MessageBox.Show("Object in table correspondents was delete!", "Delete data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                loadData("");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridView dgv1 = dataGridView1;

                this.id = Convert.ToString(dgv1.CurrentRow.Cells[0].Value);
                updateBtn.Text = "Update item id: " + this.id;
                deleteBtn.Text = "Delete item id: " + this.id;
            }
        }

        private void Correspondents_Load(object sender, EventArgs e)
        {
            loadData("");
            if(CRUD.userRole == "user")
            {
                createBtn.Visible = false;
                updateBtn.Visible = false;
                deleteBtn.Visible = false;
            }
        }

        private void searchLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
