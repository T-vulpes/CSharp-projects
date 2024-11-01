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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Ace.OleDB.12.0; Data Source=prsnl_vt.accdb");

        private void prsn_show()
        {
            try
            {
                connect.Open();
                OleDbDataAdapter psnlist = new OleDbDataAdapter("SELECT ID AS[ID],name AS[Name],surname AS[Surname],gender AS[Gender],graduation AS[Graduation],birth AS[Birth],job AS[Job],place AS[Place],salary AS[Salary] from personnel Order By name ASC", connect);
                DataSet ds_memory= new DataSet();
                psnlist.Fill(ds_memory);
                dataGridView1.DataSource = ds_memory.Tables[0];
                connect.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connect.Close();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            prsn_show();
            this.Text = "User Actions";
            label19.Text = Form1.name + " " + Form1.surname;
            pictureBox1.Width = 150;
            pictureBox1.Height = 150;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;

            pictureBox2.Width = 150;
            pictureBox2.Height = 150;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;

            try
            {
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\personnelimg\\" + Form1.id + ".jpg");

            }
            catch (Exception)
            {
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\personnelimg\\noimg.jpg");
            }
            maskedTextBox1.Mask = "00000000000";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool usrcase = false;
            if (maskedTextBox1.Text.Length == 11)
            {
                connect.Open();
                OleDbCommand search = new OleDbCommand("SELECT * from personnel where ID='" + maskedTextBox1.Text + "'", connect);
                OleDbDataReader usrread = search.ExecuteReader();
                while (usrread.Read())
                {
                    usrcase = true;
                    try
                    {
                        pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\personnelimg\\" + usrread.GetValue(0) + ".jpg");
                    }
                    catch (Exception)
                    {
                        pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\personnelimg\\noimg.jpg");
                    }

                    label11.Text = usrread.GetValue(1).ToString();
                    label12.Text = usrread.GetValue(2).ToString();
                    if (usrread.GetValue(3).ToString() == "Female")
                        label13.Text = usrread.GetValue(3).ToString();
                    else
                        label13.Text = usrread.GetValue(3).ToString();

                    label14.Text = usrread.GetValue(4).ToString();
                    label18.Text = usrread.GetValue(5).ToString();
                    label17.Text = usrread.GetValue(6).ToString();
                    label16.Text = usrread.GetValue(7).ToString();
                    label15.Text = usrread.GetValue(8).ToString();


                    break;
                }
                if (usrcase == false)
                {
                    MessageBox.Show("The searched record was not found", "not successful", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                connect.Close();
            }
            else
            {
                MessageBox.Show("Please enter your 11 digit ID:", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
