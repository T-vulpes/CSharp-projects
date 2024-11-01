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
using System.Text.RegularExpressions;
using System.IO;
namespace Personnel_Tracking_Program
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Ace.OleDB.12.0; Data Source=prsnl_vt.accdb");

        private void users_show()
        {
            try
            {
                connect.Open();
                OleDbDataAdapter list = new OleDbDataAdapter("SELECT ID AS[ID],name AS[Name],surname AS[Surname],authority AS[Authority],username AS[Username],password AS[Password] from staff Order By name ASC", connect);
                DataSet ds_memory = new DataSet();
                list.Fill(ds_memory);
                dataGridView1.DataSource = ds_memory.Tables[0];
                connect.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connect.Close();
            }
        }

        private void persnl_show()
        {
            try
            {
                connect.Open();
                OleDbDataAdapter psnlist = new OleDbDataAdapter("SELECT ID AS[ID],name AS[Name],surname AS[Surname],gender AS[Gender],graduation AS[Graduation],birth AS[Birth],job AS[Job],place AS[Place],salary AS[Salary] from personnel Order By name ASC", connect);
                DataSet ds_memory2 = new DataSet();
                psnlist.Fill(ds_memory2);
                dataGridView2.DataSource = ds_memory2.Tables[0];
                connect.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connect.Close();
            }
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.Height = 150;
            pictureBox1.Width = 150;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            try
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\img\\" + Form1.id + ".png");
            }
            catch (Exception)
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\img\\noimg.jpg");
            }

            this.Text = "Admin Operations";
            label10.Text = Form1.name + " " + Form1.surname;
            textBox1.MaxLength = 11;
            textBox4.MaxLength = 8;
            toolTip1.SetToolTip(this.textBox1, "ID must be 11 characters");
            radioButton1.Checked = true;
            textBox2.CharacterCasing = CharacterCasing.Upper;
            textBox3.CharacterCasing = CharacterCasing.Upper;
            textBox5.MaxLength = 10;
            textBox6.MaxLength = 10;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            textBox9.MaxLength = 11;

            users_show();
            //------
            pictureBox2.Height = 100;
            pictureBox2.Width = 100;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;

            DateTime time = DateTime.Now;
            int year = int.Parse(time.ToString("yyyy"));
            int month = int.Parse(time.ToString("MM"));
            int day = int.Parse(time.ToString("dd"));
            dateTimePicker1.MinDate = new DateTime(1960, 1, 1);
            dateTimePicker1.MaxDate = new DateTime(year - 18, month, day);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            radioButton3.Checked = true;

            //---
            persnl_show();


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSurrogate(e.KeyChar) == true)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSurrogate(e.KeyChar) == true)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length != 8)
                errorProvider1.SetError(textBox4, "Username must be 8 characters");
            else
                errorProvider1.Clear();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsDigit(e.KeyChar) == true)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        int passsecurity = 0;
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string passlevl = "";
            int lowercase = 0;
            int uppercase = 0;
            int digitscore = 0;
            int symbolscore = 0;
            string passw = textBox5.Text;
            string crcpasww = passw;
            crcpasww = crcpasww.Replace("İ", "i");
            crcpasww = crcpasww.Replace("Ç", "C");
            crcpasww = crcpasww.Replace("ç", "c");
            crcpasww = crcpasww.Replace("ş", "s");
            crcpasww = crcpasww.Replace("Ş", "S");
            crcpasww = crcpasww.Replace("Ğ", "G");
            crcpasww = crcpasww.Replace("ğ", "g");
            crcpasww = crcpasww.Replace("ü", "u");
            crcpasww = crcpasww.Replace("Ü", "U");
            crcpasww = crcpasww.Replace("ö", "o");
            crcpasww = crcpasww.Replace("Ö", "O");

            if (passw != crcpasww)
            {
                passw = crcpasww;
                textBox5.Text = passw;
            }
            int number_lowercasech = passw.Length - Regex.Replace(passw, "[a-z]", "").Length;
            lowercase = Math.Min(2, number_lowercasech) * 10;
            int number_uppercasech = passw.Length - Regex.Replace(passw, "[A-Z]", "").Length;
            uppercase = Math.Min(2, number_uppercasech) * 10;

            int number_digits = passw.Length - Regex.Replace(passw, "[0-9]", "").Length;
            digitscore = Math.Min(2, number_digits) * 10;

            int number_symbol = passw.Length - number_lowercasech - number_uppercasech - number_digits;
            symbolscore = Math.Min(2, number_symbol) * 10;

            passsecurity = lowercase + uppercase + digitscore + symbolscore;
            if (passw.Length == 9)
                passsecurity += 10;
            else if (passw.Length == 10)
                passsecurity += 20;

            if (lowercase == 0 || uppercase == 0 || digitscore == 0 || symbolscore == 0)
            {
                label20.Text = "Error! It is mandatory to use at least one capital letter, lower case letter, number and symbol.";
            }
            if (lowercase != 0 || uppercase != 0 || digitscore != 0 || symbolscore != 0)
            {
                label20.Text = "";
            }
            if (passsecurity < 70)
            {
                passlevl = "password is not acceptable";
            }
            else if (passsecurity == 70 || passsecurity == 80)
                passlevl = " strong password";
            else if (passsecurity == 90 || passsecurity == 100)
                passlevl = " very strong password";

            label21.Text = "%" + Convert.ToString(passsecurity);
            label22.Text = passlevl;
            progressBar1.Value = passsecurity;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text != textBox6.Text)
                errorProvider1.SetError(textBox6, "Password Does Not Match");
            else
                errorProvider1.Clear();
        }
        private void toppage1_clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void toppage2_clear()
        {
            pictureBox2.Image = null;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            textBox10.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox7.Clear();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string auth = "";
            bool actcntl = false;

            connect.Open();
            OleDbCommand selects = new OleDbCommand("select * from staff where ID='" + textBox1.Text + "'", connect);
            OleDbDataReader read = selects.ExecuteReader();
            while (read.Read())
            {
                actcntl = true;
                break;
            }
            connect.Close();

            if (textBox1.Text.Length < 11 || textBox1.Text == "")
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            if (textBox2.Text.Length < 2 || textBox2.Text == "")
                label2.ForeColor = Color.Red;
            else
                label2.ForeColor = Color.Black;

            if (textBox3.Text.Length < 2 || textBox3.Text == "")
                label3.ForeColor = Color.Red;
            else
                label3.ForeColor = Color.Black;

            if (textBox4.Text.Length != 8 || textBox4.Text == "")
                label5.ForeColor = Color.Red;
            else
                label5.ForeColor = Color.Black;

            if (textBox5.Text == "" || passsecurity < 70)
                label6.ForeColor = Color.Red;
            else
                label6.ForeColor = Color.Black;

            if (textBox6.Text == "" || textBox5.Text != textBox6.Text)
                label7.ForeColor = Color.Red;
            else
                label7.ForeColor = Color.Black;

            if (textBox1.Text.Length == 11 && textBox1.Text != "" && textBox2.Text != "" && textBox2.Text.Length > 1 &&
                textBox3.Text.Length > 1 && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != ""
                && textBox5.Text == textBox6.Text && passsecurity >= 70)
            {
                if (radioButton1.Checked == true)
                    auth = "admin";
                else
                    auth = "user";

                try
                {
                    connect.Open();
                    OleDbCommand add = new OleDbCommand("INSERT INTO staff values( '" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + auth + "','" + textBox4.Text + "','" + textBox5.Text + "')", connect);
                    add.ExecuteNonQuery();
                    connect.Close();
                    MessageBox.Show("new user added.", "successful!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    toppage1_clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connect.Close();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bool usrcase = false;
            if (textBox1.Text.Length == 11)
            {
                connect.Open();
                OleDbCommand search = new OleDbCommand("SELECT * from staff where ID='" + textBox1.Text + "'", connect);
                OleDbDataReader usrread = search.ExecuteReader();
                while (usrread.Read())
                {
                    usrcase = true;
                    textBox2.Text = usrread.GetValue(1).ToString();
                    textBox3.Text = usrread.GetValue(2).ToString();
                    if (usrread.GetValue(3).ToString() == "admin")
                        radioButton1.Checked = true;
                    else
                        radioButton2.Checked = true;

                    textBox4.Text = usrread.GetValue(4).ToString();
                    textBox5.Text = usrread.GetValue(5).ToString();
                    textBox6.Text = usrread.GetValue(5).ToString();
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
                toppage1_clear();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string auth = "";

            if (textBox1.Text.Length < 11 || textBox1.Text == "")
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            if (textBox2.Text.Length < 2 || textBox2.Text == "")
                label2.ForeColor = Color.Red;
            else
                label2.ForeColor = Color.Black;

            if (textBox3.Text.Length < 2 || textBox3.Text == "")
                label3.ForeColor = Color.Red;
            else
                label3.ForeColor = Color.Black;

            if (textBox4.Text.Length != 8 || textBox4.Text == "")
                label5.ForeColor = Color.Red;
            else
                label5.ForeColor = Color.Black;

            if (textBox5.Text == "" || passsecurity < 70)
                label6.ForeColor = Color.Red;
            else
                label6.ForeColor = Color.Black;

            if (textBox6.Text == "" || textBox5.Text != textBox6.Text)
                label7.ForeColor = Color.Red;
            else
                label7.ForeColor = Color.Black;

            if (textBox1.Text.Length == 11 && textBox1.Text != "" && textBox2.Text != "" && textBox2.Text.Length > 1 &&
                textBox3.Text.Length > 1 && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != ""
                && textBox5.Text == textBox6.Text && passsecurity >= 70)
            {
                if (radioButton1.Checked == true)
                    auth = "admin";
                else
                    auth = "user";

                try
                {
                    connect.Open();
                    OleDbCommand update = new OleDbCommand(
                        "UPDATE [staff] SET [name] = ?, [surname] = ?, [authority] = ?, [username] = ?, [password] = ? WHERE [ID] = ?", connect);

                    update.Parameters.AddWithValue("?", textBox2.Text);  // name
                    update.Parameters.AddWithValue("?", textBox3.Text);  // surname
                    update.Parameters.AddWithValue("?", auth);           // authority
                    update.Parameters.AddWithValue("?", textBox4.Text);  // username
                    update.Parameters.AddWithValue("?", textBox5.Text);  // password
                    update.Parameters.AddWithValue("?", textBox1.Text); // ID, güncellenecek kaydın kimliği

                    update.ExecuteNonQuery();
                    connect.Close();
                    MessageBox.Show("User information updated.", "Successful!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    users_show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connect.Close();
                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 11)
            {
                bool search_status = false;
                connect.Open();

                OleDbCommand selectsearch = new OleDbCommand("SELECT * from staff where ID='" + textBox1.Text + "'", connect);
                OleDbDataReader searchread = selectsearch.ExecuteReader();

                if (searchread.Read())
                {
                    search_status = true;
                    OleDbCommand deletesearch = new OleDbCommand("DELETE from staff where ID='" + textBox1.Text + "'", connect);
                    deletesearch.ExecuteNonQuery();
                    MessageBox.Show("User record deleted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    connect.Close();
                    users_show();
                    toppage1_clear();

                }
                else
                {
                    searchread.Close(); // Kayıt bulunmazsa da DataReader'ı kapatıyoruz
                    MessageBox.Show("No records found to delete!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                connect.Close(); // Bağlantıyı yalnızca burada kapatıyoruz
            }
            else
            {
                MessageBox.Show("Please enter an 11-digit ID number.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            toppage1_clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectimg = new OpenFileDialog();
            selectimg.Title = "Select staff picture";
            selectimg.Filter = "JPG FILES(*.jpg) | *.jpg";
            if (selectimg.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox2.Image = new Bitmap(selectimg.OpenFile());
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string gender = "";
            bool recordcontrol = false;
            connect.Open();
            OleDbCommand selectsve = new OleDbCommand("SELECT * from personnel where ID='" + textBox1.Text + "'", connect);
            OleDbDataReader recordre = selectsve.ExecuteReader();

            while (recordre.Read())
            {
                recordcontrol = true;
                break;
            }
            connect.Close();

            if (recordcontrol == false)
            {
                if (pictureBox2.Image == null)
                {
                    button6.ForeColor = Color.Red;
                }
                else
                    button6.ForeColor = Color.Black;

                if (comboBox1.Text == "")
                    label15.ForeColor = Color.Red;
                else
                    label15.ForeColor = Color.Black;

                if (comboBox2.Text == "")
                    label16.ForeColor = Color.Red;
                else
                    label16.ForeColor = Color.Black;

                if (comboBox3.Text == "")
                    label17.ForeColor = Color.Red;
                else
                    label17.ForeColor = Color.Black;


                if (pictureBox2.Image != null && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
                {
                    if (radioButton3.Checked == true)
                        gender = "Female";
                    else if (radioButton4.Checked == true)
                        gender = "Male";

                    try
                    {
                        connect.Open();
                        OleDbCommand add = new OleDbCommand("INSERT INTO personnel (ID, name, surname, gender, graduation, birth, job, place, salary) VALUES ('"
                            + textBox9.Text + "','"
                            + textBox8.Text + "','"
                            + textBox7.Text + "','"
                            + gender + "','"
                            + comboBox1.Text + "','"
                            + dateTimePicker1.Text + "','"
                            + comboBox2.Text + "','"
                            + comboBox3.Text + "','"
                            + textBox10.Text + "')", connect);
                        add.ExecuteNonQuery();
                        connect.Close();
                        if (!Directory.Exists(Application.StartupPath + "\\personnelimg"))
                            Directory.CreateDirectory(Application.StartupPath + "\\personnelimg");
                        else
                            pictureBox2.Image.Save(Application.StartupPath + "\\personnelimg\\" + textBox9.Text + ".jpg");
                        MessageBox.Show("A new personnel record has been created.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        persnl_show();
                        toppage2_clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connect.Close();
                    }

                }
                else
                    MessageBox.Show("Personnel record could not be created. Please check the information you entered.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                MessageBox.Show("The ID number entered has been registered in advance.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            toppage2_clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bool persnlcase = false;
            if (textBox9.Text.Length == 11)
            {
                connect.Open();
                OleDbCommand search = new OleDbCommand("SELECT * from personnel where ID='" + textBox9.Text + "'", connect);
                OleDbDataReader persnlread = search.ExecuteReader();
                while (persnlread.Read())
                {
                    persnlcase = true;
                    try
                    {
                        pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\personnelimg\\" + persnlread.GetValue(0).ToString() + ".jpg");
                    }
                    catch
                    {
                        pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\personnelimg\\noimg.jpg");

                    }

                    textBox9.Text = persnlread.GetValue(0).ToString();
                    textBox8.Text = persnlread.GetValue(1).ToString();
                    textBox7.Text = persnlread.GetValue(2).ToString();
                    if (persnlread.GetValue(3).ToString() == "Female")
                        radioButton4.Checked = true;
                    else
                        radioButton3.Checked = true;

                    comboBox1.Text = persnlread.GetValue(4).ToString();
                    dateTimePicker1.Text = persnlread.GetValue(5).ToString();
                    comboBox2.Text = persnlread.GetValue(6).ToString();
                    comboBox3.Text = persnlread.GetValue(7).ToString();
                    textBox10.Text = persnlread.GetValue(8).ToString();

                    break;
                }
                if (persnlcase == false)
                {
                    MessageBox.Show("The searched record was not found", "not successful", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                connect.Close();
            }
            else
            {
                MessageBox.Show("Please enter your 11 digit ID:", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toppage2_clear();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox9.Text.Length == 11)
            {
                bool search_status = false;
                connect.Open();

                OleDbCommand selectsearch = new OleDbCommand("SELECT * from personnel where ID='" + textBox9.Text + "'", connect);
                OleDbDataReader searchread = selectsearch.ExecuteReader();

                if (searchread.Read())
                {
                    search_status = true;
                    OleDbCommand deletesearch = new OleDbCommand("DELETE from personnel where ID='" + textBox9.Text + "'", connect);
                    deletesearch.ExecuteNonQuery();
                    MessageBox.Show("Personnel  record deleted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    connect.Close();
                    persnl_show();
                    toppage2_clear();

                }
                else
                {
                    searchread.Close(); // Kayıt bulunmazsa da DataReader'ı kapatıyoruz
                    MessageBox.Show("No records found to delete!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                connect.Close(); // Bağlantıyı yalnızca burada kapatıyoruz
            }
            else
            {
                MessageBox.Show("Please enter an 11-digit ID number.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string gender = "";

            if (pictureBox2.Image == null)
                button6.ForeColor = Color.Red;
            else
                button6.ForeColor = Color.Black;

            if (textBox9.Text.Length < 11 || textBox9.Text == "")
                label13.ForeColor = Color.Red;
            else
                label13.ForeColor = Color.Black;

            if (textBox8.Text.Length < 2 || textBox8.Text == "")
                label12.ForeColor = Color.Red;
            else
                label12.ForeColor = Color.Black;

            if (textBox7.Text.Length < 2 || textBox7.Text == "")
                label11.ForeColor = Color.Red;
            else
                label11.ForeColor = Color.Black;

            if (textBox10.Text.Length < 5 || textBox10.Text == "")
                label19.ForeColor = Color.Red;
            else
                label19.ForeColor = Color.Black;

            if (comboBox1.Text == "")
                label15.ForeColor = Color.Red;
            else
                label5.ForeColor = Color.Black;

            if (comboBox1.Text == "")
                label15.ForeColor = Color.Red;
            else
                label5.ForeColor = Color.Black;


            if (comboBox2.Text == "")
                label17.ForeColor = Color.Red;
            else
                label7.ForeColor = Color.Black;


            if (comboBox3.Text == "")
                label18.ForeColor = Color.Red;
            else
                label8.ForeColor = Color.Black;

            if (textBox9.Text.Length == 11 && textBox8.Text != "" && textBox7.Text != "" && textBox10.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
            {
                if (radioButton3.Checked == true)
                    gender = "Female";
                else
                    gender = "woman";

                try
                {
                    connect.Open();
                    OleDbCommand update = new OleDbCommand(
                        "UPDATE [personnel] SET [name] = ?, [surname] = ?, [gender] = ?, [graduation] = ?, [birth] = ?, [job] = ?, [place] = ?, [salary] = ? WHERE [ID] = ?", connect);

                    update.Parameters.AddWithValue("?", textBox8.Text);
                    update.Parameters.AddWithValue("?", textBox7.Text);
                    update.Parameters.AddWithValue("?", gender);
                    update.Parameters.AddWithValue("?", comboBox1.Text);
                    update.Parameters.AddWithValue("?", dateTimePicker1.Text);
                    update.Parameters.AddWithValue("?", comboBox2.Text);
                    update.Parameters.AddWithValue("?", comboBox3.Text);
                    update.Parameters.AddWithValue("?", textBox10.Text);
                    update.Parameters.AddWithValue("?", textBox9.Text);  // ID



                    update.ExecuteNonQuery();
                    connect.Close();
                    MessageBox.Show("Personnel information updated.", "Successful!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    persnl_show();
                    toppage2_clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connect.Close();
                }

            }
        }
    }
}
