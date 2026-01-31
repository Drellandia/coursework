using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Npgsql;

namespace CourseWork
{
    public partial class Book : Form
    {

        private string id = "";
        private int intRow = 0;
        public Book()
        {
            InitializeComponent();
            resetMe();
            this.Text = "Book, work user: " + CRUD.userLogin;
        }

        private void resetMe()
        {
            this.id = string.Empty;

            nameTextBox.Text = "";
            authorTextBox.Text = "";
            publishingHouseTextBox.Text = "";
            identifierTextBox.Text = "";
            extraditionIDTextBox.Text = "";

            if (themeComboBox.Items.Count > 0 )
            {
                themeComboBox.SelectedIndex = 0;
            }

            updateBtn.Text = "Update";
            deleteBtn.Text = "Delete";

            searchTextBox.Clear();

            if (searchTextBox.CanSelect)
            {
                searchTextBox.Select();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            loadData("");
            if (CRUD.userRole == "user")
            {
                createBtn.Visible = false;
                updateBtn.Visible = false;
                deleteBtn.Visible = false;
            }

        }

        private void loadData(string keyword)
        {
            CRUD.sql = "SELECT id, name, author, publishinghouse, theme, identifier, extradition_id FROM book WHERE name LIKE @keyword::varchar OR author LIKE @keyword::varchar OR publishinghouse LIKE @keyword::varchar OR theme LIKE @keyword::varchar OR identifier::text LIKE @keyword::varchar OR extradition_id::text LIKE @keyword::varchar";


            string strKeyword = string.Format("%{0}%", keyword);

            CRUD.cmd = new NpgsqlCommand(CRUD.sql, CRUD.connection);
            CRUD.cmd.Parameters.Clear();
            CRUD.cmd.Parameters.AddWithValue("keyword", strKeyword);

            DataTable dt = CRUD.PerformCRUD(CRUD.cmd);

            if(dt.Rows.Count > 0 )
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
            dgv1.Columns[2].HeaderText = "Author";
            dgv1.Columns[3].HeaderText = "Publishing house";
            dgv1.Columns[4].HeaderText = "Theme";
            dgv1.Columns[5].HeaderText = "Identifier";
            dgv1.Columns[6].HeaderText = "Extradition ID";

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

            if(str == "Update" && !string.IsNullOrEmpty(this.id)) 
            {
                CRUD.cmd.Parameters.AddWithValue("name", nameTextBox.Text.Trim().ToString());
                CRUD.cmd.Parameters.AddWithValue("author", authorTextBox.Text.Trim().ToString());
                CRUD.cmd.Parameters.AddWithValue("publishingHouse", publishingHouseTextBox.Text.Trim().ToString());
                CRUD.cmd.Parameters.AddWithValue("theme", themeComboBox.SelectedItem.ToString());
                CRUD.cmd.Parameters.AddWithValue("identifier", Convert.ToInt32(identifierTextBox.Text.Trim()));
                CRUD.cmd.Parameters.AddWithValue("extraditionID", Convert.ToInt32(extraditionIDTextBox.Text.Trim()));
                CRUD.cmd.Parameters.AddWithValue("id", this.id);
            }

            if (str == "Create")
            {
                CRUD.cmd.Parameters.AddWithValue("name", nameTextBox.Text.Trim().ToString());
                CRUD.cmd.Parameters.AddWithValue("author", authorTextBox.Text.Trim().ToString());
                CRUD.cmd.Parameters.AddWithValue("publishingHouse", publishingHouseTextBox.Text.Trim().ToString());
                CRUD.cmd.Parameters.AddWithValue("theme", themeComboBox.SelectedItem.ToString());
                CRUD.cmd.Parameters.AddWithValue("identifier", Convert.ToInt32(identifierTextBox.Text.Trim()));
                CRUD.cmd.Parameters.AddWithValue("extraditionID", Convert.ToInt32(extraditionIDTextBox.Text.Trim()));
            }

            if (str == "Delete" && !string.IsNullOrEmpty(this.id))
            {
                CRUD.cmd.Parameters.AddWithValue("id", this.id);
            }

        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(nameTextBox.Text.Trim()) 
                || string.IsNullOrEmpty(authorTextBox.Text.Trim()) 
                || string.IsNullOrEmpty(publishingHouseTextBox.Text.Trim())
                || string.IsNullOrEmpty(identifierTextBox.Text.Trim())
                || string.IsNullOrEmpty(extraditionIDTextBox.Text.Trim()))
            {
                MessageBox.Show("Fill all empty field or to correct incorrect value", "Create data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            CRUD.sql = "INSERT INTO book(name, author, publishinghouse, theme, identifier, extradition_id) VALUES(@name, @author, @publishingHouse, @theme, @identifier, @extraditionID)";

            execute(CRUD.sql, "Create");

            MessageBox.Show("New object in table reportages was create!", "Create data", MessageBoxButtons.OK, MessageBoxIcon.Information);

            loadData("");

            resetMe();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                DataGridView dgv1 = dataGridView1;

                this.id = Convert.ToString(dgv1.CurrentRow.Cells[0].Value);
                updateBtn.Text = "Update item id: " + this.id;
                deleteBtn.Text = "Delete item id: " + this.id;
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count == 0) 
            {
                return;
            }

            if(string.IsNullOrEmpty(this.id))
            {
                MessageBox.Show("Select any item for update", "Update data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(nameTextBox.Text.Trim())
                || string.IsNullOrEmpty(authorTextBox.Text.Trim())
                || string.IsNullOrEmpty(publishingHouseTextBox.Text.Trim())
                || string.IsNullOrEmpty(identifierTextBox.Text.Trim())
                || string.IsNullOrEmpty(extraditionIDTextBox.Text.Trim()))
            {
                MessageBox.Show("Plese fill empty field or correct incorrect value", "Update data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

                CRUD.sql = "UPDATE book SET name = @name, author = @author, publishinghouse = @publishingHouse, theme = @theme, identifier = @identifier, extradition_id = @extraditionID WHERE id = @id::integer";

                execute(CRUD.sql, "Update");

                MessageBox.Show("Object in table reportages was update!", "Update data", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

            if(MessageBox.Show("Are you sure? Delete this item?", "Delete Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                CRUD.sql = "DELETE from book WHERE id = @id::integer";

                execute(CRUD.sql, "Delete");

                resetMe();

                MessageBox.Show("Object in table reportages was delete!", "Delete data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                loadData("");
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(searchTextBox.Text.Trim())) 
            {
                loadData("");
            }
            else
            {
                loadData(searchTextBox.Text.Trim());
            }

            resetMe();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            MainBlock mainBlock = new MainBlock();
            mainBlock.Show();
            this.Hide();
        }
    }
}
