using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SantaComin
{
    public partial class Form1 : Form
    {
        int gravity = 10;
        int treeSpeed = 6;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void Time_Tick(object sender, EventArgs e)
        {
            Santa.Top += gravity;
            TopTree.Left -= treeSpeed;
            BottomTree.Left -= treeSpeed;
            Score.Text = $"Score: {score}";

            if (TopTree.Left < -200)
            {
                TopTree.Left = 800 ;
                score++;
            }


            if(BottomTree.Left < -200)
            {
                BottomTree.Left = 900;
                score++;
            }

            if (Santa.Top < -25)
            {
                GameOver();
            }



            if (Santa.Bounds.IntersectsWith(TopTree.Bounds) || Santa.Bounds.IntersectsWith(BottomTree.Bounds) || Santa.Bounds.IntersectsWith(Ground.Bounds))
            {
                GameOver();
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -5;
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }
        }
        private void GameOver()
        {
            Time.Stop();
            Score.Text = $"Game Over!";
            Restart.Visible = true;
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            Form1 NewForm = new Form1();
            NewForm.Show();
            this.Dispose(false); 
        }
    }
}
