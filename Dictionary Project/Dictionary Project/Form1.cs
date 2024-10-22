using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Dictionary_Project
{
    public partial class Form1 : Form
    {
        // Declare the database connection
        OleDbConnection connection;

        public Form1()
        {
            InitializeComponent();

            // Define the connection string for the database
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\vt_dict.accdb";

            // Check if the database file exists
            if (!System.IO.File.Exists(Application.StartupPath + "\\vt_dict.accdb"))
            {
                MessageBox.Show("Database not found: " + Application.StartupPath + "\\vt_dict.accdb", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                connection = new OleDbConnection(connectionString);
            }
        }

        // Add new word to the database
        private void button1_Click(object sender, EventArgs e)
        {
            if (connection == null)
            {
                MessageBox.Show("Connection could not be initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Open the connection
                connection.Open();

                // Use parameterized query to prevent SQL injection
                OleDbCommand add = new OleDbCommand("INSERT INTO engtur (English, Turkish) VALUES (@English, @Turkish)", connection);
                add.Parameters.AddWithValue("@English", textBox1.Text);
                add.Parameters.AddWithValue("@Turkish", textBox2.Text);

                // Execute the query
                add.ExecuteNonQuery();

                // Notify the user
                MessageBox.Show("Word added to the database");

                // Clear the text fields
                textBox1.Clear();
                textBox2.Clear();
            }
            catch (Exception ex)
            {
                // Show error message
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Close the connection if it's open
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        // Update the word in the database
        private void button2_Click(object sender, EventArgs e)
        {
            if (connection == null)
            {
                MessageBox.Show("Connection could not be initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Open the connection
                connection.Open();

                // Use parameterized query for the update
                OleDbCommand update = new OleDbCommand("UPDATE engtur SET Turkish = @Turkish WHERE English = @English", connection);
                update.Parameters.AddWithValue("@Turkish", textBox2.Text);
                update.Parameters.AddWithValue("@English", textBox1.Text);

                // Execute the update query
                int rowsAffected = update.ExecuteNonQuery();

                // Notify the user if the update was successful
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Word updated in the database");
                }
                else
                {
                    MessageBox.Show("No word found to update");
                }

                // Clear the text fields
                textBox1.Clear();
                textBox2.Clear();
            }
            catch (Exception ex)
            {
                // Show error message
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Close the connection if it's open
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
                // Open the connection
                connection.Open();

                // Use parameterized query for the delete operation
                OleDbCommand delete = new OleDbCommand("DELETE FROM engtur WHERE English = @English", connection);
                delete.Parameters.AddWithValue("@English", textBox1.Text);

                // Execute the delete query
                int rowsAffected = delete.ExecuteNonQuery();

                // Notify the user if the deletion was successful
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Word deleted from the database");
                }
                else
                {
                    MessageBox.Show("No word found to delete");
                }

                // Clear the text fields
                textBox1.Clear();
                textBox2.Clear();
            }
            catch (Exception ex)
            {
                // Show error message
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Close the connection if it's open
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

                // Use parameterized query for safety
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

                // Query to load all words
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
