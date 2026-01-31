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
using System.IO;

namespace CourseWork
{
    public partial class CustomerReturn : Form
    {
        private int intRow = 0;
        public CustomerReturn()
        {
            InitializeComponent();
            this.Text = "Reportage by info, work user: " + CRUD.userLogin;
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

        private void ReportageByInfo_Load(object sender, EventArgs e)
        {
            loadData("");
        }

        private void loadData(string keyword)
        {
            CRUD.sql = "select CONCAT(customer.name, ' ', customer.surname, ' ', customer.fathername) AS full_name, extradition.returningterm, book.name from extradition join customer on extradition.id = customer.extradition_id join book on extradition.id = book.extradition_id;";


            CRUD.cmd = new NpgsqlCommand(CRUD.sql, CRUD.connection);

            DataTable dt = CRUD.PerformCRUD(CRUD.cmd);

            DataGridView dgv1 = dataGridView1;


            dgv1.MultiSelect = false;
            dgv1.AutoGenerateColumns = true;
            dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv1.DataSource = dt;

            dgv1.Columns[0].HeaderText = "Full name";
            dgv1.Columns[1].HeaderText = "Returning term";
            dgv1.Columns[2].HeaderText = "Book name";

        }

        private void exportDataBtn_Click_1(object sender, EventArgs e)
        {
            CRUD.sql = "select CONCAT(customer.name, ' ', customer.surname, ' ', customer.fathername) AS full_name, extradition.returningterm, book.name from extradition join customer on extradition.id = customer.extradition_id join book on extradition.id = book.extradition_id;";

            string path = "C:\\Users\\Windows\\Desktop\\курсач!\\Program\\Data\\data.txt";

            CRUD.cmd = new NpgsqlCommand(CRUD.sql, CRUD.connection);

            DataTable dt = CRUD.PerformCRUD(CRUD.cmd);

            DataGridView dgv1 = dataGridView1;


            dgv1.DataSource = dt;

            File.WriteAllText(path, string.Empty);


            try
            {
                foreach (DataGridViewRow row in dgv1.Rows)
                {
                    int count = 0;

                    if (count == 3)
                    {
                        count = 0;
                    }
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        object value = cell.Value;
                        if (value != null)
                        {
                            File.AppendAllText(path, dgv1.Columns[count].HeaderText + ": " + value.ToString() + "\n");
                        }
                        count++;
                    }
                }

                MessageBox.Show("Data was export", "Export data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Export data error" + ex.Message, "Export data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
