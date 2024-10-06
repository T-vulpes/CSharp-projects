using System;
using System.Windows.Forms;

namespace ball_bouncing_game
{
    public partial class Form1 : Form
    {
        private int bounceCount = 0;  
        private int ballSpeed = 8;    
        private bool isFalling = true; 
        private bool isGameStarted = false; 
        private bool isGameOver = false; 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            balpic.Visible = false; 
            label1.Text = "Press SPACE to start";  
            textBox2.Text = "0"; 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isGameOver) return;
            if (isFalling)
            {
                balpic.Top += ballSpeed;  
                if (balpic.Top >= girlpic.Bottom - balpic.Height)
                {
                    timer1.Stop();  
                    label1.Text = $"Game Over! The ball bounced {bounceCount} times.";
                    isGameStarted = false;  
                    isGameOver = true;  
                    return;
                }
            }
            else
            {
                balpic.Top -= ballSpeed;  
                if (balpic.Top <= 50)  
                {
                    isFalling = true;
                }
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Space && isGameStarted && !isGameOver)
            {
                bounceCount++;  
                textBox2.Text = bounceCount.ToString();  

                isFalling = false;  
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            isGameStarted = true;
            isGameOver = false;  
            bounceCount = 0;  
            balpic.Visible = true; 
            balpic.Top = 50;  
            isFalling = true;  
            timer1.Start();  
            label1.Text = "";  
        }
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            balpic.Visible = false; 
            label1.Text = $"Game Stopped. You bounced the ball {bounceCount} times.";
            isGameStarted = false;
            isGameOver = true;  
        }
    }
}
