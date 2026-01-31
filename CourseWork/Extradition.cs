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
    public partial class Extradition : Form
    {
        private string id = "";
        private int intRow = 0;
        public Extradition()
        {
            InitializeComponent();
            resetMe();
            this.Text = "Extradition, work user: " + CRUD.userLogin;
        }


        private void resetMe()
        {
            this.id = string.Empty;

            returningDateTextBox.Text = "";
            extraditionDateTextBox.Text = "";
            returningTermTextBox.Text = "";

            updateBtn.Text = "Update";
            deleteBtn.Text = "Delete";

            searchTextBox.Clear();

            if (searchTextBox.CanSelect)
            {
                searchTextBox.Select();
            }

        }

        private void loadData(string keyword)
        {
            CRUD.sql = "SELECT id, extraditiondate, returningdate, returningterm FROM extradition WHERE extraditiondate::text LIKE @keyword::varchar OR returningdate::text LIKE @keyword::varchar OR returningterm LIKE @keyword::varchar";


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
            dgv1.Columns[1].HeaderText = "Extradition date";
            dgv1.Columns[2].HeaderText = "Returning date";
            dgv1.Columns[3].HeaderText = "Returning term";

        }

        private void execute(string mySQL, string param)
        {
            CRUD.cmd = new NpgsqlCommand(mySQL, CRUD.connection);
            addParameters(param);
            CRUD.PerformCRUD(CRUD.cmd);
        }

        private void addParameters(string str)
        {

            CultureInfo provider = CultureInfo.InvariantCulture;

            CRUD.cmd.Parameters.Clear();

            if (str == "Update" && !string.IsNullOrEmpty(this.id))
            {
                try
                {
                    CRUD.cmd.Parameters.AddWithValue("extraditionDate", DateTime.ParseExact(extraditionDateTextBox.Text.Trim(), "dd/MM/yyyy", provider));
                }
                catch (Exception ex)
                {
                    CRUD.cmd.Parameters.AddWithValue("extraditionDate", DateTime.ParseExact("01/01/2000", "dd/MM/yyyy", provider));
                    MessageBox.Show("Date format incorect, must be 'dd/MM/yyyy' we add to db patern data like '01/01/2000'", "Exception error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                try
                {
                    CRUD.cmd.Parameters.AddWithValue("returningDate", DateTime.ParseExact(returningDateTextBox.Text.Trim(), "dd/MM/yyyy", provider));
                }
                catch (Exception ex)
                {
                    CRUD.cmd.Parameters.AddWithValue("returningDate", DateTime.ParseExact("01/01/2000", "dd/MM/yyyy", provider));
                    MessageBox.Show("Date format incorect, must be 'dd/MM/yyyy' we add to db patern data like '01/01/2000'", "Exception error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                CRUD.cmd.Parameters.AddWithValue("returningTerm", returningTermTextBox.Text.Trim().ToString());
                CRUD.cmd.Parameters.AddWithValue("id", this.id);
            }

            if (str == "Create")
            {
                try
                {
                    CRUD.cmd.Parameters.AddWithValue("extraditionDate", DateTime.ParseExact(extraditionDateTextBox.Text.Trim(), "dd/MM/yyyy", provider));
                }
                catch (Exception ex)
                {
                    CRUD.cmd.Parameters.AddWithValue("extraditionDate", DateTime.ParseExact("01/01/2000", "dd/MM/yyyy", provider));
                    MessageBox.Show("Date format incorect, must be 'dd/MM/yyyy' we add to db patern data like '01/01/2000'", "Exception error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                try
                {
                    CRUD.cmd.Parameters.AddWithValue("returningDate", DateTime.ParseExact(returningDateTextBox.Text.Trim(), "dd/MM/yyyy", provider));
                }
                catch (Exception ex)
                {
                    CRUD.cmd.Parameters.AddWithValue("returningDate", DateTime.ParseExact("01/01/2000", "dd/MM/yyyy", provider));
                    MessageBox.Show("Date format incorect, must be 'dd/MM/yyyy' we add to db patern data like '01/01/2000'", "Exception error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                CRUD.cmd.Parameters.AddWithValue("returningTerm", returningTermTextBox.Text.Trim().ToString());
            }

            if (str == "Delete" && !string.IsNullOrEmpty(this.id))
            {
                CRUD.cmd.Parameters.AddWithValue("id", this.id);
            }

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

        private void Events_Load(object sender, EventArgs e)
        {
            loadData("");
            if (CRUD.userRole == "user")
            {
                createBtn.Visible = false;
                updateBtn.Visible = false;
                deleteBtn.Visible = false;
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
            if (string.IsNullOrEmpty(returningDateTextBox.Text.Trim())
                || string.IsNullOrEmpty(extraditionDateTextBox.Text.Trim())
                || string.IsNullOrEmpty(returningTermTextBox.Text.Trim()))
            {
                MessageBox.Show("Fill all empty field or to correct incorrect value", "Create data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            CRUD.sql = "INSERT INTO extradition(extraditiondate, returningdate, returningterm) VALUES(@extraditionDate, @returningDate, @returningTerm)";

            execute(CRUD.sql, "Create");

            MessageBox.Show("New object in table events was create!", "Create data", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

            if (string.IsNullOrEmpty(returningDateTextBox.Text.Trim())
                || string.IsNullOrEmpty(extraditionDateTextBox.Text.Trim())
                || string.IsNullOrEmpty(returningTermTextBox.Text.Trim()))
            {
                MessageBox.Show("Plese fill empty field or correct incorrect value", "Update data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            CRUD.sql = "UPDATE extradition SET extraditiondate = @extraditionDate, returningdate = @returningDate, returningterm = @returningTerm WHERE id = @id::integer";

            execute(CRUD.sql, "Update");

            MessageBox.Show("Object in table events was update!", "Update data", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                CRUD.sql = "DELETE from extradition WHERE id = @id::integer";

                execute(CRUD.sql, "Delete");

                resetMe();

                MessageBox.Show("Object in table events was delete!", "Delete data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                loadData("");
            }
        }
    }
}
