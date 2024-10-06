namespace ball_bouncing_game
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.girlpic = new System.Windows.Forms.PictureBox();
            this.balpic = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.girlpic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.balpic)).BeginInit();
            this.SuspendLayout();
            this.button1.Location = new System.Drawing.Point(77, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(254, 72);
            this.button1.TabIndex = 0;
            this.button1.Text = "START";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button2.Location = new System.Drawing.Point(77, 148);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(254, 72);
            this.button2.TabIndex = 1;
            this.button2.Text = "STOP";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);

            this.girlpic.Image = ((System.Drawing.Image)(resources.GetObject("girlpic.Image")));
            this.girlpic.Location = new System.Drawing.Point(414, 18);
            this.girlpic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.girlpic.Name = "girlpic";
            this.girlpic.Size = new System.Drawing.Size(278, 352);
            this.girlpic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.girlpic.TabIndex = 2;
            this.girlpic.TabStop = false;

            this.balpic.BackColor = System.Drawing.Color.Transparent;
            this.balpic.Image = ((System.Drawing.Image)(resources.GetObject("balpic.Image")));
            this.balpic.Location = new System.Drawing.Point(591, 220);
            this.balpic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.balpic.Name = "balpic";
            this.balpic.Size = new System.Drawing.Size(71, 69);
            this.balpic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.balpic.TabIndex = 3;
            this.balpic.TabStop = false;
            this.balpic.Visible = false;
  
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(754, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 29);
            this.label1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(12, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(301, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Number of bounced balls : ";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(88, 302);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(148, 26);
            this.textBox2.TabIndex = 7;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(722, 20);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(0, 20);
            this.labelTime.TabIndex = 8;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.OliveDrab;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(319, 351);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(471, 19);
            this.textBox1.TabIndex = 9;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(864, 455);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.balpic);
            this.Controls.Add(this.girlpic);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Ball Bouncing Game";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.girlpic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.balpic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox girlpic;
        private System.Windows.Forms.PictureBox balpic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
    }
}
