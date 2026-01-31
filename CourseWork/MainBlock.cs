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
    public partial class MainBlock : Form
    {
        public MainBlock()
        {
            InitializeComponent();
            this.Text = "Main block, work user: " + CRUD.userLogin;
        }

        private void logOutBtn_Click(object sender, EventArgs e)
        {
            HelloPage helloPage = new HelloPage();
            helloPage.Show();
            this.Hide();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bookEnterBtn_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            book.Show();
            this.Hide();
        }

        private void extraditionEnterBtn_Click(object sender, EventArgs e)
        {
            Extradition extradition = new Extradition();
            extradition.Show();
            this.Hide();
        }

        private void customerEnterBtn_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.Show();
            this.Hide();
        }

        private void customerReturningBtn_Click(object sender, EventArgs e)
        {
            CustomerReturn customerReturn = new CustomerReturn();
            customerReturn.Show();
            this.Hide();
        }
    }
}
