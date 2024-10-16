using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gas_Station_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double d_gas95 = 0, d_gaso97 = 0, d_diesel = 0, d_eurodiesel = 0, d_lpg = 0;
        double e_gas95 = 0, e_gaso97 = 0, e_diesel = 0, e_eurodiesel = 0, e_lpg = 0;
        double f_gas95 = 0, f_gaso97 = 0, f_diesel = 0, f_eurodiesel = 0, f_lpg = 0;
        double s_gas95 = 0, s_gaso97 = 0, s_diesel = 0, s_eurodiesel = 0, s_lpg = 0;

        string[] wrehoseinfo = new string[5];
        string[] priceinfo = new string[5];
        
        private void txt_read()
        {
            wrehoseinfo = System.IO.File.ReadAllLines(Application.StartupPath + "\\gastank.txt");
            d_gas95 = Convert.ToDouble(wrehoseinfo[0]);
            d_gaso97 = Convert.ToDouble(wrehoseinfo[1]);
            d_diesel = Convert.ToDouble(wrehoseinfo[2]);
            d_eurodiesel = Convert.ToDouble(wrehoseinfo[3]);
            d_lpg = Convert.ToDouble(wrehoseinfo[4]);
        }
        
        private void txt_write()
        {
            label6.Text = d_gas95.ToString("N");
            label7.Text = d_gaso97.ToString("N");
            label8.Text = d_diesel.ToString("N");
            label9.Text = d_eurodiesel.ToString("N");
            label10.Text = d_lpg.ToString("N");
        }

        private void txt_price_read()
        {
            wrehoseinfo = System.IO.File.ReadAllLines(Application.StartupPath + "\\price.txt");
            f_gas95 = Convert.ToDouble(wrehoseinfo[0]);
            f_gaso97 = Convert.ToDouble(wrehoseinfo[1]);
            f_diesel = Convert.ToDouble(wrehoseinfo[2]);
            f_eurodiesel = Convert.ToDouble(wrehoseinfo[3]);
            f_lpg = Convert.ToDouble(wrehoseinfo[4]);
        }
        
        private void txt_price_write()
        {
            label16.Text = f_gas95.ToString("N");
            label15.Text = f_gaso97.ToString("N");
            label14.Text = f_diesel.ToString("N");
            label13.Text = f_eurodiesel.ToString("N");
            label12.Text = f_lpg.ToString("N");

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "gasoline (95)")
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;

            }
            if (comboBox1.Text == "gasoline (97)")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }
            if (comboBox1.Text == "diesel")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = true;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }
            if (comboBox1.Text == "euro diesel")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = true;
                numericUpDown5.Enabled = false;
            }
            if (comboBox1.Text == "LPG")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = true;
            }

            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
            label29.Text = "____________";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                e_gas95 = Convert.ToDouble(textBox1.Text);
                if (1000 < e_gas95 + d_gas95 || e_gas95 <= 0)
                    textBox1.Text = "!Error!";

                else
                    wrehoseinfo[0] = Convert.ToString(d_gas95 + e_gas95);


            }
            catch (Exception)
            {
                textBox1.Text = "Error";
            }
            try
            {
                e_gaso97 = Convert.ToDouble(textBox2.Text);
                if (1000 < e_gaso97 + d_gaso97 || e_gaso97 <= 0)
                    textBox2.Text = "!Error!";

                else
                    wrehoseinfo[1] = Convert.ToString(d_gaso97 + e_gaso97);


            }
            catch (Exception)
            {
                textBox2.Text = "Error";
            }
            try
            {
                e_diesel = Convert.ToDouble(textBox3.Text);
                if (1000 < e_diesel + d_diesel || e_diesel <= 0)
                    textBox3.Text = "!Error!";

                else
                    wrehoseinfo[2] = Convert.ToString(d_diesel + e_diesel);


            }
            catch (Exception)
            {
                textBox3.Text = "Error";
            }
            try
            {
                e_eurodiesel = Convert.ToDouble(textBox4.Text);
                if (1000 < e_eurodiesel + d_eurodiesel || e_eurodiesel <= 0)
                    textBox4.Text = "!Error!";

                else
                    wrehoseinfo[3] = Convert.ToString(d_eurodiesel + e_eurodiesel);


            }
            catch (Exception)
            {
                textBox4.Text = "Error";
            }
            try
            {
                e_lpg = Convert.ToDouble(textBox5.Text);
                if (1000 < e_lpg + d_lpg || e_lpg <= 0)
                    textBox5.Text = "!Error!";

                else
                    wrehoseinfo[4] = Convert.ToString(d_lpg + e_lpg);


            }
            catch (Exception)
            {
                textBox5.Text = "Error";
            }
            System.IO.File.WriteAllLines(Application.StartupPath + "\\gastank.txt", wrehoseinfo);
            txt_read();
            txt_write();
            progressbar_update();
            numericupdate();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                f_gas95 = f_gas95 + (f_gas95 * Convert.ToDouble(textBox10.Text) / 100);
                priceinfo[0] = Convert.ToString(f_gas95);
            }
            catch(Exception)
            {
                textBox10.Text = "Error";
            }
            try
            {
                f_gaso97 = f_gaso97 + (f_gaso97 * Convert.ToDouble(textBox9.Text) / 100);
                priceinfo[1] = Convert.ToString(f_gaso97);
            }
            catch (Exception)
            {
                textBox9.Text = "Error";
            }
            try
            {
                f_diesel = f_diesel + (f_diesel * Convert.ToDouble(textBox8.Text) / 100);
                priceinfo[2] = Convert.ToString(f_diesel);
            }
            catch (Exception)
            {
                textBox8.Text = "Error";
            }
            try
            {
                f_eurodiesel = f_eurodiesel + (f_eurodiesel * Convert.ToDouble(textBox7.Text) / 100);
                priceinfo[3] = Convert.ToString(f_eurodiesel);
            }
            catch (Exception)
            {
                textBox7.Text = "Error";
            }
            try
            {
                f_lpg = f_lpg + (f_lpg * Convert.ToDouble(textBox6.Text) / 100);
                priceinfo[4] = Convert.ToString(f_lpg);
            }
            catch (Exception)
            {
                textBox6.Text = "Error";
            }

            System.IO.File.WriteAllLines(Application.StartupPath + "\\price.txt", priceinfo);
            txt_price_read();
            txt_price_write();
        }
             

        private void button3_Click(object sender, EventArgs e)
        {
            s_gas95 = double.Parse(numericUpDown1.Value.ToString());
            s_gaso97 = double.Parse(numericUpDown2.Value.ToString());
            s_diesel = double.Parse(numericUpDown3.Value.ToString());
            s_eurodiesel = double.Parse(numericUpDown4.Value.ToString());
            s_lpg = double.Parse(numericUpDown5.Value.ToString());

            if (numericUpDown1.Enabled == true)
            {
                d_gas95 = d_gas95 - s_gas95;
                label29.Text = Convert.ToString(s_gas95 * f_gas95);
            }
            else if (numericUpDown2.Enabled == true)
            {
                d_gaso97 = d_gaso97 - s_gaso97;
                label29.Text = Convert.ToString(s_gaso97 * f_gaso97);
            }
            else if (numericUpDown3.Enabled == true)
            {
                d_diesel = d_diesel - s_diesel;
                label29.Text = Convert.ToString(s_diesel * f_diesel);
            }
            else if (numericUpDown4.Enabled == true)
            {
                d_eurodiesel = d_eurodiesel - s_eurodiesel;
                label29.Text = Convert.ToString(s_eurodiesel * f_eurodiesel);
            }
            else if (numericUpDown5.Enabled == true)
            {
                d_lpg = d_lpg - s_lpg;
                label29.Text = Convert.ToString(s_lpg * f_lpg);
            }

            wrehoseinfo[0] = Convert.ToString(d_gas95);
            wrehoseinfo[1] = Convert.ToString(d_gaso97);
            wrehoseinfo[2] = Convert.ToString(d_diesel);
            wrehoseinfo[3] = Convert.ToString(d_eurodiesel);
            wrehoseinfo[4] = Convert.ToString(d_lpg);

            System.IO.File.WriteAllLines(Application.StartupPath + "\\gastank.txt", wrehoseinfo);
            txt_read();
            txt_write();
            progressbar_update();
            numericupdate();

            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
        }


        private void progressbar_update()
        {
            progressBar1.Value = Convert.ToInt16(d_gas95);
            progressBar2.Value = Convert.ToInt16(d_gaso97);
            progressBar3.Value = Convert.ToInt16(d_diesel);
            progressBar4.Value = Convert.ToInt16(d_eurodiesel);
            progressBar5.Value = Convert.ToInt16(d_lpg);

        }

        private void numericupdate()
        {
            numericUpDown1.Maximum = decimal.Parse(d_gas95.ToString());
            numericUpDown2.Maximum = decimal.Parse(d_gaso97.ToString());
            numericUpDown3.Maximum = decimal.Parse(d_diesel.ToString());
            numericUpDown4.Maximum = decimal.Parse(d_eurodiesel.ToString());
            numericUpDown5.Maximum = decimal.Parse(d_lpg.ToString());
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "$ FUEL AUTOMATION $";
            progressBar1.Maximum = 1000;
            progressBar2.Maximum = 1000;
            progressBar3.Maximum = 1000;
            progressBar4.Maximum = 1000;
            progressBar5.Maximum = 1000;
            txt_read();
            txt_write();
            txt_price_read();
            txt_price_write();
            numericupdate();
            progressbar_update();



        }
    }
}
