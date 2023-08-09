using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormConnectionMySQL
{
    public partial class WindowsFormConnectionMySQL : Form
    {
        private string connStr = ConfigurationManager
            .ConnectionStrings["MySQL.Connect.WindowsFormConnectDatabase"]
            .ConnectionString;
        private MySqlConnection mySqlConnection;
        private MySqlDataAdapter mySqlDataAdapter;

        public WindowsFormConnectionMySQL()
        {
            InitializeComponent();
            mySqlConnection = new MySqlConnection(connStr);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void getAllDataButton_Click(object sender, EventArgs e)
        {
            try
            {
                mySqlConnection.Open();

                string sql = "SELECT * FROM users;";
                MySqlCommand mySqlCmd = new MySqlCommand(sql, mySqlConnection);

                DataTable allDataTable = new DataTable();

                mySqlDataAdapter = new MySqlDataAdapter(mySqlCmd);

                mySqlDataAdapter.Fill(allDataTable);

                dataGridView1.DataSource = allDataTable;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error MySQL connection: " + ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            finally
            {
                if (mySqlConnection.State == ConnectionState.Open)
                {
                    mySqlConnection.Close();
                }
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                mySqlConnection.Open();
                
                string sql = "SELECT * FROM users WHERE name='" + searchTextBox.Text + "';";
                MySqlCommand mySqlCmd = new MySqlCommand(sql, mySqlConnection);

                DataTable searchDataTable = new DataTable();

                mySqlDataAdapter = new MySqlDataAdapter(mySqlCmd);

                mySqlDataAdapter.Fill(searchDataTable);

                dataGridView1.DataSource = searchDataTable;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error MySQL connection: " + ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            finally
            {
                if (mySqlConnection.State == ConnectionState.Open)
                {
                    mySqlConnection.Close();
                }
            }
        }
    }
}
