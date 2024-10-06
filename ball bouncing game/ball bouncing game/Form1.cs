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
                balpic.Top -= ballSpeed;  // Move the ball upwards

                // If the ball reaches the top limit, let it fall back
                if (balpic.Top <= 50)  // Set the upper limit
                {
                    isFalling = true;
                }
            }
        }

        // Spacebar key press event handler
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Space && isGameStarted && !isGameOver)
            {
                bounceCount++;  // Increment bounce count
                textBox2.Text = bounceCount.ToString();  // Update the bounce count display

                isFalling = false;  // Reverse the ball's direction
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Start the game
            isGameStarted = true;
            isGameOver = false;  // Ensure the game is not marked as over when starting again
            bounceCount = 0;  // Reset bounce count
            balpic.Visible = true;  // Show the ball
            balpic.Top = 50;  // Set initial position
            isFalling = true;  // Start the ball falling
            timer1.Start();  // Start the timer
            label1.Text = "";  // Clear the on-screen message
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
