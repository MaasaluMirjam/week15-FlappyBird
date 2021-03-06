using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        int gravity = 10;
        int pipeSpeed = 6;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_tick(object sender, EventArgs e)
        {
            bird.Top += gravity;
            pipeTop.Left -= pipeSpeed;
            pipeBottom.Left -= pipeSpeed;
            scoreLabel.Text = $"Score: {score}";

            if (pipeTop.Left < -100)
            {
                pipeTop.Left = 500;
                score++;
            }

            if(pipeBottom.Left < -100)
            {
                pipeBottom.Left = 600;
                score++;
            }

            if(bird.Top < -25)
            {
                gameOver();
            }

            if(bird.Bounds.IntersectsWith(pipeTop.Bounds) || bird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                bird.Bounds.IntersectsWith(grounds.Bounds))
            {
                gameOver();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -5;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }
        }

        private void bird_Click(object sender, EventArgs e)
        {

        }

        private void gameOver()
        {
            timer1.Stop();
            scoreLabel.Text = $"Game over!";
        }
       
    }
}
