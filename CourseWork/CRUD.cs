using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace CourseWork
{
    internal class CRUD
    {

        private static string getConnectionString()
        {

            string host = "Server=localhost;";
            string port = "Port=5432;";
            string db = "Database=library;";
            string user = "User Id=postgres;";
            string password = "Password=root;";

            string connectionString = string.Format("{0}{1}{2}{3}{4}", host, port, db, user, password);

            return connectionString;
        }

        public static NpgsqlConnection connection = new NpgsqlConnection(getConnectionString());
        public static NpgsqlCommand cmd = default(NpgsqlCommand);
        public static string sql = string.Empty;
        public static string userLogin = string.Empty;
        public static string userRole = string.Empty;

        public static DataTable PerformCRUD(NpgsqlCommand com)
        {
            NpgsqlDataAdapter adapter = default(NpgsqlDataAdapter);
            DataTable dt = new DataTable();

            try
            {

                adapter = new NpgsqlDataAdapter();
                adapter.SelectCommand = com;
                adapter.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message, "CRUD opreration was fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dt = null;
            }

            return dt;
        }

    }
}
