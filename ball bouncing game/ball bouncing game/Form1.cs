using System;
using System.Windows.Forms;

namespace ball_bouncing_game
{
    public partial class Form1 : Form
    {
        private int bounceCount = 0;  // Counter for the number of bounces
        private int ballSpeed = 8;     // Speed at which the ball moves
        private bool isFalling = true; // Flag to check if the ball is falling
        private bool isGameStarted = false; // To track if the game has started
        private bool isGameOver = false; // To check if the game is over

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            balpic.Visible = false;  // Hide the ball until the game starts
            label1.Text = "Press SPACE to start";  // Initial message
            textBox2.Text = "0";  // Clear the bounce count display
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // If the game is over, do not move the ball
            if (isGameOver) return;

            // If the ball is falling
            if (isFalling)
            {
                balpic.Top += ballSpeed;  // Move the ball downwards

                // If the ball reaches the bottom of the girl picture, stop the game
                if (balpic.Top >= girlpic.Bottom - balpic.Height)
                {
                    timer1.Stop();  // Stop the timer
                    label1.Text = $"Game Over! The ball bounced {bounceCount} times.";
                    isGameStarted = false;  // The game has ended
                    isGameOver = true;  // Activate game over check
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
            // Stop the game
            timer1.Stop();
            balpic.Visible = false;  // Hide the ball
            label1.Text = $"Game Stopped. You bounced the ball {bounceCount} times.";
            isGameStarted = false;
            isGameOver = true;  // Mark the game as over when stopped
        }
    }
}
