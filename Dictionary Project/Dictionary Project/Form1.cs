using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Dictionary_Project
{
    public partial class Form1 : Form
    {
        OleDbConnection connection;

        public Form1()
        {
            InitializeComponent();
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\vt_dict.accdb";
            if (!System.IO.File.Exists(Application.StartupPath + "\\vt_dict.accdb"))
            {
                MessageBox.Show("Database not found: " + Application.StartupPath + "\\vt_dict.accdb", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                connection = new OleDbConnection(connectionString);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (connection == null)
            {
                MessageBox.Show("Connection could not be initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connection.Open();
                OleDbCommand add = new OleDbCommand("INSERT INTO engtur (English, Turkish) VALUES (@English, @Turkish)", connection);
                add.Parameters.AddWithValue("@English", textBox1.Text);
                add.Parameters.AddWithValue("@Turkish", textBox2.Text);
                add.ExecuteNonQuery();
                MessageBox.Show("Word added to the database");
                textBox1.Clear();
                textBox2.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (connection == null)
            {
                MessageBox.Show("Connection could not be initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                connection.Open();

                OleDbCommand update = new OleDbCommand("UPDATE engtur SET Turkish = @Turkish WHERE English = @English", connection);
                update.Parameters.AddWithValue("@Turkish", textBox2.Text);
                update.Parameters.AddWithValue("@English", textBox1.Text);

                int rowsAffected = update.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Word updated in the database");
                }
                else
                {
                    MessageBox.Show("No word found to update");
                }

                textBox1.Clear();
                textBox2.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (connection == null)
            {
                MessageBox.Show("Connection could not be initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connection.Open();

                OleDbCommand delete = new OleDbCommand("DELETE FROM engtur WHERE English = @English", connection);
                delete.Parameters.AddWithValue("@English", textBox1.Text);

                int rowsAffected = delete.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Word deleted from the database");
                }
                else
                {
                    MessageBox.Show("No word found to delete");
                }

                textBox1.Clear();
                textBox2.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                connection.Open();
                OleDbCommand searchcm = new OleDbCommand("SELECT English, Turkish FROM engtur WHERE English LIKE @English", connection);
                searchcm.Parameters.AddWithValue("@English", textBox1.Text + "%");

                OleDbDataReader read = searchcm.ExecuteReader();
                while (read.Read())
                {
                    listBox1.Items.Add(read["English"].ToString() + " - " + read["Turkish"].ToString());
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                connection.Open();
                OleDbCommand loadAll = new OleDbCommand("SELECT English, Turkish FROM engtur", connection);
                OleDbDataReader read = loadAll.ExecuteReader();

                while (read.Read())
                {
                    listBox1.Items.Add(read["English"].ToString() + " - " + read["Turkish"].ToString());
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

    }
}
