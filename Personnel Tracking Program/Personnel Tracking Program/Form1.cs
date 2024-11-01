using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace Personnel_Tracking_Program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Ace.OleDB.12.0; Data Source=prsnl_vt.accdb");
        public static string id, name, surname, auth;

        private void button1_Click(object sender, EventArgs e)
        {
            if (right != 0)
            {
                connect.Open();
                OleDbCommand selectadd = new OleDbCommand("select * from staff", connect);
                OleDbDataReader recordreading = selectadd.ExecuteReader();
                while (recordreading.Read())
                {
                    if (radioButton1.Checked == true)
                    {
                        if (recordreading["username"].ToString() == textBox1.Text && recordreading["password"].ToString() == textBox2.Text && recordreading["authority"].ToString() == "admin"){
                            status = true;
                            id = recordreading.GetValue(0).ToString();
                            name= recordreading.GetValue(1).ToString();
                            surname = recordreading.GetValue(2).ToString();
                            auth = recordreading.GetValue(3).ToString();
                            this.Hide();
                            Form2 frm2 = new Form2();
                            frm2.Show();
                            break;
                        }
                    }

                    if (radioButton2.Checked == true)
                    {
                        if (recordreading["username"].ToString() == textBox1.Text && recordreading["password"].ToString() == textBox2.Text && recordreading["authority"].ToString() == "user")
                        {
                            status = true;
                            id = recordreading.GetValue(0).ToString();
                            name = recordreading.GetValue(1).ToString();
                            surname = recordreading.GetValue(2).ToString();
                            auth = recordreading.GetValue(3).ToString();
                            this.Hide();
                            Form3 frm3 = new Form3();
                            frm3.Show();
                            break;
                        }
                    }
                }

                if (status == false)
                {
                    right--;
                }
                connect.Close();
            }
            label5.Text = Convert.ToString(right);
            if (right == 0)
            {
                button1.Enabled = false;
                MessageBox.Show("No more right to enter", "Personnel tracking", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        int right = 3;
        bool status = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "User Login...";
            this.AcceptButton= button1;
            this.CancelButton = button2;
            label5.Text = Convert.ToString(right);
            radioButton1.Checked = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

        }
    }
}
