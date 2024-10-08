// This form allows the user to generate a QR code based on input data and display it in a PictureBox.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagingToolkit.QRCode;
using MessagingToolkit.QRCode.Codec;
namespace Creating_QR_Code
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        QRCodeEncoder code = new QRCodeEncoder();
        Image img;

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            img = code.Encode(textBox1.Text);
            pictureBox1.Image = img;
        }
    }
}
