﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.Aztec;

// This form captures video from a webcam and decodes QR codes from the video stream, displaying the decoded data.

namespace Creating_QR_Code
{
    public partial class Form1 : Form
    {
        FilterInfoCollection webcam;
        VideoCaptureDevice cam;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach(FilterInfo dev in webcam)
            {
                comboBox1.Items.Add(dev.Name);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void cam_newcam(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image=((Bitmap)eventArgs.Frame.Clone());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cam = new VideoCaptureDevice(webcam[comboBox1.SelectedIndex].MonikerString);
            cam.NewFrame += new NewFrameEventHandler(cam_newcam);
            cam.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BarcodeReader mbarcode = new BarcodeReader();
            if (pictureBox1.Image != null)
            {
                Result res = mbarcode.Decode((Bitmap)pictureBox1.Image);
                try
                {
                    string dec = res.ToString().Trim();
                    if (dec != "")
                    {
                        timer1.Stop();
                        textBox1.Text = dec;
                    }
                }
                catch(Exception ex)
                {}
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cam != null)
            {
                if (cam.IsRunning == true)
                {
                    cam.Stop();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 add = new Form2();
            add.Show();
            this.Hide();
        }
    }
}
